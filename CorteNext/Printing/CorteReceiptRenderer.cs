using CorteNext.Models;
using CorteNext.Services;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace CorteNext.Printing
{
  public sealed class CorteReceiptRenderer
      : ICorteReceiptRenderer
  {
    private const int ReceiptWidth = 380;
    private const int MaximumReceiptHeight = 1400;
    private const float LeftMargin = 1F;
    private const float RightMargin = 12F;
    private readonly IFondoService _fondoService;

    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public CorteReceiptRenderer(IFondoService fondoService)
    {
      _fondoService = fondoService;
    }

    // =========================================================
    // RENDER
    // =========================================================

    public Bitmap Render(CorteRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);
      FondoRecord? fondo = LoadFondo(record);

      Bitmap bitmap =
          new(
              ReceiptWidth,
              MaximumReceiptHeight,
              PixelFormat.Format32bppRgb);

      using Graphics graphics = Graphics.FromImage(bitmap);
      ConfigureGraphics(graphics);
      graphics.Clear(Color.White);
      int y = 8;

      // =====================================================
      // HEADER
      // =====================================================

      DrawCenteredText(
          graphics,
          GetShiftDisplayName(
              record.Shift),
          fontSize: 18F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 0);

      DrawCenteredText(
          graphics,
          record.Date.ToString(
              "dddd"),
          fontSize: 14F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 0);

      DrawCenteredText(
          graphics,
          record.Date.ToString(
              "MM/dd/yyyy"),
          fontSize: 14F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 0);

      DrawCenteredText(
          graphics,
          record.Time,
          fontSize: 14F,
          style: FontStyle.Regular,
          ref y,
          bottomSpacing: 2);

      DrawSeparator(graphics, ref y);

      // =====================================================
      // CASH COUNT
      // =====================================================

      DrawSectionTitle(
          graphics,
          "CASH COUNT",
          ref y);

      DrawMoneyRow(
          graphics,
          "$1",
          FormatMoney(record.One),
          ref y);

      DrawMoneyRow(
          graphics,
          "$5",
          FormatMoney(record.Five),
          ref y);

      DrawMoneyRow(
          graphics,
          "$10",
          FormatMoney(record.Ten),
          ref y);

      DrawMoneyRow(
          graphics,
          "$20",
          FormatMoney(record.Twenty),
          ref y);

      DrawMoneyRow(
          graphics,
          "$50",
          FormatMoney(record.Fifty),
          ref y);

      DrawMoneyRow(
          graphics,
          "$100",
          FormatMoney(record.Hundred),
          ref y);

      DrawMoneyRow(
          graphics,
          "QTR",
          FormatMoney(record.Quarter),
          ref y);

      DrawSeparator(graphics, ref y);

      DrawMoneyRow(
          graphics,
          "TOTAL CASH",
          FormatMoney(record.TotalCash),
          ref y,
          bold: true,
          fontSize: 12F);

      // =====================================================
      // DRIVE TIP AND EXPENSES
      // =====================================================

      if (IsRegularCorte(record.Shift))
      {
        DrawMoneyRow(
            graphics,
            "DRIVE TIP",
            FormatMoney(record.DriveTip),
            ref y);

        DrawMoneyRow(
            graphics,
            "EXPENSES",
            FormatMoney(record.Expenses),
            ref y);
      }

      DrawSeparator(graphics, ref y);

      DrawMoneyRow(
          graphics,
          "GROSS TOTAL",
          FormatMoney(record.GrossTotal),
          ref y,
          bold: true,
          fontSize: 12F);

      AddVerticalSpace(ref y, 3);

      // =====================================================
      // FONDO
      // =====================================================

      DrawSectionTitle(graphics, "FONDO", ref y);

      if (fondo != null)
      {
        DrawMoneyRow(
            graphics,
            "$1",
            FormatMoney(fondo.One),
            ref y);

        DrawMoneyRow(
            graphics,
            "$5",
            FormatMoney(fondo.Five),
            ref y);

        DrawMoneyRow(
            graphics,
            "$10",
            FormatMoney(fondo.Ten),
            ref y);

        DrawMoneyRow(
            graphics,
            "QTR1",
            FormatMoney(fondo.Quarter1),
            ref y);

        DrawMoneyRow(
            graphics,
            "QTR2",
            FormatMoney(fondo.Quarter2),
            ref y);
      }
      else
      {
        DrawCenteredText(
            graphics,
            "FONDO DETAIL NOT AVAILABLE",
            fontSize: 9.5F,
            style: FontStyle.Italic,
            ref y,
            bottomSpacing: 2);
      }

      DrawSeparator(
          graphics,
          ref y);

      DrawMoneyRow(
          graphics,
          "TOTAL FONDO",
          FormatDeduction(record.Fondo),
          ref y,
          bold: true,
          fontSize: 12F);

      AddVerticalSpace(
          ref y,
          3);

      // =====================================================
      // FINAL CALCULATION
      // =====================================================

      DrawMoneyRow(
          graphics,
          "NET TOTAL",
          FormatMoney(record.NetTotal),
          ref y,
          bold: true,
          fontSize: 13F);

      DrawMoneyRow(
          graphics,
          "SALES",
          FormatDeduction(record.Sales),
          ref y,
          bold: true,
          fontSize: 12F);

      DrawSeparator(
          graphics,
          ref y);

      // =====================================================
      // SHORT / OVER
      // =====================================================

      DrawResult(
          graphics,
          record.ShortOver,
          ref y);

      DrawSeparator(
          graphics,
          ref y);

      // =====================================================
      // EXPENSE SUMMARY
      // =====================================================

      if (IsRegularCorte(record.Shift))
      {
        DrawMoneyRow(
            graphics,
            "TOTAL EXPENSES",
            FormatMoney(record.Expenses),
            ref y,
            bold: true,
            fontSize: 11F);

        DrawSeparator(graphics, ref y);
      }

      // =====================================================
      // STAFF
      // =====================================================

      DrawMoneyRow(
          graphics,
          "STAFF",
          GetStaffDisplayName(
              record.StaffName),
          ref y,
          bold: true,
          fontSize: 11F);

      DrawSeparator(graphics, ref y);

      // =====================================================
      // FOOTER
      // =====================================================

      DrawCenteredText(
          graphics,
          GetShiftDisplayName(
              record.Shift),
          fontSize: 14F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 4);

      return CropBitmap(bitmap, y + 8);
    }

    // =========================================================
    // LOAD MATCHING FONDO
    // =========================================================

    private FondoRecord? LoadFondo(CorteRecord record)
    {
      string fondoShift = GetFondoShift(record.Shift);
      return _fondoService.GetFondo(record.Date.Date, fondoShift);
    }

    // =========================================================
    // FONDO SHIFT MAPPING
    // =========================================================

    private static string GetFondoShift(string corteShift)
    {
      if (string.IsNullOrWhiteSpace(corteShift))
      {
        throw new InvalidOperationException("Corte shift is missing.");
      }

      return corteShift.Trim() switch
      {
        "am" => "am",

        "pm" => "pm",

        "amDrive" => "drive",

        "pmDrive" => "drive",

        _ => throw new InvalidOperationException($"Unknown Corte shift: {corteShift}")
      };
    }

    // =========================================================
    // CONFIGURE GRAPHICS
    // =========================================================

    private static void ConfigureGraphics(
        Graphics graphics)
    {
      graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
      graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
      graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
    }

    // =========================================================
    // SECTION TITLE
    // =========================================================

    private static void DrawSectionTitle(Graphics graphics, string text, ref int y)
    {
      using Font font =
          new(
              "Segoe UI",
              12F,
              FontStyle.Bold);

      using Brush brush = new SolidBrush(Color.Black);
      float height = font.GetHeight(graphics) + 2F;

      RectangleF bounds =
          new(
              LeftMargin,
              y,
              ReceiptWidth -
              LeftMargin -
              RightMargin,
              height);

      using StringFormat format =
          new()
          {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center,
            FormatFlags = StringFormatFlags.NoWrap
          };

      graphics.DrawString(
          text,
          font,
          brush,
          bounds,
          format);

      y += (int)Math.Ceiling(height) + 2;
    }

    // =========================================================
    // RECEIPT ROW
    // =========================================================

    private static void DrawMoneyRow(
        Graphics graphics,
        string label,
        string value,
        ref int y,
        bool bold = false,
        float fontSize = 12F)
    {
      FontStyle style = bold ? FontStyle.Bold : FontStyle.Regular;

      using Font font = new(
              "Segoe UI",
              fontSize,
              style);

      using Brush brush = new SolidBrush(Color.Black);
      float availableWidth = ReceiptWidth - LeftMargin - RightMargin;
      float rowHeight = font.GetHeight(graphics) + 2F;

      RectangleF rowBounds = new(
              LeftMargin,
              y,
              availableWidth,
              rowHeight);

      using StringFormat labelFormat = new()
      {
        Alignment = StringAlignment.Near,
        LineAlignment = StringAlignment.Center,
        Trimming = StringTrimming.EllipsisCharacter,
        FormatFlags = StringFormatFlags.NoWrap
      };

      using StringFormat valueFormat = new()
      {
        Alignment = StringAlignment.Far,
        LineAlignment = StringAlignment.Center,
        Trimming = StringTrimming.None,
        FormatFlags = StringFormatFlags.NoWrap
      };

      graphics.DrawString(
          label,
          font,
          brush,
          rowBounds,
          labelFormat);

      graphics.DrawString(
          value,
          font,
          brush,
          rowBounds,
          valueFormat);

      y += (int)Math.Ceiling(rowHeight);
    }

    // =========================================================
    // SHORT / OVER RESULT
    // =========================================================

    private static void DrawResult(
        Graphics graphics,
        decimal value,
        ref int y)
    {
      string heading;
      string formattedValue;

      if (value < 0M)
      {
        heading = "SHORT";
        formattedValue = FormatDeduction(value);
      }
      else if (value > 0M)
      {
        heading = "OVER";
        formattedValue = FormatMoney(value);
      }
      else
      {
        heading = "BALANCED";
        formattedValue = FormatMoney(0M);
      }

      DrawCenteredText(
          graphics,
          heading,
          fontSize: 17F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 0);

      DrawCenteredText(
          graphics,
          formattedValue,
          fontSize: 21F,
          style: FontStyle.Bold,
          ref y,
          bottomSpacing: 2);
    }

    // =========================================================
    // CENTERED TEXT
    // =========================================================

    private static void DrawCenteredText(
        Graphics graphics,
        string text,
        float fontSize,
        FontStyle style,
        ref int y,
        int bottomSpacing)
    {
      using Font font = new(
              "Segoe UI",
              fontSize,
              style);

      using Brush brush = new SolidBrush(Color.Black);
      float height = font.GetHeight(graphics) + 2F;

      RectangleF bounds = new(
              LeftMargin,
              y,
              ReceiptWidth -
              LeftMargin -
              RightMargin,
              height);

      using StringFormat format = new()
      {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center,
        Trimming = StringTrimming.EllipsisCharacter,
        FormatFlags = StringFormatFlags.NoWrap
      };

      graphics.DrawString(
          text,
          font,
          brush,
          bounds,
          format);

      y += (int)Math.Ceiling(height) + bottomSpacing;
    }

    // =========================================================
    // SEPARATOR
    // =========================================================

    private static void DrawSeparator(Graphics graphics, ref int y)
    {
      y += 2;

      using Pen pen =
          new(
              Color.Black,
              4.5F);

      graphics.DrawLine(
          pen,
          LeftMargin,
          y,
          ReceiptWidth - RightMargin,
          y);

      y += 4;
    }

    // =========================================================
    // SPACING
    // =========================================================

    private static void AddVerticalSpace(ref int y, int space)
    {
      y += space;
    }

    // =========================================================
    // MONEY FORMATTING
    // =========================================================

    private static string FormatMoney(decimal value)
    {
      return Math.Abs(value).ToString("C2");
    }

    private static string FormatDeduction(decimal value)
    {
      return $"({Math.Abs(value):C2})";
    }

    // =========================================================
    // STAFF
    // =========================================================

    private static string GetStaffDisplayName(string staffName)
    {
      if (string.IsNullOrWhiteSpace(staffName))
      {
        return "NOT ENTERED";
      }

      return staffName.Trim().ToUpperInvariant();
    }

    // =========================================================
    // SHIFT DISPLAY
    // =========================================================

    private static string GetShiftDisplayName(string shift)
    {
      if (string.IsNullOrWhiteSpace(shift))
      {
        return "CORTE";
      }

      return shift.Trim() switch
      {
        "am" => "AM CORTE",
        "pm" => "PM CORTE",
        "amDrive" => "AM DRIVE CORTE",
        "pmDrive" => "PM DRIVE CORTE",
        _ => "CORTE"
      };
    }

    // =========================================================
    // REGULAR CORTE
    // =========================================================

    private static bool IsRegularCorte(
        string shift)
    {
      return string.Equals(
                 shift?.Trim(),
                 "am",
                 StringComparison.OrdinalIgnoreCase) ||
             string.Equals(
                 shift?.Trim(),
                 "pm",
                 StringComparison.OrdinalIgnoreCase);
    }

    // =========================================================
    // CROP BITMAP
    // =========================================================

    private static Bitmap CropBitmap(
        Bitmap source,
        int requestedHeight)
    {
      int height =
          Math.Max(
              1,
              Math.Min(
                  requestedHeight,
                  source.Height));

      Bitmap result =
          new(
              source.Width,
              height,
              PixelFormat.Format32bppRgb);

      using Graphics graphics =
          Graphics.FromImage(
              result);

      graphics.Clear(
          Color.White);

      Rectangle destinationRectangle =
          new(
              0,
              0,
              result.Width,
              result.Height);

      Rectangle sourceRectangle =
          new(
              0,
              0,
              source.Width,
              height);

      graphics.DrawImage(
          source,
          destinationRectangle,
          sourceRectangle,
          GraphicsUnit.Pixel);

      source.Dispose();

      return result;
    }
  }
}
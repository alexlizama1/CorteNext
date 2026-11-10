using CorteNext.Models;
using CorteNext.Services;
using System.Drawing.Printing;

namespace CorteNext.Printing
{
  public sealed class ReceiptPrintService : IReceiptPrintService
  {
    private readonly ICorteReceiptRenderer _corteRenderer;
    private readonly IPrinterSettingsService _printerSettings;
    private Bitmap? _printImage;

    public ReceiptPrintService(
        ICorteReceiptRenderer corteRenderer,
        IPrinterSettingsService printerSettings)
    {
      _corteRenderer =
          corteRenderer;

      _printerSettings =
          printerSettings;
    }

    // =========================================================
    // PRINT CORTE
    // =========================================================

    public void PrintCorte(
       CorteRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);

      if (!_printerSettings.IsReceiptPrinterValid())
      {
        throw new InvalidOperationException(
            "A receipt printer has not been configured.");
      }

      using Bitmap receipt =
          _corteRenderer.Render(record);

      using PrintDocument printDocument =
          new();

      printDocument.PrinterSettings.PrinterName =
          _printerSettings.ReceiptPrinterName!;

      printDocument.DefaultPageSettings.Margins =
    new Margins(
        left: 5,
        right: 5,
        top: 5,
        bottom: 5);

      printDocument.OriginAtMargins =
          false;

      PrintBitmap(
          printDocument,
          receipt);
    }

    // =========================================================
    // PRINT BITMAP
    // =========================================================

    private void PrintBitmap(
        PrintDocument printDocument,
        Bitmap receipt)
    {
      _printImage =
          new Bitmap(receipt);

      try
      {
        printDocument.PrintPage +=
            PrintDocument_PrintPage;

        printDocument.Print();
      }
      finally
      {
        printDocument.PrintPage -=
            PrintDocument_PrintPage;

        _printImage?.Dispose();

        _printImage = null;
      }
    }

    // =========================================================
    // PRINT PAGE
    // =========================================================

    private void PrintDocument_PrintPage(
        object sender,
        PrintPageEventArgs e)
    {
      if (_printImage == null ||
          e.Graphics == null)
      {
        e.HasMorePages = false;
        return;
      }

      // =========================================================
      // PRINTABLE AREA
      // =========================================================

      float printableWidth =
          e.MarginBounds.Width;

      // Never enlarge the receipt.
      // Only shrink it if the printer's printable area is narrower.
      float scale =
          Math.Min(
              1F,
              printableWidth / _printImage.Width);

      float printWidth =
          _printImage.Width * scale;

      float printHeight =
          _printImage.Height * scale;

      // Center horizontally inside the printable area.
      float x =
          e.MarginBounds.Left +
          ((e.MarginBounds.Width - printWidth) / 2F);

      float y =
          e.MarginBounds.Top;

      RectangleF destination =
          new(
              x,
              y,
              printWidth,
              printHeight);

      e.Graphics.DrawImage(
          _printImage,
          destination);

      e.HasMorePages = false;
    }

  }
}
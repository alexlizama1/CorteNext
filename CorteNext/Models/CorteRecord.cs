namespace CorteNext.Models
{
  public sealed class CorteRecord
  {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; } = string.Empty;

    // =========================================================
    // CASH
    // =========================================================

    public decimal One { get; set; }

    public decimal Five { get; set; }

    public decimal Ten { get; set; }

    public decimal Twenty { get; set; }

    public decimal Fifty { get; set; }

    public decimal Hundred { get; set; }

    public decimal Quarter { get; set; }

    // =========================================================
    // TOTALS
    // =========================================================

    public decimal TotalCash { get; set; }

    public decimal DriveTip { get; set; }

    public decimal Expenses { get; set; }

    public decimal GrossTotal { get; set; }

    public decimal Fondo { get; set; }

    public decimal NetTotal { get; set; }

    public decimal Sales { get; set; }

    public decimal ShortOver { get; set; }

    // =========================================================
    // STAFF / SHIFT
    // =========================================================

    public string StaffName { get; set; } = string.Empty;

    public string Shift { get; set; } = string.Empty;
  }
}
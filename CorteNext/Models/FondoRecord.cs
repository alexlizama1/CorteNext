namespace CorteNext.Models
{
  public sealed class FondoRecord
  {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; } = string.Empty;

    public decimal One { get; set; }

    public decimal Five { get; set; }

    public decimal Ten { get; set; }

    public decimal Quarter1 { get; set; }

    public decimal Quarter2 { get; set; }

    public decimal Total { get; set; }

    public string StaffName { get; set; } = string.Empty;

    public string Shift { get; set; } = string.Empty;
  }
}
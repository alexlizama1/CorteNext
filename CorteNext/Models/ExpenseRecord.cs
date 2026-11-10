namespace CorteNext.Models
{
  public sealed class ExpenseRecord
  {
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Time { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Company { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Shift { get; set; } = string.Empty;
  }
}
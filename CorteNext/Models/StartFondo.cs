namespace CorteNext.Models
{
  public sealed class StartFondo
  {
    public decimal One { get; set; }

    public decimal Five { get; set; }

    public decimal Ten { get; set; }

    public decimal Quarter { get; set; }

    public string Shift { get; set; } = string.Empty;

    public decimal Total =>
        One +
        Five +
        Ten +
        Quarter;
  }
}
namespace CorteNext.Models
{
  public sealed class DailyTracker
  {
    public DateTime Date { get; set; }

    // =========================================================
    // FONDO
    // =========================================================

    public bool FondoAMCompleted { get; set; }

    public bool FondoDriveCompleted { get; set; }

    public bool FondoPMCompleted { get; set; }

    // =========================================================
    // CORTE
    // =========================================================

    public bool CorteAMCompleted { get; set; }

    public bool CorteAMDriveCompleted { get; set; }

    public bool CortePMDriveCompleted { get; set; }

    public bool CortePMCompleted { get; set; }

    // =========================================================
    // SUMMARY
    // =========================================================

    public bool AllFondoCompleted =>
        FondoAMCompleted &&
        FondoDriveCompleted &&
        FondoPMCompleted;

    public bool AllCorteCompleted =>
        CorteAMCompleted &&
        CorteAMDriveCompleted &&
        CortePMDriveCompleted &&
        CortePMCompleted;

    public bool DayCompleted =>
        AllFondoCompleted &&
        AllCorteCompleted;
  }
}
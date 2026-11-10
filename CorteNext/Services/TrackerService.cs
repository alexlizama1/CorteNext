using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class TrackerService : ITrackerService
  {
    private readonly IFondoService _fondoService;
    private readonly ICorteService _corteService;

    public TrackerService(
        IFondoService fondoService,
        ICorteService corteService)
    {
      _fondoService =
          fondoService;

      _corteService =
          corteService;
    }

    public DailyTracker GetDailyTracker(
        DateTime date)
    {
      date =
          date.Date;

      return new DailyTracker
      {
        Date =
              date,

        // =============================================
        // FONDO
        // =============================================

        FondoAMCompleted =
              _fondoService.FondoExists(
                  date,
                  "am"),

        FondoDriveCompleted =
              _fondoService.FondoExists(
                  date,
                  "drive"),

        FondoPMCompleted =
              _fondoService.FondoExists(
                  date,
                  "pm"),

        // =============================================
        // CORTE
        // =============================================

        CorteAMCompleted =
              _corteService.CorteExists(
                  date,
                  "am"),

        CorteAMDriveCompleted =
              _corteService.CorteExists(
                  date,
                  "amDrive"),

        CortePMDriveCompleted =
              _corteService.CorteExists(
                  date,
                  "pmDrive"),

        CortePMCompleted =
              _corteService.CorteExists(
                  date,
                  "pm")
      };
    }
  }
}
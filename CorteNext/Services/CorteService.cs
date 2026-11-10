using CorteNext.Data.Repositories;
using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class CorteService : ICorteService
  {
    private readonly ICorteRepository _corteRepository;
    private readonly ICorteTrackerRepository _trackerRepository;

    public CorteService(
        ICorteRepository corteRepository,
        ICorteTrackerRepository trackerRepository)
    {
      _corteRepository = corteRepository;
      _trackerRepository = trackerRepository;
    }

    // =========================================================
    // CALCULATE
    // =========================================================

    public CorteRecord Calculate(
        CorteRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);

      // -----------------------------------------------------
      // Total Cash
      // -----------------------------------------------------

      record.TotalCash =
          record.One +
          record.Five +
          record.Ten +
          record.Twenty +
          record.Fifty +
          record.Hundred +
          record.Quarter;

      // -----------------------------------------------------
      // Gross Total
      // -----------------------------------------------------

      record.GrossTotal =
          record.TotalCash +
          record.DriveTip +
          record.Expenses;

      // -----------------------------------------------------
      // Net Total
      // -----------------------------------------------------

      record.NetTotal =
          record.GrossTotal -
          record.Fondo;

      // -----------------------------------------------------
      // Short / Over
      // -----------------------------------------------------

      record.ShortOver =
          record.NetTotal -
          record.Sales;

      return record;
    }

    // =========================================================
    // SAVE
    // =========================================================

    public void SaveCorte(
        CorteRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);

      Validate(record);

      bool alreadyExists =
          CorteExists(
              record.Date,
              record.Shift);

      if (alreadyExists)
      {
        throw new InvalidOperationException(
            "This Corte shift has already been completed today.");
      }

      Calculate(record);

      _corteRepository.Add(record);

      ShiftType shift =
          ConvertDatabaseShift(
              record.Shift);

      _trackerRepository.MarkCompleted(
          record.Date,
          shift);
    }

    private static ShiftType ConvertDatabaseShift(
    string shift)
    {
      return shift switch
      {
        "am" =>
            ShiftType.CorteAM,

        "pm" =>
            ShiftType.CortePM,

        "amDrive" =>
            ShiftType.CorteAMDrive,

        "pmDrive" =>
            ShiftType.CortePMDrive,

        _ =>
            throw new InvalidOperationException(
                $"Unknown Corte shift: {shift}")
      };
    }

    // =========================================================
    // GET CORTE
    // =========================================================

    public CorteRecord? GetCorte(
        DateTime date,
        string shift)
    {
      return _corteRepository.GetByDateAndShift(
          date,
          shift);
    }

    // =========================================================
    // VALIDATION
    // =========================================================

    private static void Validate(
        CorteRecord record)
    {
      if (string.IsNullOrWhiteSpace(
              record.StaffName))
      {
        throw new InvalidOperationException(
            "Staff name is required.");
      }

      if (string.IsNullOrWhiteSpace(
              record.Shift))
      {
        throw new InvalidOperationException(
            "Corte shift is required.");
      }

      if (record.One < 0 ||
          record.Five < 0 ||
          record.Ten < 0 ||
          record.Twenty < 0 ||
          record.Fifty < 0 ||
          record.Hundred < 0 ||
          record.Quarter < 0)
      {
        throw new InvalidOperationException(
            "Cash amounts cannot be negative.");
      }

      if (record.DriveTip < 0)
      {
        throw new InvalidOperationException(
            "Drive Tip cannot be negative.");
      }

      if (record.Expenses < 0)
      {
        throw new InvalidOperationException(
            "Expenses cannot be negative.");
      }

      if (record.Fondo < 0)
      {
        throw new InvalidOperationException(
            "Fondo cannot be negative.");
      }
    }

    public bool CorteExists(
    DateTime date,
    string shift)
    {
      CorteRecord? existingRecord =
          _corteRepository.GetByDateAndShift(
              date,
              shift);

      return existingRecord != null;
    }

    public IReadOnlyList<CorteRecord> GetCortesByDate(
    DateTime date)
    {
      return _corteRepository.GetByDate(
          date);
    }

    public IReadOnlyList<CorteRecord> GetRecentCortes(
        int count)
    {
      return _corteRepository.GetRecent(
          count);
    }

    public IReadOnlyList<DateTime> GetCorteDates(
        DateTime startDate,
        DateTime endDate)
    {
      startDate =
          startDate.Date;

      endDate =
          endDate.Date;

      if (endDate < startDate)
      {
        throw new ArgumentException(
            "The ending date cannot be earlier than the starting date.");
      }

      return _corteRepository.GetReportDates(
          startDate,
          endDate);
    }

  }
}
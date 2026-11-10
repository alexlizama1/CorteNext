using CorteNext.Data.Repositories;
using CorteNext.Models;

namespace CorteNext.Services
{
  public sealed class FondoService : IFondoService
  {
    private readonly IFondoRepository _fondoRepository;
    private readonly IStartFondoRepository _startFondoRepository;
    private readonly IFondoTrackerRepository _trackerRepository;

    public FondoService(
        IFondoRepository fondoRepository,
        IStartFondoRepository startFondoRepository,
        IFondoTrackerRepository trackerRepository)
    {
      _fondoRepository = fondoRepository;
      _startFondoRepository = startFondoRepository;
      _trackerRepository = trackerRepository;
    }

    // =========================================================
    // CHECK IF  FONDO EXISTS
    // =========================================================
    //public bool FondoExists(
    //DateTime date,
    //string shift)
    //{
    //  FondoRecord? record =
    //      _fondoRepository.GetByDateAndShift(
    //          date,
    //          shift);

    //  return record != null;
    //}

    public bool FondoExists(
    DateTime date,
    string shift)
    {
      return _fondoRepository.Exists(
          date.Date,
          shift);
    }

    // =========================================================
    // GET FONDO
    // =========================================================

    public FondoRecord? GetFondo(
        DateTime date,
        string shift)
    {
      return _fondoRepository.GetByDateAndShift(
          date,
          shift);
    }

    // =========================================================
    // GET STARTING FONDO
    // =========================================================

    public StartFondo? GetStartingFondo(
        string shift)
    {
      return _startFondoRepository.GetByShift(
          shift);
    }

    // =========================================================
    // SAVE FONDO
    // =========================================================

    public void SaveFondo(
        FondoRecord record)
    {
      ArgumentNullException.ThrowIfNull(record);

      ValidateRecord(record);

      bool alreadyExists =
          FondoExists(
              record.Date,
              record.Shift);

      if (alreadyExists)
      {
        throw new InvalidOperationException(
            "This Fondo shift has already been completed today.");
      }

      record.Total =
          record.One +
          record.Five +
          record.Ten +
          record.Quarter1 +
          record.Quarter2;

      _fondoRepository.Add(record);

      ShiftType shift =
          ConvertDatabaseShift(
              record.Shift);

      _trackerRepository.MarkCompleted(
          record.Date,
          shift);
    }

    // =========================================================
    // VALIDATION
    // =========================================================

    private static void ValidateRecord(
        FondoRecord record)
    {
      if (string.IsNullOrWhiteSpace(record.StaffName))
      {
        throw new InvalidOperationException(
            "Staff name is required.");
      }

      if (string.IsNullOrWhiteSpace(record.Shift))
      {
        throw new InvalidOperationException(
            "Fondo shift is required.");
      }

      if (record.One < 0 ||
          record.Five < 0 ||
          record.Ten < 0 ||
          record.Quarter1 < 0 ||
          record.Quarter2 < 0)
      {
        throw new InvalidOperationException(
            "Fondo amounts cannot be negative.");
      }
    }

    // =========================================================
    // DATABASE SHIFT -> ENUM
    // =========================================================

    private static ShiftType ConvertDatabaseShift(
        string shift)
    {
      return shift.ToLowerInvariant() switch
      {
        "am" =>
            ShiftType.FondoAM,

        "drive" =>
            ShiftType.FondoDrive,

        "pm" =>
            ShiftType.FondoPM,

        _ =>
            throw new InvalidOperationException(
                $"Unknown Fondo shift: {shift}")
      };
    }
  }
}
using CorteNext.Configuration;
using CorteNext.Data;
using CorteNext.Data.Repositories;
using CorteNext.Forms;
using CorteNext.Models;
using CorteNext.Printing;
using CorteNext.Services;

namespace CorteNext
{
  internal static class Program
  {
    [STAThread]

    static void Main()
    {
      ApplicationConfiguration.Initialize();

      // =====================================================
      // DATABASE LOCATION
      // =====================================================

      DatabasePathProvider.PrepareDatabaseLocation();

      string databasePath =
          DatabasePathProvider.DatabasePath;

      DatabaseSettings databaseSettings =
          new(databasePath);

      IDatabaseConnectionFactory connectionFactory =
          new SQLiteConnectionFactory(
              databaseSettings);

      // =====================================================
      // DATABASE MIGRATION
      // =====================================================

      IDatabaseMigrationService databaseMigrationService =
          new DatabaseMigrationService(
              connectionFactory,
              databasePath,
              DatabasePathProvider.BackupDirectory);

      try
      {
        databaseMigrationService.Migrate();
      }
      catch (Exception ex)
      {
        MessageBox.Show(
            "CorteNext could not safely prepare the database.\r\n\r\n" +
            "The application will close to prevent data loss.\r\n\r\n" +
            ex.Message,
            "Database Migration Error",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);

        return;
      }

      // =====================================================
      // REPOSITORIES
      // =====================================================

      IFondoRepository fondoRepository =
          new FondoRepository(
              connectionFactory);

      IStartFondoRepository startFondoRepository =
          new StartFondoRepository(
              connectionFactory);

      IFondoTrackerRepository fondoTrackerRepository =
          new FondoTrackerRepository(
              connectionFactory);

      ICorteRepository corteRepository =
          new CorteRepository(
              connectionFactory);

      ICorteTrackerRepository corteTrackerRepository =
          new CorteTrackerRepository(
              connectionFactory);

      IExpenseRepository expenseRepository =
          new ExpenseRepository(
              connectionFactory);

      IUserRepository userRepository =
          new UserRepository(
              connectionFactory);

      IPrinterRepository printerRepository =
          new PrinterRepository(
              connectionFactory);

      // =====================================================
      // CORE SERVICES
      // =====================================================

      IFondoService fondoService =
          new FondoService(
              fondoRepository,
              startFondoRepository,
              fondoTrackerRepository);

      ICorteService corteService =
          new CorteService(
              corteRepository,
              corteTrackerRepository);

      IExpenseService expenseService =
          new ExpenseService(
              expenseRepository);

      IAuthenticationService authenticationService =
          new AuthenticationService(
              userRepository);

      IUserService userService =
          new UserService(
              userRepository);

      // =====================================================
      // TRACKER SERVICE
      // =====================================================

      ITrackerService trackerService =
          new TrackerService(
              fondoService,
              corteService);

      // =====================================================
      // PRINTER SETTINGS
      // =====================================================

      IPrinterSettingsService printerSettingsService =
          new PrinterSettingsService(
              printerRepository);

      // =====================================================
      // RECEIPT RENDERER
      //
      // IMPORTANT:
      // fondoService must already exist because the renderer
      // now retrieves the matching Fondo denomination detail.
      // =====================================================

      ICorteReceiptRenderer corteReceiptRenderer =
          new CorteReceiptRenderer(
              fondoService);

      // =====================================================
      // RECEIPT PRINT SERVICE
      // =====================================================

      IReceiptPrintService receiptPrintService =
          new ReceiptPrintService(
              corteReceiptRenderer,
              printerSettingsService);

      // =====================================================
      // USER SESSION
      // =====================================================

      UserSession userSession =
          new();

      // =====================================================
      // Update Service
      // =====================================================

      HttpClient updateHttpClient = new()
      {
        Timeout = TimeSpan.FromSeconds(10)
      };

      IUpdateService updateService =
          new UpdateService(
              updateHttpClient,
              "https://YOUR-SERVER/version.json");


      // =====================================================
      // MAIN FORM
      // =====================================================

      MainForm mainForm =
          new(
              fondoService,
              corteService,
              expenseService,
              authenticationService,
              userService,
              printerSettingsService,
              receiptPrintService,
              trackerService,
              updateService,
              userSession);

      // =====================================================
      // START APPLICATION
      // =====================================================

      Application.Run(
          mainForm);
    }
  }
}
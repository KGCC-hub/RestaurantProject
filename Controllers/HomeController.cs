using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestaurantProject.Models;
using System.Diagnostics;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostReservation(Reserva reserva)
        {
            var connectionString = _configuration.GetConnectionString("ChainTrust");
            const string query = @"INSERT INTO Reserva (Nombre, Dia, Hora, Comensales) VALUES (@NameCostumer, @Date, @Time, @NumberOfPeople)";
            try
            {
                //var stopwatch = Stopwatch.StartNew(); // INICIA MEDICIÓN
                using var conn = new SqlConnection(connectionString);
                using var cmd = new SqlCommand(query, conn)
                {
                    CommandTimeout = 300
                };
                cmd.Parameters.AddWithValue("@NameCostumer", reserva.NameCostumer);
                cmd.Parameters.AddWithValue("@Date", reserva.Date);
                cmd.Parameters.AddWithValue("@Time", reserva.Time);
                cmd.Parameters.AddWithValue("@NumberOfPeople", reserva.NumberOfPeople);
                conn.Open();
                cmd.ExecuteNonQuery();
                //stopwatch.Stop(); // TERMINA MEDICION

                Console.WriteLine($"Tiempo de inserción: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(
                $"Lo sentimos, hubo un error al intentar registar la reserva. Intente de nuevo.: {ex.Message}", ex);
            }
            return View("Gracias");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

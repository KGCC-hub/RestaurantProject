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

        // FORMULARIO
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GUARDAR RESERVA
        [HttpPost]
        public IActionResult PostReservation(Reserva reserva)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            const string query = @"INSERT INTO Reserva (Nombre, Dia, Hora, Comensales) 
                                   VALUES (@Nombre, @Dia, @Hora, @Comensales)";

            try
            {
                using var conn = new SqlConnection(connectionString);
                using var cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nombre", reserva.Nombre);
                cmd.Parameters.AddWithValue("@Dia", reserva.Dia);
                cmd.Parameters.AddWithValue("@Hora", reserva.Hora);
                cmd.Parameters.AddWithValue("@Comensales", reserva.Comensales);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new ApplicationException(
                    $"Error al registrar la reserva: {ex.Message}", ex);
            }

            return View("Gracias");
        }

        // LISTAR RESERVAS
        public IActionResult Listado()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            var reservas = new List<Reserva>();

            const string query = "SELECT Id, Nombre, Dia, Hora, Comensales FROM Reserva";

            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(query, conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reservas.Add(new Reserva
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Dia = reader.GetDateTime(2),
                    Hora = reader.GetTimeSpan(3),
                    Comensales = reader.GetInt32(4)
                });
            }

            return View(reservas);
        }

        // ELIMINAR MULTIPLE
        [HttpPost]
        public IActionResult EliminarSeleccionadas(List<int> ids)
        {
            if (ids == null || !ids.Any())
                return RedirectToAction("Listado");

            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(connectionString);
            conn.Open();

            foreach (var id in ids)
            {
                using var cmd = new SqlCommand("DELETE FROM Reserva WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Listado");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
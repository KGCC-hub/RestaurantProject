using System;

namespace RestaurantProject.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public DateTime Dia { get; set; }

        public TimeSpan Hora { get; set; }

        public int Comensales { get; set; }
    }
}


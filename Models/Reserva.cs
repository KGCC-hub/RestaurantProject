namespace RestaurantProject.Models
{
    public class Reserva
    {
        public string ?NameCostumer { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public int NumberOfPeople { get; set; }
    }
}

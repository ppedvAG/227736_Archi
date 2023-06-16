namespace ppedv.KurvenkönigsKarren.API.Model
{
    public class CarDTO
    {
        public int Id { get; set; }
        public int KW { get; set; }
        public string Model { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
    }
}

namespace ppedv.KurvenkönigsKarren.Model
{
    public class Car : Entity
    {
        public string Model { get; set; } = string.Empty;
        public int KW { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Seats { get; set; }
        public Transmission Transmission { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}
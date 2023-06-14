using System.ComponentModel;

namespace ppedv.KurvenkönigsKarren.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }

    public class Manufacturer : Entity
    {
        public required string Name { get; set; } = string.Empty;
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }

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

    public class Rent : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public string StartLocation { get; set; } = string.Empty;
        public string? EndLocation { get; set; } = null;

        public virtual Car? Car { get; set; }
        public virtual Customer? Driver { get; set; }
        public virtual Customer? Payer { get; set; }
    }

    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = null;

        public virtual ICollection<Rent> RentsAsDriver { get; set; } = new HashSet<Rent>();
        public virtual ICollection<Rent> RentsAsPayer { get; set; } = new HashSet<Rent>();
    }

    public enum Transmission
    {
        Automatic,
        Manual,
        Semi
    }
}
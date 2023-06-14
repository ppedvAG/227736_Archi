namespace ppedv.KurvenkönigsKarren.Model
{
    public class Customer : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; } = null;

        public virtual ICollection<Rent> RentsAsDriver { get; set; } = new HashSet<Rent>();
        public virtual ICollection<Rent> RentsAsPayer { get; set; } = new HashSet<Rent>();
    }
}
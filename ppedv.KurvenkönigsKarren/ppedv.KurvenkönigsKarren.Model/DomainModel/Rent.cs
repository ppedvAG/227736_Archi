namespace ppedv.KurvenkönigsKarren.Model.DomainModel
{
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
}
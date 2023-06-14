﻿namespace ppedv.KurvenkönigsKarren.Model
{
    public class Manufacturer : Entity
    {
        public required string Name { get; set; } = string.Empty;
        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}
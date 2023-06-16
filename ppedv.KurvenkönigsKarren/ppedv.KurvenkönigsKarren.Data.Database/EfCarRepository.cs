using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Data.Database
{
    public class EfCarRepository : EfRepository<Car>, ICarRepository
    {
        public EfCarRepository(EfContext context) : base(context)
        {
        }

        public IEnumerable<Car> GetAllSuperCars()
        {
            return  context.Cars.ToList(); //todo Special Query
        }
    }
}

using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Model.Contracts
{
    public interface ICarRepository : IRepository<Car>
    {
        IEnumerable<Car> GetAllSuperCars();
    }


}

using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Logic.Core
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        public CarService(IRepository repo)
        {
            this.repo = repo;
        }

        public bool IsCarAvailable(Car car, DateTime day)
        {
            return !repo.Query<Rent>().Any(x => x.Car.Id == car.Id && x.StartDate.Date <= day.Date
                                                                    && (x.EndDate == null || x.EndDate.Value.Date >= day.Date));
        }
    }
}
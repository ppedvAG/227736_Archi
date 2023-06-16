using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Logic.Core
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork unitOfWokr;

        public CarService(IUnitOfWork unitOfWokr)
        {
            this.unitOfWokr = unitOfWokr;
        }

        public bool IsCarAvailable(Car car, DateTime day)
        {
            return !unitOfWokr.RentRepository.Query().Any(x => x.Car.Id == car.Id && x.StartDate.Date <= day.Date
                                                                    && (x.EndDate == null || x.EndDate.Value.Date >= day.Date));
        }
    }
}
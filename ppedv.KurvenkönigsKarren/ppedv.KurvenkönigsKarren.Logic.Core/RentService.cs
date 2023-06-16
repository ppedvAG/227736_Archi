using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Logic.Core
{
    public class RentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICarService carService;

        public RentService(IUnitOfWork unitOfWork, ICarService carService)
        {
            this.unitOfWork = unitOfWork;
            this.carService = carService;
        }

        public void CreateNewRentForCar(Car car, Customer driver, DateTime startDate, string startLocation)
        {
            if (!carService.IsCarAvailable(car, startDate))
            {
                throw new InvalidOperationException("Das Auto ist nicht verfügbar");
            }

            if (startDate < DateTime.Now)
            {
                throw new ArgumentException("Startdatum kann nicht in der vergangenheit liegen");
            }

            var rent = new Rent()
            {
                OrderDate = DateTime.Now,
                StartDate = startDate,
                StartLocation = startLocation,
                Driver = driver,
                Car = car,  
            };

            unitOfWork.RentRepository.Add(rent);
            unitOfWork.SaveAll();
        }
    }
}

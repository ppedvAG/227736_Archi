using Bogus;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Logic.Core
{
    public class DemoService
    {
        private readonly IUnitOfWork unitOfWork;

        public DemoService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

            string lang = "de";
            int seed = 4;

            CustomerFaker = new Faker<Customer>(lang)
                   .UseSeed(seed)
                   .RuleFor(x => x.Name, x => x.Name.FullName())
                   .RuleFor(x => x.Address, x => x.Address.FullAddress())
                   .RuleFor(x => x.BirthDate, x => x.Date.Past(yearsToGoBack: 18));

            var customers = CustomerFaker.Generate(100);

            ManufaturerFaker = new Faker<Manufacturer>(lang)
                   .UseSeed(seed)
                   .RuleFor(x => x.Name, x => x.Vehicle.Manufacturer());

            var manus = ManufaturerFaker.Generate(100);

            RentFaker = new Faker<Rent>(lang)
                  .UseSeed(seed)
                  .RuleFor(x => x.OrderDate, x => x.Date.Recent())
                  .RuleFor(x => x.StartDate, x => x.Date.Recent())
                  .RuleFor(x => x.EndDate, x => x.Date.Recent())
                  .RuleFor(x => x.StartLocation, x => x.Address.City())
                  .RuleFor(x => x.EndLocation, x => x.Address.City())
                  .RuleFor(x => x.Driver, x => x.PickRandom(customers))
                  .RuleFor(x => x.Payer, x => x.PickRandom(customers));

            var rents = RentFaker.Generate(100);

            CarFaker = new Faker<Car>(lang)
               .UseSeed(seed)
               .RuleFor(x => x.Model, x => x.Vehicle.Model())
               .RuleFor(x => x.KW, x => x.Random.Int(50, 500))
               .RuleFor(x => x.Color, x => x.Commerce.Color())
               .RuleFor(x => x.Seats, x => x.Random.Int(2, 8))
               .RuleFor(x => x.Transmission, x => x.Random.Enum<Transmission>())
               .RuleFor(x => x.Manufacturer, x => x.PickRandom(manus))
               .RuleFor(x => x.Rents, x => x.PickRandom(rents, 4).ToList());

        }

        public void CrateDemoRents(int amount = 100)
        {
            var cars = CarFaker.Generate(amount);
            foreach (var car in cars)
            {
               unitOfWork.CarRepository.Add(car);
            }
            unitOfWork.SaveAll();
        }

        public Faker<Car> CarFaker { get; }
        public Faker<Manufacturer> ManufaturerFaker { get; }
        public Faker<Rent> RentFaker { get; }
        public Faker<Customer> CustomerFaker { get; }

    }
}

using FluentAssertions;
using Moq;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Logic.Core.Tests
{
    public class RentServiceTests
    {
        [Fact]
        public void CreateNewRentForCar_can_create()
        {
            var repoMock = new Mock<IRepository<Rent>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x=>x.RentRepository).Returns(repoMock.Object);
            
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(x => x.IsCarAvailable(It.IsAny<Car>(), It.IsAny<DateTime>())).Returns(true);

            var rentService = new RentService(uowMock.Object, carServiceMock.Object);
            var car = new Car() { Color = "blau" };
            var customer = new Customer() { Name = "Peter" };

            rentService.CreateNewRentForCar(car, customer, DateTime.Now.AddDays(1), "Hier");

            repoMock.Verify(x => x.Add(It.IsAny<Rent>()), Times.Once);
            uowMock.Verify(x => x.SaveAll(), Times.Once);
        }

        [Fact]
        public void CreateNewRentForCar_car_not_available_throws_InvalidOpException()
        {
            var repoMock = new Mock<IRepository<Rent>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.RentRepository).Returns(repoMock.Object);
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(x => x.IsCarAvailable(It.IsAny<Car>(), It.IsAny<DateTime>())).Returns(false);

            var rentService = new RentService(uowMock.Object, carServiceMock.Object);
            var car = new Car() { Color = "blau" };
            var customer = new Customer() { Name = "Peter" };

            Action act = () => rentService.CreateNewRentForCar(car, customer, DateTime.Now.AddDays(1), "Hier");

            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void CreateNewRentForCar_startdate_in_the_past_throws_ArgumentException()
        {
            var repoMock = new Mock<IRepository<Rent>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.RentRepository).Returns(repoMock.Object);
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(x => x.IsCarAvailable(It.IsAny<Car>(), It.IsAny<DateTime>())).Returns(true);

            var rentService = new RentService(uowMock.Object, carServiceMock.Object);
            var car = new Car() { Color = "blau" };
            var customer = new Customer() { Name = "Peter" };

            Action act = () => rentService.CreateNewRentForCar(car, customer, DateTime.Now.AddDays(-1), "Hier");

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void CreateNewRentForCar_startdate_in_the_throws_ArgumentException()
        {
            var repoMock = new Mock<IRepository<Rent>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.RentRepository).Returns(repoMock.Object);
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(x => x.IsCarAvailable(It.IsAny<Car>(), It.IsAny<DateTime>())).Returns(true);

            var rentService = new RentService(uowMock.Object, carServiceMock.Object);
            var car = new Car() { Color = "blau" };
            var customer = new Customer() { Name = "Peter" };

            Action act = () => rentService.CreateNewRentForCar(car, customer, DateTime.Now, "Hier");

            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(0, false)]
        [InlineData(-1, true)]
        public void CreateNewRentForCar_startdate_tests(int addDays, bool shouldThrow)
        {
            var repoMock = new Mock<IRepository<Rent>>();
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.RentRepository).Returns(repoMock.Object);
            var carServiceMock = new Mock<ICarService>();
            carServiceMock.Setup(x => x.IsCarAvailable(It.IsAny<Car>(), It.IsAny<DateTime>())).Returns(true);

            var rentService = new RentService(uowMock.Object, carServiceMock.Object);
            var car = new Car() { Color = "blau" };
            var customer = new Customer() { Name = "Peter" };

            Action act = () => rentService.CreateNewRentForCar(car, customer, DateTime.Now.AddDays(addDays), "Hier");

            if (shouldThrow)
                act.Should().Throw<ArgumentException>();
        }
    }
}
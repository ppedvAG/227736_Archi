using ppedv.KurvenkönigsKarren.Data.Database;
using ppedv.KurvenkönigsKarren.Logic.Core;
using ppedv.KurvenkönigsKarren.Model.DomainModel;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("*** KurvenkönigsKarren v0.1 DELUXE EDITION ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";

var repo = new EfRepository(conString);
var carService = new CarService(repo);

var cars = repo.GetAll<Car>();
foreach (var car in cars)
{
    Console.WriteLine($"{car.Manufacturer?.Name} {car.Model} {(carService.IsCarAvailable(car, DateTime.Now) ? "✔️" : "❌")}");
	foreach (var r in car.Rents)
	{
        Console.WriteLine($"\t{r.StartDate:g} - {r.EndDate:g} {r.Driver?.Name}");
    }
}


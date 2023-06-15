using Autofac;
using ppedv.KurvenkönigsKarren.Data.Database;
using ppedv.KurvenkönigsKarren.Logic.Core;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;
using System.Reflection;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine("*** KurvenkönigsKarren v0.1 DELUXE EDITION ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";

//Di per Reflection
//var path = @"C:\Users\Fred\source\repos\ppedvAG\227736_Archi\ppedv.KurvenkönigsKarren\ppedv.KurvenkönigsKarren.Data.Database\bin\Debug\net7.0\ppedv.KurvenkönigsKarren.Data.Database.dll";
//var ass = Assembly.LoadFrom(path);
//var typeMitRepo = ass.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IRepository))).FirstOrDefault();
//var repo = Activator.CreateInstance(typeMitRepo, conString) as IRepository;

//Di per AutoFac
var builder = new ContainerBuilder();
//builder.RegisterType<EfRepository>().As<IRepository>();
builder.RegisterType<EfRepository>().AsImplementedInterfaces().WithParameter("conString", conString);
var container = builder.Build();

var repo = container.Resolve<IRepository>();

//Dependency Injection per code
//IRepository repo = new EfRepository(conString);


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


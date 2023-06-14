using HalloDekorator;

Console.WriteLine("Hello, World!");


var myPizza = new Salami(new Pizza());

Console.WriteLine($"{myPizza.Name} {myPizza.Preis}");

var myBrot = new Käse(new Käse(new Salami(new Brot())));

Console.WriteLine($"{myBrot.Name} {myBrot.Preis}");
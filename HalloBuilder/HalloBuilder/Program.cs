// See https://aka.ms/new-console-template for more information
using HalloBuilder;

Console.WriteLine("Hello, World!");

var schrank1 = new Schrank.Builder()
                          .SetOberfläche(Oberfläche.Gewachst)
                          .SetBöden(5)
                          .SetTüren(4)
                          .Build();

var schrank2 = new Schrank.Builder()
                          .SetOberfläche(Oberfläche.Lackiert)
                          .SetFarbe("Blau")
                          .SetBöden(5)
                          .SetTüren(4)
                          .Build();


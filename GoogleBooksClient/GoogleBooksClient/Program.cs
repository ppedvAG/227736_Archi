// See https://aka.ms/new-console-template for more information
using GoogleBooksClient;

Console.WriteLine("Hello, World!");

var url = "https://www.googleapis.com/books/v1/volumes?q=softwaretests";

var httpClient = new HttpClient();

var json = httpClient.GetStringAsync(url).Result;

//Console.WriteLine(json);


BooksResult result = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);

foreach (var item in result.items)
{
    Console.WriteLine($"{item.volumeInfo.title}");
}
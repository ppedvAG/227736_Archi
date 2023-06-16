using ppedv.KurvenkönigsKarren.Data.Database;
using ppedv.KurvenkönigsKarren.Model.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(x => new EfRepository(conString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

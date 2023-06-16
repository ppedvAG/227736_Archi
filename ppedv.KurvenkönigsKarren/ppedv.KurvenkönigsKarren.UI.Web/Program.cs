using ppedv.KurvenkönigsKarren.Model.Contracts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

 string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork>(x => new ppedv.KurvenkönigsKarren.Data.Database.EfUnitOfWork(conString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

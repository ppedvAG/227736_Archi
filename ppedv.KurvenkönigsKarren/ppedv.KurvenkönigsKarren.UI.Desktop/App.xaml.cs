using Microsoft.Extensions.DependencyInjection;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.UI.Desktop.ViewModels;
using System;
using System.Windows;

namespace ppedv.KurvenkönigsKarren.UI.Desktop
{
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            string conString = "Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;";

            services.AddSingleton<IUnitOfWork>(x => new Data.Database.EfUnitOfWork(conString));
            services.AddSingleton<CarsViewModel>();

            return services.BuildServiceProvider();
        }
    }
}

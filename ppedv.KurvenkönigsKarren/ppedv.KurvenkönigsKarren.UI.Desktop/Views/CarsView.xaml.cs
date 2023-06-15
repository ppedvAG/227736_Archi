using Microsoft.Extensions.DependencyInjection;
using ppedv.KurvenkönigsKarren.UI.Desktop.ViewModels;
using System.Windows.Controls;

namespace ppedv.KurvenkönigsKarren.UI.Desktop.Views
{
    /// <summary>
    /// Interaction logic for CarsView.xaml
    /// </summary>
    public partial class CarsView : UserControl
    {
        public CarsView()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<CarsViewModel>();
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ppedv.KurvenkönigsKarren.UI.Desktop.ViewModels
{
    internal class CarsViewModel : ObservableObject
    {
        IRepository repo;
        private Car selectedCar;

        public CarsViewModel(IRepository repo)
        {
            this.repo = repo;

            CarList = new ObservableCollection<Car>(repo.GetAll<Car>());
            //SaveCommand = new SaveCommand(repo);
            NewSaveCommand = new RelayCommand(repo.SaveAll);
            NewCarCommand = new RelayCommand(UserWantsToCreateNewCar);
        }

        private void UserWantsToCreateNewCar()
        {
            var car = new Car() { Color = "NEU", Model = "NEU NEU" };
            repo.Add(car);
            CarList.Add(car);
            SelectedCar = car;
        }

        public ICommand NewSaveCommand { get; set; }
        public ICommand NewCarCommand { get; set; }

        public ObservableCollection<Car> CarList { get; set; }
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                selectedCar = value;
                OnPropertyChanged("SelectedCar");
                OnPropertyChanged(nameof(PS));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCar"));
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PS"));
            }
        }

        public int PS
        {
            get
            {
                if (SelectedCar == null)
                    return -1;
                return SelectedCar.KW * 5;
            }
        }

        public SaveCommand SaveCommand { get; set; }

    }

    class SaveCommand : ICommand
    {
        private readonly IRepository repo;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public SaveCommand(IRepository repo)
        {
            this.repo = repo;
        }

        public void Execute(object? parameter)
        {
            repo.SaveAll();
        }
    }
}

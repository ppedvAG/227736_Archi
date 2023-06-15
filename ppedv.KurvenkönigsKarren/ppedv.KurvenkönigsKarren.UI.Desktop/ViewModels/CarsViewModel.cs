using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ppedv.KurvenkönigsKarren.UI.Desktop.ViewModels
{
    internal class CarsViewModel:INotifyPropertyChanged
    {
        IRepository repo;
        private Car selectedCar;

        public event PropertyChangedEventHandler? PropertyChanged;

        public CarsViewModel(IRepository repo)
        {
            this.repo = repo;

            CarList = new List<Car>(repo.GetAll<Car>());
            SaveCommand = new SaveCommand(repo);
        }

        public List<Car> CarList { get; set; }
        public Car SelectedCar
        {
            get => selectedCar; 
            set
            {
                selectedCar = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedCar"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PS"));
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

        //todo kill
        public CarsViewModel() : this(new Data.Database.EfRepository("Server=(localdb)\\mssqllocaldb;Database=KurvenKönig_Test;Trusted_Connection=true;"))
        {

        }
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

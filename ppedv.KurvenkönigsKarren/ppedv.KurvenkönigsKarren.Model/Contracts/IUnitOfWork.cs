using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Model.Contracts
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Rent> RentRepository { get; }

        void SaveAll();
    }


}

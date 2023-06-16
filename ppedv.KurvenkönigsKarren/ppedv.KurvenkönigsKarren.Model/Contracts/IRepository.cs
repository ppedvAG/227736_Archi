using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Model.Contracts
{
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get;  }
        IRepository<Customer> CustomerRepository { get;  }
        IRepository<Rent> RentRepository { get;  }

        void SaveAll();
    }

    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Query();
        T? GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

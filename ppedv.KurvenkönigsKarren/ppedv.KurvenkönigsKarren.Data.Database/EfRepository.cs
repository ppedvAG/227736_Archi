using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Data.Database
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private EfContext context;
        public EfUnitOfWork(string conString)
        {
            context = new EfContext(conString);
        }

        public IRepository<Car> CarRepository => new EfRepository<Car>(context);

        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(context);

        public IRepository<Rent> RentRepository => new EfRepository<Rent>(context);

        public void SaveAll()
        {
            context.SaveChanges();
        }
    }

    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        public EfRepository(EfContext context)
        {
            this.context = context;
        }
        protected EfContext context;

        public void Add(T entity)
        {
            context.Add(entity);
        }
        public void Delete(T entity)
        {
            context.Remove(entity);
        }
        public IQueryable<T> Query()
        {
            return context.Set<T>();
        }
        public T? GetById(int id)
        {
            return context.Find<T>(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}

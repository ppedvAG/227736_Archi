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

        public ICarRepository CarRepository => new EfCarRepository(context);

        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(context);

        public IRepository<Rent> RentRepository => new EfRepository<Rent>(context);

        public void SaveAll()
        {
            context.SaveChanges();
        }
    }
}

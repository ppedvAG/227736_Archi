using ppedv.KurvenkönigsKarren.Model.Contracts;
using ppedv.KurvenkönigsKarren.Model.DomainModel;

namespace ppedv.KurvenkönigsKarren.Data.Database
{
    public class EfRepository : IRepository
    {
        public EfRepository(string conString)
        {
            context = new EfContext(conString);
        }
        readonly EfContext context;
        public void Add<T>(T entity) where T : Entity
        {
            context.Add(entity);
        }
        public void Delete<T>(T entity) where T : Entity
        {
            context.Remove<T>(entity);
        }
        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }
        public T? GetById<T>(int id) where T : Entity
        {
            return context.Find<T>(id);
        }
        public void SaveAll()
        {
            context.SaveChanges();
        }
        public void Update<T>(T entity) where T : Entity
        {
            context.Update(entity);
        }
    }
}

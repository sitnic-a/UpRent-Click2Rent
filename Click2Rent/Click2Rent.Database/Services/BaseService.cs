using Click2Rent.Domain;

#pragma warning disable CS8604
#pragma warning disable CS8603

namespace Click2Rent.Database.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseClass
    {
        private readonly Click2RentContext _context;

        public BaseService(Click2RentContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            var newRecord = _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return newRecord.Entity;
        }

        public bool Delete(int id)
        {
            var dbRecord = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            _context.Set<T>().Remove(dbRecord);
            _context.SaveChanges();
            return true;
        }

        public List<T> GetAll()
        {
            var list = _context.Set<T>().ToList();
            return list;
        }

        public T GetById(int id)
        {
            var dbRecord = _context.Set<T>().FirstOrDefault(e => e.Id == id);
            return dbRecord;
        }

        public T Update(int id, T Entity)
        {
            Entity.Id = id;
            _context.Update(Entity);
            _context.SaveChanges();
            return Entity;
        }
    }
}

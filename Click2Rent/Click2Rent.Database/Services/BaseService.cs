using Click2Rent.Domain;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8604
#pragma warning disable CS8603

namespace Click2Rent.Database.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseClass
    {
        private readonly Click2RentDbFactory _contextFactory;

        public BaseService(Click2RentDbFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public T Add(T entity)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var newRecord = _context.Set<T>().Add(entity);
                _context.SaveChanges();
                return newRecord.Entity;
            }
        }

        public bool Delete(int id)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var dbRecord = _context.Set<T>().FirstOrDefault(e => e.Id == id);
                _context.Set<T>().Remove(dbRecord);
                _context.SaveChanges();
                return true;
            }
        }

        public List<T> GetAll()
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var list = _context.Set<T>().ToList();
                return list;
            }
        }

        public T GetById(int id)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var dbRecord = _context.Set<T>().FirstOrDefault(e => e.Id == id);
                return dbRecord;
            }
        }

        public T Update(int id, T Entity)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                Entity.Id = id;
                _context.Update(Entity);
                _context.SaveChanges();
                return Entity;
            }
        }
    }
}

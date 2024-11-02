using Click2Rent.Domain;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS8604

namespace Click2Rent.Database.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseClass
    {
        private readonly Click2RentDbFactory _contextFactory;

        public BaseService(Click2RentDbFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Add(T entity)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var newRecord = await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return newRecord.Entity;
            }
        }

        public async Task<T> Delete(int id)
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var dbRecord = await _context.Set<T>().FindAsync(id);
                var removed = _context.Set<T>().Remove(dbRecord);
                await _context.SaveChangesAsync();
                return removed.Entity;
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (Click2RentContext _context = _contextFactory.CreateDbContext(args: []))
            {
                var list = await _context.Set<T>().ToListAsync();
                return list;
            }
        }
    }
}

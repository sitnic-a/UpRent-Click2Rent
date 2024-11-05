namespace Click2Rent.Database.Services
{
    public interface IBaseService<T>
    {
        List<T> GetAll();
        T GetById(int id );
        T Add(T Entity);
        bool Delete(int id);
        T Update(int id, T Entity);
    }
}

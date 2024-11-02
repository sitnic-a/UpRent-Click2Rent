namespace Click2Rent.Database.Services
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Add(T Entity);
        Task<T> Delete(int id);
    }
}

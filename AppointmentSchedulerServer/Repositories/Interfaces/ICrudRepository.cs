namespace AppointmentSchedulerServer.Repositories
{
    public interface ICrudRepository<T, ID>
    {
        public Task<int> Save(T entity);
        public Task<int> SaveAll(IEnumerable<T> entities);
        public Task<T> FindById(ID id);
        public Task<Boolean> ExistsById(ID id);
        public Task<IEnumerable<T>> FindAll();
        public Task<IEnumerable<T>> FindAllById(IEnumerable<ID> Ids);
        public Task DeleteById(ID id);
        public Task Delete(T entity);
        public Task DeleteAll(IEnumerable<T> entities);
    }
}

using Core.Abstractions;

namespace DataAccess.Repositories.Base
{
    public interface IRepository<T> where T : IEntity
    {
        public T Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T Get(Predicate<T> filter);
        public List<T> GetAll(Predicate<T> filter);
    }
}
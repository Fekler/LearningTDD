using LearningTDD.Domain.Models._Base;

namespace LearningTDD.Domain.Interfaces._Base
{
    public interface IBaseOperations<T> where T : Entity
    {
        Task<T> Get(int id);
        Task<int> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Update(T entity);
    }
}

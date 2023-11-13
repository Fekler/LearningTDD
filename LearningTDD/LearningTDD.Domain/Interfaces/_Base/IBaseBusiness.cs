using LearningTDD.Domain.Models._Base;

namespace LearningTDD.Domain.Interfaces._Base
{
    public interface IBaseBusiness<T> where T : Entity
    {

        Task<T> Get(int id);
        Task<int> Add(object entity);
        Task<bool> Delete(int id);
        Task<bool> Update(object entity);

    }
}

using LearningTDD.Domain.DTO;
using LearningTDD.Domain.Models._Base;

namespace LearningTDD.Domain.Interfaces._Base
{
    public interface IBaseBusiness<T> where T : Entity
    {

        Task<ApiResponse<T>> Get(int id);
        Task<ApiResponse<int>> Add(object entity);
        Task<ApiResponse<bool>> Delete(int id);
        Task<ApiResponse<bool>> Update(object entity);

    }
}

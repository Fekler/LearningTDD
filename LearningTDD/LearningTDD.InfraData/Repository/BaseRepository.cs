using LearningTDD.Domain.Interfaces._Base;
using LearningTDD.Domain.Models._Base;
using System.Data;

namespace LearningTDD.InfraData.Repository
{
    public abstract class BaseRepository<T> : IBaseOperations<T> where T : Entity 
    {
        protected readonly IDbConnection _connection;

        protected BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Task<int> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

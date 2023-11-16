using LearningTDD.Domain.Interfaces._Base;
using LearningTDD.Domain.Models;
using LearningTDD.Domain.Models._Base;
using System.Data;
using static Dapper.SqlMapper;

namespace LearningTDD.InfraData.Repository
{
    public abstract class BaseRepository<T> : IBaseOperations<T> where T : Entity 
    {
        private List<T> _entities;

        public BaseRepository()
        {
            _entities = new();
        }

        public async Task<int> Add(T entity)
        {
            if (_entities.Count == 0)
            {
                entity.Id = 1;
            }
            else
            {
                var lastStudent = _entities.Last();
                entity.Id = lastStudent.Id + 1;
            }

            _entities.Add(entity);

            return entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = _entities.FirstOrDefault(s => s.Id == id);
            var result = entity is not null;
            if (result)
                _entities.Remove(entity);
            return result;
        }

        public async Task<T> Get(int id)
        {
            var result = _entities.FirstOrDefault(s => s.Id == id);
            return result;
        }

        public async Task<bool> Update(T entity)
        {
            var listedEntity = _entities.FirstOrDefault(s => s.Id == entity.Id);
            var result = entity is not null;
            if (result)
            {
                _entities.Remove(listedEntity);
                Add(entity);
            }
            return result;
        }
    }
}

using LearningTDD.Domain.Interfaces._Base;
using LearningTDD.Domain.Models._Base;
using Microsoft.EntityFrameworkCore;

namespace LearningTDD.InfraData.Repository
{
    public abstract class BaseRepository<T> : IBaseOperations<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<int> Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id) => await _dbSet.FindAsync(id);

        public async Task<bool> Update(T entity)
        {
            var existingEntity = await _dbSet.FindAsync(entity.Id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

//using LearningTDD.Domain.Interfaces._Base;
//using LearningTDD.Domain.Models._Base;

//namespace LearningTDD.InfraData.Repository
//{
//    public abstract class BaseRepository<T> : IBaseOperations<T> where T : Entity
//    {
//        private List<T> _entities;

//        public BaseRepository()
//        {
//            _entities = new();
//        }

//        public async Task<int> Add(T entity)
//        {
//            if (_entities.Count == 0)
//            {
//                entity.Id = 1;
//            }
//            else
//            {
//                var lastStudent = _entities.Last();
//                entity.Id = lastStudent.Id + 1;
//            }

//            _entities.Add(entity);

//            return entity.Id;
//        }

//        public async Task<bool> Delete(int id)
//        {
//            var entity = _entities.FirstOrDefault(e => e.Id == id);
//            if (entity is null)
//                return false;

//            _entities.Remove(entity);
//            return true;
//        }

//        public async Task<T> Get(int id)
//        {
//            var result = _entities.FirstOrDefault(e => e.Id == id);
//            return result;
//        }

//        public async Task<bool> Update(T entity)
//        {
//            var listedEntity = _entities.FirstOrDefault(e => e.Id == entity.Id);
//            if (listedEntity is null)
//                return false;
//            _entities.Remove(listedEntity);
//            _ = await Add(entity);
//            return true;
//        }
//    }
//}

using LearningTDD.API.Interfaces;
using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;

namespace LearningTDD.API.Business
{
    public class StudentBusiness : IStudent
    {
        private readonly IStudentRepository _repository;

        public StudentBusiness(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Add(object entity)
        {
            var result = await _repository.Add((Student)entity);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var exists = await Get(id);
            if (exists is null) 
            {
                return false;
            }
            return true;
        }

        public Task<Student> Get(int id)
        {
            var exists = _repository.Get(id);
            return exists;
        }

        public async Task<bool> Update(object entity)
        {
            var update = await _repository.Update((Student)entity);
            return update;
        }
    }
}

using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;

namespace LearningTDD.API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        public Task<int> Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}

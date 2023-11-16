using LearningTDD.InfraData.Interfaces;
using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;
using LearningTDD.Domain.DTO;

namespace LearningTDD.InfraData.Business
{
    public class StudentBusiness(IStudentRepository repository) : IStudent
    {
        private readonly IStudentRepository _repository = repository;

        public async Task<int> Add(object entity)
        {
            try
            {
                var item = (StudentDTO)entity;
                Student studentToAdd = new(
                    item.Id = null,
                    item.Name,
                    item.CPF,
                    item.Email);

                var result = await _repository.Add(studentToAdd);

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var exists = await Get(id);
                if (exists is null)
                {
                    return false;
                }
                var deleted = await _repository.Delete(id);
                return deleted;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Task<Student> Get(int id)
        {
            try
            {
                var exists = _repository.Get(id);
                return exists;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Update(object entity)
        {
            try
            {
                var item = (StudentDTO)entity;
                Student studentToUpdate = new(
                    item.Id,
                    item.Name,
                    item.CPF,
                    item.Email,
                    item.CreateIn);
                var result = await _repository.Update(studentToUpdate);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

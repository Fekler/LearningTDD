using LearningTDD.InfraData.Interfaces;
using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;
using LearningTDD.Domain.DTO;
using LearningTDD.InfraData.Util;

namespace LearningTDD.InfraData.Business
{
    public class StudentBusiness(IStudentRepository repository) : IStudent
    {
        private readonly IStudentRepository _repository = repository;

        public async Task<ApiResponse<int>> Add(object entity)
        {
            ApiResponse<int> result = new() 
            { 
                Success = false,
                Message = $"{Constants.FailedToAdd} {nameof(Student)}" 
            };
            if (entity is null)
            {
                result.Message = Constants.EntityCannotBeNull;
                return result;
            }

            try
            {
                var item = (StudentDTO)entity;
                var studentToAdd = StudentDtoToModel(item, added: false);

                var id = await _repository.Add(studentToAdd);
                if (id > 0)
                {
                    result.Success = true;
                    result.Data = id;
                    result.Message = $"{nameof(Student)} {Constants.AddedSuccessfully}";
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }

        public async Task<ApiResponse<bool>> Delete(int id)
        {
            ApiResponse<bool> result = new() { Success = false, Message = $"{Constants.FailedToDelete} {nameof(Student)}" };

            try
            {

                var existsResponse = await Get(id);
                if (existsResponse is null or { Success: false } or { Data: null })
                {
                    result.Message = existsResponse.Message;
                    return result;
                }

                var deleted = await _repository.Delete(existsResponse.Data.Id);
                if (deleted)
                {
                    result.Success = true;
                    result.Data = deleted;
                    result.Message = $"{nameof(Student)} {Constants.DeletedSuccessfully}";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ApiResponse<Student>> Get(int id)
        {
            ApiResponse<Student> result = new() { Success = false, Message = $"{nameof(Student)} {Constants.NotFound}" };
            try
            {
                var student = await _repository.Get(id);
                if (student is not null)
                {
                    result.Data = student;
                    result.Success = true;
                    result.Message = $"{nameof(Student)} {Constants.Found}";

                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ApiResponse<bool>> Update(object entity)
        {
            ApiResponse<bool> result = new() { Success = false, Message = $"{Constants.FailedToUpdate} {nameof(Student)}." };
            if (entity is null)
            {
                result.Message = Constants.EntityCannotBeNull;
                return result;
            }

            try
            {
                var item = (StudentDTO)entity;
                Student studentToUpdate = StudentDtoToModel(item);

                var updated = await _repository.Update(studentToUpdate);
                if (updated)
                {
                    result.Success = true;
                    result.Message = $"{studentToUpdate.GetType().Name} {Constants.UpdatedSuccessfully}";
                    result.Data = updated;
                }

            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        private static Student StudentDtoToModel(StudentDTO entity, bool added = true, string? name = null, string? cpf = null, string? email = null)
        {
            return new Student(
                id: (added) ? entity.Id : null,
                name: string.IsNullOrEmpty(name) ? entity.Name : name,
                cpf: string.IsNullOrEmpty(cpf) ? entity.CPF : cpf,
                email: string.IsNullOrEmpty(email) ? entity.Email : email,
                createIn: (added) ? entity.CreateIn : null);
        }

    }
}
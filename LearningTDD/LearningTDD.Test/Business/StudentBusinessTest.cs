using Bogus;
using Bogus.Extensions.Brazil;
using LearningTDD.Domain.DTO;
using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;
using LearningTDD.InfraData.Business;
using Moq;

namespace LearningTDD.Test.Business
{
    public class StudentBusinessTest
    {
        private readonly Faker _faker;
        private readonly StudentDTO _dto;
        private readonly StudentBusiness _business;
        private readonly Mock<IStudentRepository> _repository;

        public StudentBusinessTest()
        {
            _faker = new Faker();
            _dto = new()
            {
                Name = _faker.Person.FullName,
                Email = _faker.Person.Email,
                CPF = _faker.Person.Cpf()
            };

            _repository = new Mock<IStudentRepository>();
            _business = new StudentBusiness(_repository.Object);
        }
        [Fact]
        public async void ShouldAddStudent()
        {
            await _business.Add(_dto);
            _repository.Verify(r => r.Add(It.Is<Student>(s => s.Name == _dto.Name)));
        }

    }
}

using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using LearningTDD.Domain.DTO;
using LearningTDD.Domain.Interfaces;
using LearningTDD.Domain.Models;
using LearningTDD.InfraData.Business;
using LearningTDD.InfraData.Interfaces;
using Moq;

namespace LearningTDD.Test.Business
{
    public class StudentBusinessTest
    {
        private readonly Faker _faker;
        private Action _action;
        private readonly StudentDTO _dto;
        private readonly StudentBusiness _business;
        private readonly Mock<IStudentRepository> _repository;

        public StudentBusinessTest()
        {
            _faker = new Faker();
            _dto = new()
            {
                Id = 1,
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
        [Fact]
        public async void ShouldGetStudent()
        {
            Student student = new(null, _dto.Name, _dto.CPF, _dto.Email)
            {
            };
            await _business.Add(_dto);
            _repository.Setup(r => r.Get(0)).ReturnsAsync(student);
            var studentToCompare = await _business.Get(0);
            /*_action = () => */
            bool isEquals = studentToCompare.Equals(student);
            Assert.True(studentToCompare.Equals(student));
        }

    }
}

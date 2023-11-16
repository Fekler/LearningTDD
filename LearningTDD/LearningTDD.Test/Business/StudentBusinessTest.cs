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
            var studentId = await _business.Add(_dto);
            _repository.Verify(r => r.Add(It.Is<Student>(s => s.Name == _dto.Name)));
            Assert.True(studentId >= 0);
        }

        [Fact]
        public async void ShouldGetStudent()
        {
            Student student = new(null, _dto.Name, _dto.CPF, _dto.Email);

            var studentId = await _business.Add(_dto);
            _repository.Setup(r => r.Get(studentId)).ReturnsAsync(student);
            var studentToCompare = await _business.Get(studentId);

            Assert.True(studentToCompare.Equals(student));
        }

        [Fact]
        public async void ShouldDeleteStudent()
        {
            Student student = new(null, _dto.Name, _dto.CPF, _dto.Email);

            var studentId = await _business.Add(_dto);
            _repository.Setup(r => r.Delete(It.IsAny<int>())).ReturnsAsync(true);
            _repository.Setup(r => r.Get(studentId)).ReturnsAsync(student);

            var isDeleted = await _business.Delete(studentId);

            _repository.Verify(r => r.Delete(studentId), Times.Once);

            Assert.True(isDeleted);
        }

        [Fact]
        public async Task ShouldUpdateStudent()
        {
            Student student = new(null, _dto.Name, _dto.CPF, _dto.Email);
            string studentNewName = "New Name";

            var studentId = await _business.Add(_dto);

            _repository.Setup(r => r.Update(It.IsAny<Student>())).ReturnsAsync(true);


            _dto.Id = studentId;
            _dto.Name = studentNewName;

            var isUpdated = await _business.Update(_dto);


            _repository.Verify(r => r.Update(It.IsAny<Student>()), Times.Once);
             Assert.True(isUpdated);
        }

    }
}

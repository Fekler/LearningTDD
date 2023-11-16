using Bogus;
using FluentAssertions;
using LearningTDD.Domain.Validations;
using LearningTDD.Test._Builders;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace LearningTDD.Test.Unitary
{
    public class StudentTest
    {
        private readonly Faker _faker;
        private Action _action;

        public StudentTest()
        {
            _faker = new Faker();
        }
        [Fact(DisplayName ="Create Student")]
        public void CreateStudent()
        {
            _action = () => _ = StudentBuilder.New().Build();
            _action.Should().NotThrow();

        }
        [Fact(DisplayName = "Change Student Name")]
        public void ShouldChangeStudentName()
        {
            string newName = "New name";

            Action action = () =>
            {
                var student = StudentBuilder.New().Build();
                student.ChangeName(newName);
                Assert.Equal(newName, student.Name);
            };

            action.Should().NotThrow();
        }

    
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("CPF Invalido")]
        [InlineData("0000000000")]
        [InlineData("15")]
        public void DoNotShouldCreateWithInvalidCPF(string invalidCpf)
        {
            if (invalidCpf == "15")
                invalidCpf = _faker.Random.String(15);
            _action = () => _ = StudentBuilder.New().WithCpf(invalidCpf).Build();
            _action.Should().Throw<DomainExceptionValidation>().WithMessage(Error.CPF+".");

        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("email invalido")]
        [InlineData("email@invalido")]
        public void DoNotShouldCreateWithInvalidEmail(string invalidEmail)
        {
            _action = () => _ = StudentBuilder.New().WithEmail(invalidEmail).Build();
            _action.Should().Throw<DomainExceptionValidation>().WithMessage(Error.EMAIL + ".");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DoNotShouldCreateWithInvalidName(string invalidName)
        {
            _action = () => _ = StudentBuilder.New().WithName(invalidName).Build();
            _action.Should().Throw<DomainExceptionValidation>().WithMessage(Error.NAME + ".");
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-50)]
        public void DoNotShouldCreateWithInvalidId(int invalidId)
        {
            _action = () => _ = StudentBuilder.New().WithId(invalidId).Build();
            _action.Should().Throw<DomainExceptionValidation>().WithMessage(Error.ID + ".");
        }
    }
}

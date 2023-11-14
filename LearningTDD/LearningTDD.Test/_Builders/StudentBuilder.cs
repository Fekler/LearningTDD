using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using LearningTDD.Domain.Models;

namespace LearningTDD.Test._Builders
{
    public class StudentBuilder
    {
        int? _id;
        string _name;
        string _cpf;
        string _email;

        public static StudentBuilder New()
        {
            var _faker = new Faker();
            return new StudentBuilder
            {
                _name = _faker.Person.FullName,
                _email = _faker.Person.Email,
                _cpf = _faker.Person.Cpf(),
            };
        }
        public StudentBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public StudentBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public StudentBuilder WithCpf(string cpf)
        {
            _cpf = cpf;
            return this;
        }

        public StudentBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
        public Student Build()
        {
            var student = new Student(_id, _name, _cpf, _email);

            if (!_id.HasValue || _id <= 0)
                return student;

            var propertyInfo = student.GetType().GetProperty("Id");
            propertyInfo.SetValue(student, Convert.ChangeType(_id, propertyInfo.PropertyType), null);

            return student;
        }
    }
}

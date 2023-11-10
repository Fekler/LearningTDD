using LearningTDD.Domain.Models.Base;
using LearningTDD.Domain.Validations;
using System.Text.RegularExpressions;

namespace LearningTDD.Domain.Models
{
    public class Student : Entity
    {
        private readonly int _nameMaxLength = 150;
        private readonly int _cpfMaxLength = 11;

        private readonly Regex _emailRegex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private readonly Regex _cpfRegex = new(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");

        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime CreateIn { get; private set; }
        public DateTime? UpdateIn { get; private set; }

        public Student()
        {

        }

        public Student(int? id, string name, string cpf, string email, DateTime? createIn = null)
        {
            //name = name.Trim();// = name.Trim();
            var trimmedName = name.Trim();
            var trimmedCpf = cpf.Trim();
            var trimmedEmail = email.Trim();

            RuleValidator.Build()
                .When(id.HasValue && id <= 0, Error.ID)
                .When(string.IsNullOrEmpty(trimmedName) || trimmedName.Length > _nameMaxLength, Error.NAME)
                .When(string.IsNullOrEmpty(trimmedCpf) || !_cpfRegex.Match(trimmedCpf).Success || trimmedCpf.Length != _cpfMaxLength, Error.CPF)
                .When(string.IsNullOrEmpty(trimmedEmail) || !_emailRegex.Match(trimmedEmail).Success, Error.EMAIL)
                .ThrowExceptionIfExists();

            if (id.HasValue)
            {
                Id = id.Value;
                if (createIn.HasValue)
                    CreateIn = createIn.Value;
                UpdateIn = DateTime.Now;
            }
            else
                CreateIn = DateTime.Now;


            Name = trimmedName;
            CPF = trimmedCpf;
            Email = trimmedEmail;
        }
    }
}

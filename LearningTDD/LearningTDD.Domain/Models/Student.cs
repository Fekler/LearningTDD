using LearningTDD.Domain.Models._Base;
using LearningTDD.Domain.Validations;
using System.Text.RegularExpressions;

namespace LearningTDD.Domain.Models
{
    public partial class Student : Entity
    {
        private readonly int _nameMaxLength = 150;
        private readonly int _cpfMaxLength = 14;

        private readonly Regex _emailRegex = EmailValidator();
        private readonly Regex _cpfRegex = CPFValidator();

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
            var trimmedName = name?.Trim();
            var trimmedCpf = cpf?.Trim();
            var trimmedEmail = email?.Trim();

            RuleValidator.Build()
                .When(id.HasValue && id < 0, Error.ID)
                .When(string.IsNullOrEmpty(trimmedName) || trimmedName.Length > _nameMaxLength, Error.NAME)
                .When(string.IsNullOrEmpty(trimmedCpf) || !_cpfRegex.Match(trimmedCpf).Success || trimmedCpf.Length != _cpfMaxLength, Error.CPF)
                .When(string.IsNullOrEmpty(trimmedEmail) || !_emailRegex.Match(trimmedEmail).Success, Error.EMAIL)
                .ThrowExceptionIfExists();

            if (id.HasValue)
            {
                Id = id.Value;
                if (createIn.HasValue)
                    CreateIn = createIn.Value;
                UpdateIn = DateTime.UtcNow;
            }
            else
                CreateIn = DateTime.UtcNow;


            Name = trimmedName;
            CPF = trimmedCpf;
            Email = trimmedEmail;
        }

        public void ChangeName (string newName)
        {
            Name = newName;
        }

        [GeneratedRegex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]
        private static partial Regex CPFValidator();
        [GeneratedRegex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        private static partial Regex EmailValidator();
    }
}

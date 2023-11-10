namespace LearningTDD.Domain.Validations
{

    internal class DomainExceptionValidation : ArgumentException
    {
        internal string Error { get; set; }

        internal DomainExceptionValidation(string error) : base(error) => Error = error;
        //{
        //    Error = error;   
        //}
    }
}
  
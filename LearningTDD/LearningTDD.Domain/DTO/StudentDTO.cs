namespace LearningTDD.Domain.DTO
{
    public record StudentDTO
    {   
        public int? Id ;
        public string Nome ;
        public string Email ;
        public string CPF ;
        public DateTime? CreateIn;
        public DateTime? UpdateIn;
    }
}

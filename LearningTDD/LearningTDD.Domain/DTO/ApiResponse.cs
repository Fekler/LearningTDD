namespace LearningTDD.Domain.DTO
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string? Message { get; set; }

        public T? Data { get; set; }

        public int? ErrorCode { get; set; }



    }

}

namespace PolicyStreetBackEnd.Models
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Result { get; set; }

        public void SuccessResult(T resultData, string message)
        {
            Success = true;
            Result = resultData;
            Message = message;
        }

        public void ErrorResult(string message)
        {
            Success = false;
            Message = message;
        }

    }
}

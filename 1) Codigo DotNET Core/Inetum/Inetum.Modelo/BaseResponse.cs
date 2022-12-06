namespace Inetum.Modelos
{
    public class BaseResponse<T>
    {
        private BaseResponse() { }

        private BaseResponse(bool succeeded, T result, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
        }

        public bool Succeeded { get; set; }

        public T Result { get; set; }

        public IEnumerable<string> Errors { get; set; }

        public static BaseResponse<T> Success(T result)
        {
            return new BaseResponse<T>(true, result, new List<string>());
        }

        public static BaseResponse<T> Failure(IEnumerable<string> errors)
        {
            return new BaseResponse<T>(false, default, errors);
        }
    }
}

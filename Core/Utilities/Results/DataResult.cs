
namespace Core.Utilities.Results
{
    public abstract class DataResult<T> : Result
    {
        public DataResult(T data, bool status, string message) : base(status, message)
        {
            Data = data;
        }
        public DataResult(T data, bool status) : base(status)
        {
            Data=data;
        }
        public T Data { get; set; }
    }
}

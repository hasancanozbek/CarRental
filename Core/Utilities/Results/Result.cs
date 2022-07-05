
namespace Core.Utilities.Results
{
    public abstract class Result
    {
        public Result(bool status, string message) : this(status)
        {
            Message = message;
        }
        public Result(bool status)
        {
            Status=status;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
    }
}

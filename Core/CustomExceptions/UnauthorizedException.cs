
namespace Core.CustomExceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message= "You are performing an action for which you are not authorized. Please login first.") : base(message){ }
    }
}

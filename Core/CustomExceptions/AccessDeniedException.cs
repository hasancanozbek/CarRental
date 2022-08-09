
namespace Core.CustomExceptions
{
    [Serializable]
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string message= "Access denied for current user.") : base(message) {}
    }
}

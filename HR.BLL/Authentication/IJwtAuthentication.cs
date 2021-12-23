

namespace HR.BLL
{
    public interface IJwtAuthentication
    {
        public string Authenticate(string userId);
    }
}

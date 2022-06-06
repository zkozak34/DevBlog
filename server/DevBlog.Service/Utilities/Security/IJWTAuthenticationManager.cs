namespace DevBlog.Service.Utilities.Security
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(Guid id, string email, string fullName);
    }
}

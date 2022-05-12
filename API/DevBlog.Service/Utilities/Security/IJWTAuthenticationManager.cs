namespace DevBlog.Service.Utilities.Security
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(int id, string email);
    }
}

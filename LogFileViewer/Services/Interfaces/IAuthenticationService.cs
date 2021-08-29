namespace LogFileViewer.Services
{
    public interface IAuthenticationService
    {
        bool validateAuthentication(string username, string password);
    }
}
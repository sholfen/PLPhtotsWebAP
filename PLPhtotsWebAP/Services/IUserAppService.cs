namespace PLPhtotsWebAP.Services
{
    public interface IUserAppService
    {
        Task<bool> Login(string username, string password);
        Task Logout();
        bool CheckLoginState();
    }
}

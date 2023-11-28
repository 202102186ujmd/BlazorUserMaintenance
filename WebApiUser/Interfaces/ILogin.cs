namespace WebApiUser.Interfaces
{
    public interface ILogin
    {
        Task<bool> LoginStatus(string userName,string password);

    }
}

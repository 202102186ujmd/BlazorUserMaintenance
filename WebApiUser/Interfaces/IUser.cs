namespace WebApiUser.Interfaces
{
    public interface IUser
    {
        public User.Shared.User GetUserDatta(int id);
        public List<User.Shared.User> GetUsersDetails();
        public void AddUser(User.Shared.User user);
        public void UpdateUser(int userid,User.Shared.User user);
        public void DeleteUser(int id);
        
    }
}

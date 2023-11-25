using Microsoft.EntityFrameworkCore;
using WebApiUser.Interfaces;
using WebApiUser.Models;

namespace WebApiUser.Services
{

    public class UserManagment : IUser
    {
        private readonly UserBDContext db;
        public UserManagment(UserBDContext _db)
        {
            this.db = _db;
        }

        public void AddUser(User.Shared.User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                //logs
                throw new Exception(ex.Message);
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
                else 
                {          
                    //throw new ArgumentException("User not found");
                }
            }
            catch (Exception ex)
            {
                //logs
                throw new Exception(ex.Message);
            }
        }

        public User.Shared.User GetUserDatta(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return new User.Shared.User();
                }
            }
            catch (Exception ex)
            {
                //logs
                throw new Exception(ex.Message);
            }
        }

        public List<User.Shared.User> GetUsersDetails()
        {
            try
            {
                return db.Users.ToList();
            }
            catch (Exception ex)
            {
                //logs
                return new List<User.Shared.User>();
                throw new Exception(ex.Message);
            }
        }

        public void UpdateUser(int userid,User.Shared.User user)
        {
            try
            {
                //buscar el objeto, para actualizarlo solo los campos que quiera
                var usertoupdate = db.Users.Find(userid);
                if (usertoupdate != null)
                {
                   usertoupdate.UserId = userid;
                   usertoupdate.UserName = user.UserName ?? usertoupdate.UserName;
                   usertoupdate.Address = user.Address ?? usertoupdate.Address;
                   usertoupdate.CellNumber = user.CellNumber ?? usertoupdate.CellNumber;
                   usertoupdate.EmailId = user.EmailId ?? usertoupdate.EmailId;
                    db.Entry(usertoupdate).State = EntityState.Modified;
                    db.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                //logs
                throw new Exception(ex.Message);
            }
        }
    }
}

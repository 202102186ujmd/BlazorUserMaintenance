using WebApiUser.Interfaces;
using WebApiUser.Models;

namespace WebApiUser.Services
{
    public class LoginServices : ILogin
    {
        private readonly UserBDContext _db;
        public LoginServices(UserBDContext db)
        {
            _db = db;
        }

        public Task<bool> LoginStatus(string userName, string password)
        {
            //buscar el usuario en la base de datos
            var userTologin = _db.Login.Where(x => x. UserLogin == userName).FirstOrDefault();
            if (userTologin != null)
            {
                //validar la contraseña
                if (userTologin.Password == password)
                {
                    return Task.FromResult(true);
                }
            }
            return Task.FromResult(false);
        }
    }
}

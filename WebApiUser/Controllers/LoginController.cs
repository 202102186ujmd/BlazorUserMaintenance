using Microsoft.AspNetCore.Mvc;
using WebApiUser.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogin _loginServices;

        public LoginController(ILogin loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        public ActionResult<bool> Login(string userName, string password)
        {
            //validar el usuario
            var result = _loginServices.LoginStatus(userName, password);
            return result.Result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApiUser.Interfaces;

namespace WebApiUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            this._user = user;
        }

        [HttpGet]
        public async Task<List<User.Shared.User>> Get()
        {
            return await Task.FromResult(_user.GetUsersDetails());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var userss = _user.GetUserDatta(id);
            if (userss != null)
            {
                return Ok(userss);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public void Post(User.Shared.User user)
        {
            _user.AddUser(user);
        }

        [HttpPut]
        public void Put(int userid,User.Shared.User user)
        {
            _user.UpdateUser(userid,user);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _user.DeleteUser(id);
            return Ok();
        }
    }
}

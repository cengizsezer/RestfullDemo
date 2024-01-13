using Microsoft.AspNetCore.Mvc;
using RestfullDemo.Models;
using RestfullDemo.Services;

namespace RestfullDemo.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public ActionResult Create(UserRequestModel model)
        {
            var response = _userService.Create(model);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            var response = _userService.GetUser(id);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult GetAllUser()
        {
            var response = _userService.GetAll();
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult DeleteAllUsers()
        {
            _userService.DeleteAll();
            return Ok("All users deleted successfully.");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserRequestModel model)
        {
            var response = _userService.Update(id, model);
            return Ok(response);
        }


    }
}

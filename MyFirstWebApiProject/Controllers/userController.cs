using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IUserService _userService;

        public userController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: api/<loginController>
        [HttpGet]
        public ActionResult Get([FromQuery] string email, string password)
        {
            User user= _userService.GetUserByUserNameAndPassword(email, password);
            if(user==null)
                return NoContent();
            return Ok(user);
        }

        // GET api/<loginController>/5
        //[HttpGet("{id}")]
        //public ActionResult Get(string id)
        //{

        //}

        // POST api/<loginController>
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            User newUser = _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.userId }, newUser);            
        }

        [HttpPost("checkPassword")]
        public ActionResult CheckPassword([FromBody]string pwd)
        {
            return Ok(_userService.checkpassword(pwd));
        }

        // PUT api/<loginController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User userToUpdate)
        {
            if (_userService.UpdateUser(id, userToUpdate))
                return Ok();
            return NoContent();
        }

        // DELETE api/<loginController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

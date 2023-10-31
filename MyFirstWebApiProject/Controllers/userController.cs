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
        public async Task<ActionResult> Get([FromQuery] string email, string password)
        {
            User user= await _userService.GetUserByUserNameAndPassword(email, password);
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
        public async Task<ActionResult> Post([FromBody] User user)
        {
            User newUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.userId }, newUser);
        }

        [HttpPost("checkPassword")]
        public  ActionResult CheckPassword([FromBody]string pwd)
        {
            return Ok( _userService.checkpassword(pwd));
        }

        // PUT api/<loginController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            if (await _userService.UpdateUser(id, userToUpdate))
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

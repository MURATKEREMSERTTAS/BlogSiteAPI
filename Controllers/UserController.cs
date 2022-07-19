using BlogSiteAPI.Models;
using BlogSiteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogSiteAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetUsers() => 
            await userService.GetUsers();

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await userService.GetUser(id);

            if (user == null) return NotFound();
            else return user;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(User NewUser)
        {
            await userService.CreateUser(NewUser);
            return AcceptedAtAction(nameof(GetUsers), new { id = NewUser.Id }, NewUser);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(string id,User UUpdateUser)
        {
            var user = await userService.GetUser(id);
            if (user == null) return NotFound();
            else return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUSer(string id)
        {
            var user = await userService.GetUser(id);
            if(user == null) return NotFound();
            else
            {
                await userService.DeleteUser(id);
                return NoContent();
            }
        }

    }
}

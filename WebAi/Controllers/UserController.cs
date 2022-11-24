using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAi.Dtos;
using WebAi.Entities;
using WebAi.Services.Contracts;

namespace WebAi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
/// <summary>
/// userName = admin
/// Password :1234
/// </summary>
[AllowAnonymous]
        [HttpPost("login")]
        public User Login([FromBody] UserDto user)
        {
            var User = _userService.Authenticate(user.UserName, user.Password);
            return User;
        }

        [Authorize]
        // [Authorize("Admin")]
        [HttpGet("all")]
        public IEnumerable<User> GetAllUser ()
        {
            return _userService.GetAll();
        }
    }
}
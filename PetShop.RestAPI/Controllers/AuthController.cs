using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Models;
using PetShop.Core.Services;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthenticationHelper _auth;
        private IUserService _userService;

        public AuthController(IAuthenticationHelper auth, IUserService userService)
        {
            _auth = auth;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<UserDto> Login([FromBody]LoginDto loginData)
        {
            User user = _userService.Find(loginData.Username);

            if (user == null)
                return NotFound("User not found");


            if (!_auth.VerifyPasswordHash(loginData.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            var token = _auth.GenerateToken(user);

            return new UserDto
            {
                Username = user.Username,
                Token = token
            };
        }

        [HttpPost]
        public ActionResult<UserDto> Register([FromBody] LoginDto signupData)
        {

            byte[] passwordHash;
            byte[] passwordSalt;
            _auth.CreatePasswordHash(signupData.Password, out passwordHash, out passwordSalt);
            
            User user = new User
            {
                Username = signupData.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            user = _userService.Add(user);
            var token = _auth.GenerateToken(user);

            return new UserDto
            {
                Username = user.Username,
                Token = token
            };
        }
    }
}
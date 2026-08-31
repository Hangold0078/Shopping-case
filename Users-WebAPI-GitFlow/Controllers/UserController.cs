using Microsoft.AspNetCore.Mvc;
using Models;
using Users_WebAPI_GitFlow.Repository;

namespace Users_WebAPI_GitFlow.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
   private IUserRepository _userRepository;

   public UserController(IUserRepository userRepository)
   {
      _userRepository = userRepository;
   }

   [HttpPost]
   [Route("register")]
   public ActionResult<User> Add(User user) //Action result muliggør Http-respons
   {
      
      User newUser = _userRepository.Add(user);
      if (newUser == null)
      {
         return BadRequest("Email already exists");
      }
      
      return Ok(new { message = "User registered", user = newUser });

   }

   [HttpPost]
   [Route("login")]
   public ActionResult<Login> login(Login login)
   {
      User foundUser = _userRepository.Find(login);
      
         if (foundUser == null)
         {
            return Unauthorized( new {message ="user not found"}); //kode 401
         }

         return Ok(new {message = "Login successful", email = login.Email }); //kode 200
      
   }
}
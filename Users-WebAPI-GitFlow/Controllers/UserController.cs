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
   public ActionResult<User> Add(Login login) //Action result muliggør Http-respons
   {
      
      User newUser = _userRepository.Add(login);
      if (newUser == null)
      {
         return BadRequest("Email already exists");
      }
      
      return Ok(new { message = "User registered", user = newUser });

   }

   [HttpPost]
   [Route("login")]
   public ActionResult<User?> Login(Login login)
   {
      User? foundUser = _userRepository.GetByLogin(login);
      
         if (foundUser == null)
         {
            return NotFound( new {message ="user not found"}); //Kode 404
         }

         return Ok(new {message = "Login successful", email = login.Email }); //kode 200
   }

   [HttpGet]
   [Route("{id}")]
   public ActionResult<User> GetById(int id)
   {
      User user = _userRepository.GetById(id);

      if (user == null)
      {
         return NotFound(new { message = "User not found" });
      }

      return Ok(user);
   }

   [HttpGet]
   [Route("all")]
   public ActionResult<List<User>> GetAll()
   {
      return Ok(_userRepository.GetAll());
   }
}
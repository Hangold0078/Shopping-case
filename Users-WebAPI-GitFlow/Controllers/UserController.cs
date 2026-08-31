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
   public ActionResult<Login> login(Login login)
   {
      User foundUser = _userRepository.GetByEmail(login);
      
         if (foundUser == null)
         {
            return Unauthorized( new {message ="user not found"}); //kode 401
         }

         return Ok(new {message = "Login successful", email = login.Email }); //kode 200
   }

   [HttpGet]
   [Route("getbyid/{id}")]
   public ActionResult<User> GetById(int id)
   {
      User user = _userRepository.GetById(id);

      if (user == null)
      {
         return Unauthorized(new { message = "User not found" });
      }

      return Ok(user);
   }

   [HttpGet]
   [Route("getall")]
   public ActionResult<List<User>> GetAll()
   {
      return Ok(_userRepository.GetAll());
   }
}
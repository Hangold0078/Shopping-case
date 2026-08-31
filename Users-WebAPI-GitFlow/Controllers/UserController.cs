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
   [Route("RegisterUser")]
   public ActionResult<User> Add(User user) //Action result muliggør Http-respons
   {
      User newUser = _userRepository.Add(user);
      return Ok(newUser);

   }

   [HttpPost]
   [Route("login")]
   public ActionResult<User> login(User user)
   {
      User foundUser = _userRepository.GetUserByEmail(user);
      
         if (foundUser == null)
         {
            return Unauthorized( new {message ="user not found"}); //kode 401
         }

         return Ok(new {message = "Login successful", email = user.Email }); //kode 200
   }

   [HttpGet]
   [Route("getuserbyid/{id}")]
   public ActionResult<User> GetUserById(int id)
   {
      User user = _userRepository.GetUserById(id);

      if (user == null)
      {
         return Unauthorized(new { message = "User not found" });
      }

      return Ok(user);
   }

   [HttpGet]
   [Route("getallusers")]
   public ActionResult<List<User>> GetAllUsers()
   {
      return Ok(_userRepository.GetAll());
   }
   
   
}
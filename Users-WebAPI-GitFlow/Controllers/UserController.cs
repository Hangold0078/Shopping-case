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
}
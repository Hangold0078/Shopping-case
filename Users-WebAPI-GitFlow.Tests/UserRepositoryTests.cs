using Microsoft.AspNetCore.Mvc;
using Models;
using Users_WebAPI_GitFlow.Controllers;
using Users_WebAPI_GitFlow.Repository;
namespace Users_WebAPI_GitFlow.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserRepositoryTests
{
    private Mock<IUserRepository> _mockRepository;
    private UserController _controller;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IUserRepository>();
        _controller = new UserController(_mockRepository.Object);
    }
    
    [TestMethod]
    public void LoginValidCredentials()
    {
        //Arrange
        var login = new Login("Poul@mail.dk", "123"); //input, en bruger ville sende via login
        var user = new User("Poul@mail.dk", "qwe", "salt"); //bruger, som repository'et skal returnere
        
        //Uanset hvad login-metoden kalder GetByEmail med, så lad som om vi fandt brugeren i databasen
        _mockRepository.Setup(r => r.GetByEmail(It.IsAny<Login>()))
            .Returns(user);
        
        //Act
        var result = _controller.Login(login);
       
        //Assert
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
    }
}
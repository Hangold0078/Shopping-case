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
        _mockRepository.Setup(r => r.GetByEmail(It.IsAny<Login>()))
            .Returns(User);
        
        //Act
        var result = _controller.Login("Poul@mail.dk");
       
        //Assert
        Assert.IsTrue(result);
    }
}
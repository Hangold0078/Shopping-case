using Models;

namespace Users_WebAPI_GitFlow.Repository;

public interface IUserRepository
{
    public User Add(User user);
    public User Find(Login login);
    
}
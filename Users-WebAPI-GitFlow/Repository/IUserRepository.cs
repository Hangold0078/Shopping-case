using Models;

namespace Users_WebAPI_GitFlow.Repository;

public interface IUserRepository
{
    public User Add(User user);
    public User GetUserByEmail(User user);
    public User GetUserById(int id);
    public List<User> GetAll();
}
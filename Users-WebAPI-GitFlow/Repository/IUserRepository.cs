using Models;

namespace Users_WebAPI_GitFlow.Repository;

public interface IUserRepository
{
    public User Add(User user);
    public User GetByEmail(User user);
    public User GetById(int id);
    public List<User> GetAll();
}
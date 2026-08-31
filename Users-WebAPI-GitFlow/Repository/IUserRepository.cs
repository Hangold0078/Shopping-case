using Models;

namespace Users_WebAPI_GitFlow.Repository;

public interface IUserRepository
{
    public User Add(Login login);
    public User GetByEmail(Login login);
    public User GetById(int id);
    public List<User> GetAll();
}
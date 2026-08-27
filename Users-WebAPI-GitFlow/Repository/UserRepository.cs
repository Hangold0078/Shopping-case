using Models;

namespace Users_WebAPI_GitFlow.Repository;

public class UserRepository : IUserRepository
{
    private List<User> _users = new List<User>();

    public User Add(User user)
    {
        _users.Add(user);
        return user;
    }
}
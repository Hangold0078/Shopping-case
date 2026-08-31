using Models;

namespace Users_WebAPI_GitFlow.Repository;

public class UserRepository : IUserRepository
{
    
   private List<User> _users = new List<User>
    {
        new User("isra@gmail.com", "1234") { Id = 1 },
        new User("ali@gmail.com", "password123") { Id = 2 },
        new User("sara@gmail.com", "abcd") { Id = 3 },
        new User("maria@gmail.com", "test123") { Id = 4 }
    };

    private int _nextId = 5;
    public User Add(User user)
    {
        bool exists = _users.Any(matchUser => matchUser.Email == user.Email);
        if (exists)
        {
            return null;
        }
        user.Id = _nextId++;
        _users.Add(user);
        return user;
    }

    public User GetByEmail(User user)
    {
        User foundUser = _users.Find(matchUser => matchUser.Email == user.Email);
        return foundUser;
    }

    public User GetById(int id)
    {
        User foundUser = _users.Find(matchId => matchId.Id == id);
        return foundUser;
    }

    public List<User> GetAll()
    {
        return _users;
    }
}
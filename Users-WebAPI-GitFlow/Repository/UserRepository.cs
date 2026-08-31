using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Models;

namespace Users_WebAPI_GitFlow.Repository;

public class UserRepository : IUserRepository
{
    
    private List<User> _users = new List<User>
    {
        CreateUser( "isra@gmail.com", "1234"),
        CreateUser( "ali@gmail.com", "password123"),
        CreateUser( "sara@gmail.com", "abcd"),
        CreateUser( "maria@gmail.com", "test123")
    };

    public static User CreateUser(string email, string password) //static fordi metode omhandler lokal klasse, og ikke tilhører objektet
    {
        byte[] saltBytes = new byte[128 / 8];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetNonZeroBytes(saltBytes);
        }

        string salt = Convert.ToBase64String(saltBytes);

        string hash = Convert.ToBase64String(
            KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
            )
        );

        return new User(email, hash, salt);
    }
    public User Add(User user)
    {
        bool exists = _users.Any(matchUser => matchUser.Email == user.Email);
        if (exists)
        {
            return null;
        }
        _users.Add(user);
        return user;
    }

    public User Find(Login login)
    {
        User foundUser = _users.Find(matchUser => matchUser.Email == login.Email);
        return foundUser;
    }
}
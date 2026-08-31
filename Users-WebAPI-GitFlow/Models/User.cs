using System.ComponentModel.DataAnnotations;

namespace Models;

public class User
{
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string PasswordSalt { get; set; }

    public User(string email, string passwordHash, string passwordSalt)
    {
        this.Email = email;
        this.PasswordHash = passwordHash;
        this.PasswordSalt = passwordSalt;;
    }
}
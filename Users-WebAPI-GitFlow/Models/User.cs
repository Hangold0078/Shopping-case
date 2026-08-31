using System.ComponentModel.DataAnnotations;

namespace Models;

public class User
{
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    public User(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
}
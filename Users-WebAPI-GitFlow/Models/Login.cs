using System.ComponentModel.DataAnnotations;

namespace Models;

public class Login
{
    public int Id { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public Login(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
}
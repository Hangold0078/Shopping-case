namespace Models;

public class User
{
    private int Id { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }

    public User(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
}
namespace MTCG;

public class User(string username, string password)
{
    private string Username { get; set; } = username;
    private string Password { get; set; } = password;

    private int Id { get; set; }

    private string? Token {get; set;}
    private string? GameName { get; set; }
    private string? Bio { get; set; }
    private int Elo { get; set; }
    private int Wins { get; set; }
    private int Losses { get; set; }
    private int Draws { get; set; }
    private int Coins { get; set; } = 20;

    public override string ToString()
    {
        return $"Username: {Username}, Password: {Password}, Coins: ${Coins}";
    }
}
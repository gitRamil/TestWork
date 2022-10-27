namespace JWTService.Model;

public class User : BaseAuditEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
}
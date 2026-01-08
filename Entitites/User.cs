using System.ComponentModel.DataAnnotations.Schema;

namespace DbIntegation.Entitites;

[Table("Users")]
public class User : BaseEntity
{
    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? UserName { get; set; }

    [ForeignKey("Role")]
    public int RoleId { get; set; }

    public Role? Role { get; set; }

    public bool IsAdmin()
    {
       return Role?.Name == "ADMIN";
    }

    public bool IsGuest()
    {
        return Role?.Name == "GUEST";
    }

    public bool IsUser()
    {
        return Role?.Name == "USER";
    }
}

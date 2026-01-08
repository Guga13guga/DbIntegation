namespace DbIntegation.Dto;

public class UserDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? UserEmail { get; set; }

    public string? UserName { get; set; }

    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public bool IsAdmin()
    {
        return RoleName == "ADMIN";
    }

    public bool IsGuest()
    {
        return RoleName == "GUEST";
    }

    public bool IsUser()
    {
        return RoleName == "USER";
    }
}

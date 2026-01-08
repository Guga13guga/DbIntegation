using DbIntegation.Database;
using DbIntegation.Dto;
using Microsoft.EntityFrameworkCore;

namespace DbIntegation.Models;

public class UserService
{
    private readonly DbIntegrationDbContext _context;

    public UserService(IConfiguration config)
    {
        _context = new DbIntegrationDbContext(config);
    }

    public List<UserDto> GetAllUsers()
    {
        var users = _context.Users.Include(i => i.Role).ToList();
        return users.Select(i => new UserDto
        {
            Id = i.Id,
            Name = i.Name,
            RoleId = i.RoleId,
            RoleName = i.Role?.Name,
            UserEmail = i.Email,
            UserName = i.Name,
        }).ToList();
    }

    public UserDto GetUserById(int id)
    {
        var user = _context.Users.Include(i => i.Role).SingleOrDefault(i => i.Id == id);
        if (user is not null)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name,
                UserEmail = user.Email,
                UserName = user.Name,
            };
        }

        return null;
    }
}

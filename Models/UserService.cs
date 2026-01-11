using DbIntegation.Database;
using DbIntegation.Dto;
using DbIntegation.Entitites;
using Microsoft.EntityFrameworkCore;

namespace DbIntegation.Models;

public class UserService
{
    private readonly DbIntegrationDbContext _context;

    public UserService(IConfiguration config)
    {
        _context = new DbIntegrationDbContext(config);
    }

    public bool Registration(RegistrationDto req)
    {
        var role = _context.Roles.FirstOrDefault(i => i.Name == "USER");
        if (role is null) return false;
        var User = new User
        {
            Email = req.UserEmail,
            Name = req.Name,
            Password = req.Password,
            RoleId = role.Id,
            UserName = req.UserName,
        };

        _context.Users.Add(User);
        _context.SaveChanges();
        return true;
    }

    public UserDto? SignIn(SignInDto req)
    {
        var user = _context.Users.Include(i => i.Role).SingleOrDefault(i => i.Email == req.Email && i.Password == req.Password);
        if (user is null) return null;
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            RoleId = user.RoleId,
            UserEmail = user.Email,
            UserName = user.Name,
            RoleName = user.Role?.Name
        };
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

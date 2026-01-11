using DbIntegation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbIntegation.Controllers;

public class UserController : Controller
{
    private readonly UserService _userService;

    public UserController(IConfiguration config)
    {
        _userService = new UserService(config);
    }

    public IActionResult Index()
    {
        var user = _userService.GetAllUsers();
        return View(user);
    }

    public IActionResult View(int id)
    {
        var user = _userService.GetUserById(id);
        if (user is null) return NotFound("no User found");
        return View(user);
    }

    public IActionResult Create()
    {
        return View();
    }
}

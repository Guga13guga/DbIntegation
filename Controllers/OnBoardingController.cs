using DbIntegation.Dto;
using DbIntegation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbIntegation.Controllers;

public class OnBoardingController : Controller
{
    private readonly UserService _userService;

    public static UserDto? _userDto;

    public OnBoardingController(IConfiguration config)
    {
        _userService = new UserService(config);
    }

    public IActionResult Index()
    {
        if (_userDto is not null)
        {
            return RedirectToAction("SignedPage");
        }

        return View();
    }

    public IActionResult SignedPage()
    {
        if (_userDto == null)
        {
            return RedirectToAction("Index");
        }

        return View(_userDto);
    }

    public IActionResult SignIn()// chatvirtavs ragac gverds
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(SignInDto req)//informacias ugzavnis beqs
    {
        var user = _userService.SignIn(req);
        if (user is not null)
        {
            _userDto = user;
            return RedirectToAction("SignedPage");
        }
        return RedirectToAction("ErrorPage");
    }

    public IActionResult Registration()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registration(RegistrationDto req)
    {
        var res = _userService.Registration(req);
        if(res)return RedirectToAction("Index");

        return RedirectToAction("ErrorPage");
    }


    public IActionResult ErrorPage()
    {
        return View();
    }

    public IActionResult SignItOut()
    {
        _userDto = null;
        return RedirectToAction("Index");
    }

}

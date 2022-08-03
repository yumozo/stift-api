using Microsoft.AspNetCore.Mvc;
using StiftApi.Models;
using StiftApi.Data;
using StiftApi.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace StiftApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
  private readonly UserManager<IdentityUser> _userManager;

  public HomeController(UserManager<IdentityUser> userManager)
  {
    _userManager = userManager;
  }

  public IActionResult Login(string username, string email, string password)
  {
    // login functionality
    return null;
  }

  public IActionResult Register(string username, string email, string password)
  {
    // register functionality
    return null;
  }
}
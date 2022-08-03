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
  private readonly SignInManager<IdentityUser> _signInManager;

  public HomeController(
    UserManager<IdentityUser> userManager,
    SignInManager<IdentityUser> signInManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
  }

  [HttpPost]
  public async Task<IActionResult> Login(string username, string email, string password)
  {
    // login functionality
    var user = await _userManager.FindByNameAsync(username);

    if (user != null)
    {
      // sign in 
      var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

      if (result.Succeeded)
      {
        return Ok("Logined");
      }
    }

    return NotFound("User not registered yet");
  }

  [HttpPost]
  public async Task<IActionResult> Register(string username, string email, string password)
  {
    // register functionality
    var user = new IdentityUser
    {
      UserName = username,
      Email = email,
    };

    var result = await _userManager.CreateAsync(user, password);

    if (result.Succeeded)
    {
      // sign user here 
      var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

      if (signInResult.Succeeded)
      {
        return Ok("Registered and logined");
      }
    }

    return NotFound("idk what happened");
  }

  public async Task<IActionResult> LogOut()
  {
    await _signInManager.SignOutAsync();

    return Ok("Sign out is done");
  }
}
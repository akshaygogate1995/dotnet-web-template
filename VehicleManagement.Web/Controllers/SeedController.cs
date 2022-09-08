﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleManagement.User.Dto;
using VehicleManagement.User.Repositories.Interfaces;
using VehicleManagement.User.Services.Interfaces;

namespace VehicleManagement.Web.Controllers;

[AllowAnonymous]
public class SeedController : Controller
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepo;

    public SeedController(IUserService userService, IUserRepository userRepo)
    {
        _userService = userService;
        _userRepo = userRepo;
    }
    
    public async Task<IActionResult> SeedAdmin()
    {
        try
        {
            if (await _userRepo.CheckIfExistAsync(x=> x.Email == "admin@gmail.com"))
            {
                throw new Exception("Admin already exist");
            }
            var dto = new UserDto("Admin", "Male","admin@gmail.com","admin@123","Mechi, Nepal", "100000000");
            await _userService.CreateUser(dto);
            return Ok(new
            {
                message = "Success..."
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
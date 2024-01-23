﻿using App.User.Dto;
using App.User.Entity;

namespace App.User.Services.Interfaces;

public interface IUserService
{
    Task<AppUser> CreateUser(UserDto dto);
    Task Update(AppUser appUser, UserDto dto);
    Task Remove(AppUser appUser);
}
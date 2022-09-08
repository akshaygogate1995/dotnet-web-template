﻿namespace VehicleManagement.User.Validator.Interfaces;

public interface IUserValidator
{
    Task EnsureUniqueUserEmail(string email, long? id = null);
}
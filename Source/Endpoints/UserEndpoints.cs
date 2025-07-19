
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using UserManagementAPI.Dtos;
using UserManagementAPI.Models;
using UserManagementAPI.Services;
using UserManagementAPI.Utils;

namespace UserManagementAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        app.MapGet("/users", [Authorize] (IUserService service) =>
        {
            var user = service.GetAll().Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
            return Results.Ok(user);
        });

        app.MapGet("/users/{id}", (int id, IUserService service) =>
        {
            var user = service.GetById(id);
            if (user is null)
                return Results.NotFound();

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
            return Results.Ok(userDto);
        });

        app.MapPost("/users", (UserDto userDto, IUserService service) =>
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(userDto);
            if (!Validator.TryValidateObject(userDto, context, validationResults, true))
            {
                var error = validationResults.Select(v => v.ErrorMessage);
                return Results.BadRequest(error);
            }
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email
            };
            service.Add(user);
            return Results.Created($"/users/{user.Id}", user);
        });

        app.MapPut("/users/{id}", (int id, UserDto userDto, IUserService service) =>
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(userDto);
            if (!Validator.TryValidateObject(userDto, context, validationResults, true))
            {
                var errors = validationResults.Select(v => v.ErrorMessage);
                return Results.BadRequest(errors);
            }

            var updatedUser = new User
            {
                Name = userDto.Name,
                Email = userDto.Email
            };

            return service.Update(id, updatedUser) ? Results.Ok(updatedUser) : Results.NotFound();
        });

        app.MapDelete("/users/{id}", (int id, IUserService service) =>
        {
            return service.Delete(id) ? Results.NoContent() : Results.NotFound();
        });

        app.MapGet("/auth/token", (IConfiguration config) =>
        {
            var secretKey = config["Jwt:Key"];
            if (string.IsNullOrEmpty(secretKey))
            {
                return Results.Problem("JWT secret key is missing.");
            }

            var token = JwtHelper.GenerateJwtToken(secretKey);
            return Results.Ok(new { token });
        });
    }
}
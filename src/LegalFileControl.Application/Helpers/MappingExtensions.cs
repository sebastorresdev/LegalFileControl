using LegalFileControl.Application.DTOs.Users;
using LegalFileControl.Domain.Models;

namespace LegalFileControl.Application.Helpers;

public static class MappingExtensions
{
    #region User
    public static UserDto ToUserDto(this User user) =>
        new(
            Id: user.Id,
            Name: user.Name,
            Dni: user.Dni,
            UserName: user.UserName,
            Password: user.Password,
            RoleDescription: user.Role.Description,
            IsActive: user.IsActive ?? false
        );

    public static User ToUser(this CreateUserDto user) =>
        new()
        {
            Name = user.Name,
            Dni = user.Dni,
            UserName = user.UserName,
            Password = user.Password,
            RoleId = user.RoleId,
        };

    public static User ToUser(this UpdateUserDto user) =>
        new()
        {
            Name = user.Name,
            Dni = user.Dni,
            UserName = user.UserName,
            Password = user.Password,
            IsActive = user.IsActive,
            RoleId = user.RoleId
        };
    #endregion

}
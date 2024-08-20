namespace LegalFileControl.Application.DTOs.Users;

public record UserDto(
    int Id,
    string Name,
    string Dni,
    string UserName,
    string Password,
    string RoleDescription,
    bool IsActive
);
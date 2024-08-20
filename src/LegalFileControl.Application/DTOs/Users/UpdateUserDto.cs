namespace LegalFileControl.Application.DTOs.Users;

public record UpdateUserDto(
    string Name,
    string Dni,
    string UserName,
    string Password,
    bool IsActive,
    int RoleId
);
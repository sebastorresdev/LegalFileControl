namespace LegalFileControl.Application.DTOs.Users;

public record CreateUserDto(
    string Name,
    string Dni,
    string UserName,
    string Password,
    int RoleId
);
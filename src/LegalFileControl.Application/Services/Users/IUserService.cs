using LegalFileControl.Application.DTOs.Users;

namespace LegalFileControl.Application.Services.Users;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    // Task<SessionDto> ValidateCredentials(string email, string password);
    Task<UserDto> Create(UserDto createUserDto);
    Task<UserDto> Edit(UserDto updateUserDto, int id);
    Task Delete(int Id);
}
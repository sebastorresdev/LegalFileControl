using LegalFileControl.Application.DTOs.Users;

namespace LegalFileControl.Application.Services.Users;

public interface IUserService
{
    Task<List<UserDto>> GetAll();
    //Task<SessionDto> ValidateCredentials(string email, string password);
    Task<UserDto> GetById(int id);
    Task Create(CreateUserDto createUserDto);
    Task Update(UpdateUserDto updateUserDto, int id);
    Task<int> Delete(int Id);
}
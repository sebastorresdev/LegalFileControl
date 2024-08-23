using LegalFileControl.Application.DTOs.Users;
using LegalFileControl.Application.Helpers;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;

namespace LegalFileControl.Application.Services.Users;

public class UserService(IBaseRepository<User> userRepository) : IUserService
{
    private readonly IBaseRepository<User> _userRepository = userRepository;

    public async Task Create(CreateUserDto createUserDto)
    {
        try
        {
            await _userRepository.CreateAsync(createUserDto.ToUser());
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> Delete(int id)
    {
        try
        {
            await _userRepository.DeleteAsync(id);
            return id;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task Update(UpdateUserDto updateUserDto, int id)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(id);

            user.Name = updateUserDto.Name;
            user.IsActive = updateUserDto.IsActive;
            user.Dni = updateUserDto.Dni;
            user.Password = updateUserDto.Password;
            user.RoleId = updateUserDto.RoleId;
            user.UserName = updateUserDto.UserName;

            await _userRepository.UpdateAsync(user);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<UserDto>> GetAll()
    {
        try
        {
            var userList = await _userRepository.GetAllAsync();
            return userList.Select(user => user.ToUserDto()).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<UserDto> GetById(int id)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user.ToUserDto();

        }
        catch (Exception)
        {
            throw;
        }
    }
}
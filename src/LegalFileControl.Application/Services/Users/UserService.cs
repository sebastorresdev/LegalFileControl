using LegalFileControl.Application.DTOs.Users;
using LegalFileControl.Application.Helpers;
using LegalFileControl.Domain.Interfaces;
using LegalFileControl.Domain.Models;

namespace LegalFileControl.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IBaseRepository<User> _userRepository;

    public UserService(IBaseRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserDto> Create(UserDto createUserDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Edit(UserDto updateUserDto, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<UserDto>> GetAll()
    {
        try
        {
            var userList = await _userRepository.GetAllAsync();
            var e = userList.ToList();
            e.ForEach(c =>
            {
                if (c.Role == null)
                {
                    Console.WriteLine("Es null el role");
                }
            });

            return userList.Select(user => user.ToUserDto()).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
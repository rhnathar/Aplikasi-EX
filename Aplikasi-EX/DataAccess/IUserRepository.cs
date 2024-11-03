// DAL/Interfaces/IUserRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikasi_EX.Model;

public interface IUserRepository
{
    Task RegisterAsync(User user);
    Task<User> LoginAsync(string email, string password);
    Task<List<User>> GetUsersAsync();
}

using Hotel.Domain.Entities;

namespace Hotel.Application.Abstractions
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool> IsLoginAndPasswordValid(string login, string password);

        Task<bool> IsLoginAvailable(string login);

        Task<int> GetUserIdByLogin(string login);
    }
}

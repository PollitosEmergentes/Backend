using PeruStar.API.Security.Domain.Models;
using PeruStar.API.Security.Domain.Services.Communication;

namespace PeruStar.API.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(long id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(long id, UpdateRequest request);
    Task DeleteAsync(long id);
}
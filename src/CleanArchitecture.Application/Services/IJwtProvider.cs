using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.Services;

public interface IJwtProvider
{
    public Task<string> CreateTokenAsync(AppUser user,string password,CancellationToken cancellationToken=default);
}

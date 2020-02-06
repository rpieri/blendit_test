namespace BlendIt.Test.Domain.Users.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

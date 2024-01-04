using JsonWebToken.Models;

namespace JsonWebToken.Repository
{
    public interface IToken
    {
        Token Token(UserDto user);
    }
}

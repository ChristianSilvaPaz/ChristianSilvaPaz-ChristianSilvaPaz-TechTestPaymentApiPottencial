using Sales.Domain.Entities;

namespace Sales.Domain.Interfaces.Authentication;

public interface ITokenGenerator
{
    string Generate(User user);
}
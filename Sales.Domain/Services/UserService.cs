using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Authentication;
using Sales.Domain.Interfaces.Repositories;
using Sales.Domain.Result;
using Sales.Domain.Services.Models;

namespace Sales.Domain.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ServiceResult> AddAsync(UserCreateModel model)
    {
        var result = new ServiceResult<User>();

        if (string.IsNullOrEmpty(model.Username))
            result.AddError("Username", "Usuário inválido");

        if (string.IsNullOrEmpty(model.Password))
            result.AddError("Password", "Senha inválida");

        if (result.Errors.Count > 0)
            return result;

        var user = new User() { Id = Guid.NewGuid(), Password = model.Password, Username = model.Username };

        return result.WithData(await _userRepository.AddAsync(user));
    }

    public async Task<ServiceResult<string>> Authenticate(UserAutheticationModel model)
    {
        var result = new ServiceResult<string>();

        if (string.IsNullOrEmpty(model.Username))
            result.AddError("Username", "Usuário inválido");

        if (string.IsNullOrEmpty(model.Password))
            result.AddError("Password", "Senha inválida");

        if (result.Errors.Count > 0)
            return result;

        var user = await _userRepository.GetByNameAndPasswordAsync(model.Username, model.Password);

        if (user is null)
        {
            result.AddError(string.Empty, "Usuário ou senha inválidos");
            return result;
        }

        return result.WithData(_tokenGenerator.Generate(user));
    }
}

using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Application.Features.Auths.Rules;

public class AuthBusinessRules(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task EmailMustBeUnique(string email)
    {
        var existingUser = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
        if (existingUser != null)
            throw new BusinessException("Bu e-posta adresi zaten kayıtlı.");
    }

    public async Task UserMustExist(string email)
    {
        var user = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
        if (user == null)
            throw new BusinessException("Kullanıcı bulunamadı.");
    }

    public void PasswordMustMatch(string plainPassword, byte[] storedHash, byte[] storedSalt)
    {
        bool isMatch = HashingHelper.VerifyPasswordHash(plainPassword, storedHash, storedSalt);
        if (!isMatch)
            throw new BusinessException("Şifre hatalı.");
    }
}

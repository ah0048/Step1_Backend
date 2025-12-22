using Step1_Backend.DTOs.AuthDTOs;
using Step1_Backend.Helpers;

namespace Step1_Backend.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public Task<Result<string>> Login(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> Register(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }
    }
}

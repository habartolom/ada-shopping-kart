using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Contracts.Login;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace App.Web.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ICryptographyService _cryptographyService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(ICryptographyService cryptographyService, IUserRepository userRepository, IConfiguration configuration)
        {
            _cryptographyService = cryptographyService;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ResponseTypedContract<UserDto>> CreateUserAsync(SignUpDto signUp)
        {
            var response =  new ResponseTypedContract<UserDto>();
            return response;
        }

        public async Task<ResponseTypedContract<IEnumerable<UserDto>>> GetAllRegularUsersAsync()
        {
            var response = new ResponseTypedContract<IEnumerable<UserDto>>();
            return response;
        }

        public async Task<ResponseTypedContract<UserDto>> GetUserAsync(Guid userId)
        {
            var response = new ResponseTypedContract<UserDto>();
            return response;
        }

        public async Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync(LoginRequestContract loginRequest)
        {
            var response = new ResponseTypedContract<LoginResponseContract>();
            try
            {
                UserEntity? user = await _userRepository.GetUserByUsername(loginRequest.Username);
                if (user != null && user.IsActive && IsCorrectPassword(loginRequest.Password, user))
                {
                    string token = GenerateToken(user);
                    response.Data = new LoginResponseContract() { Username = user.Person.Name, Role = user.Role.Name, Token = token };
                    return response;
                }

                response.Header.Code = HttpCodeEnum.Unauthorized;
                response.Header.Message = "Invalid Credentials";
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        private string GenerateToken(UserEntity user)
        {
            string secret = _configuration.GetSection("JWT:SecretKey").Value!;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username!.Trim()),
                    new Claim(ClaimTypes.Role, user.Role!.Name),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private bool IsCorrectPassword(string password, UserEntity user)
        {
            if (!string.IsNullOrWhiteSpace(user.PasswordHash) && !string.IsNullOrWhiteSpace(user.PasswordHash))
            {
                byte[] salt = Convert.FromBase64String(user.PasswordSalt!);
                byte[] storedPasswordHash = Convert.FromBase64String(user.PasswordHash);
                byte[] passwordHash = _cryptographyService.GenerateHash(password, salt);

                bool areSamePassword = _cryptographyService.AreHashesEqual(storedPasswordHash, passwordHash);
                return areSamePassword;
            }

            return false;
        }
    }
}

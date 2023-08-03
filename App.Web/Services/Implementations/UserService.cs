using App.Web.Infrastructure.Interfaces;
using App.Web.Models.Constants;
using App.Web.Models.Contracts.Response;
using App.Web.Models.Contracts.Users;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using App.Web.Models.Enums;
using App.Web.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IMapper _mapper;

        public UserService(ICryptographyService cryptographyService, IUserRepository userRepository, IConfiguration configuration, IMapper mapper)
        {
            _cryptographyService = cryptographyService;
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseTypedContract<UserDto>> CreateUserAsync(SignupRequestContract signUpRequest)
        {
            var response =  new ResponseTypedContract<UserDto>();
            try
            {
                UserEntity? existingUser = await _userRepository.GetUserByUsernameAsync(signUpRequest.Username);
                if (existingUser != null) throw new Exception("User cannot be created, username already exists");

                byte[] salt = _cryptographyService.GenerateSalt();
                byte[] hash = _cryptographyService.GenerateHash(signUpRequest.Password, salt);

                UserEntity newUser = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Username = signUpRequest.Username.ToLower(),
                    PasswordHash = Convert.ToBase64String(hash),
                    PasswordSalt = Convert.ToBase64String(salt),
                    IsActive = true,
                    RoleId = Constants.Roles.RegularId,
                    Person = new PersonEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = signUpRequest.Name,
                        Address = signUpRequest.Address,
                        Phone = signUpRequest.Phone
                    }
                };

                var user = await _userRepository.CreateUserAsync(newUser);
                response.Data = _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        public ResponseTypedContract<IEnumerable<UserDto>> GetAllRegularUsers()
        {
            var response = new ResponseTypedContract<IEnumerable<UserDto>>();
            try
            {
                response.Data = _userRepository.GetAllRegularUsers();
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        public async Task<ResponseTypedContract<UserDto>> GetUserAsync(Guid userId)
        {
            var response = new ResponseTypedContract<UserDto>();
            try
            {
                var user = await _userRepository.GetUser(userId);
                if (user is null) throw new Exception("User not found");
                response.Data = user;
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpCodeEnum.InternalServerError;
                response.Header.Message = ex.ToString();
            }

            return response;
        }

        public async Task<ResponseTypedContract<LoginResponseContract>> LogUserAsync(LoginRequestContract loginRequest)
        {
            var response = new ResponseTypedContract<LoginResponseContract>();
            try
            {
                UserEntity? user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);

                if (user != null && user.IsActive && IsCorrectPassword(loginRequest.Password, user))
                {
                    string token = GenerateToken(user);
                    response.Data = _mapper.Map<LoginResponseContract>(user);
                    response.Data.Token = token;
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

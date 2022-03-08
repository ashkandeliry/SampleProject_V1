using AutoMapper;
using Common.Exceptions;
using DAL.Contract;
using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Settings;
using ViewModels.UsersViewModels;

namespace BLL.UsersBLL
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly SiteSettings _siteSetting;
        public UsersService(IMapper mapper,IUsersRepository usersRepository, IOptionsSnapshot<SiteSettings> settings)
        {
            _usersRepository = usersRepository;
            _siteSetting = settings.Value;
            _mapper = mapper;
        }
        public async Task<string> Login(string Username, string Password, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                    throw new Exception("نام کاربری یا کامه عبور را وارد نمایید");
                var UserData = await _usersRepository.Login(Username);
                if (UserData == null)
                    throw new NotFoundException("نام کاربری یافت نشد");
                else
                {
                    var jwt = await GenerateAsync(UserData);
                    return jwt;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<string> GenerateAsync(TblUser user)
        {
            var secretKey = Encoding.UTF8.GetBytes(_siteSetting.Jwt.Key);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),
                SecurityAlgorithms.HmacSha256Signature);

            var claims = await _getClaimsAsync(user);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _siteSetting.Jwt.Issuer,
                Audience = _siteSetting.Jwt.Issuer,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(_siteSetting.Jwt.NotBeforeMinutes),
                Expires = DateTime.Now.AddMinutes(_siteSetting.Jwt.ExpirationMinutes),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims)
            };


            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(descriptor);

            var jwt = tokenHandler.WriteToken(securityToken);

            return jwt;
        }

        private async Task<IEnumerable<Claim>> _getClaimsAsync(TblUser user)
        {
            //JwtRegisteredClaimNames.Sub
            var securityStampClaimType = new ClaimsIdentityOptions().SecurityStampClaimType;

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            return userClaims;
        }

        public async Task<List<UsersListDTO>> GetUsersList()
        {
            try
            {
                var UserData = await _usersRepository.GetUsersListRepo();
                List<UsersListDTO> Result = _mapper.Map<List<UsersListDTO>>(UserData);
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

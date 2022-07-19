using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Almacen_Back.Data;
using Almacen_Back.Models;
using Almacen_Back.Models.DTO;
using Almacen_Back.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Almacen_Back.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Almacen_Back_Context _db;
        private readonly IConfiguration _configuration;
        private IMapper _mapper;
        public UserRepository(Almacen_Back_Context db, IConfiguration configuration,IMapper mapper)
        {
            _db = db;
            _configuration = configuration;            
            _mapper = mapper;
        }

        public async Task<string> Login(UserDTO userDTO)
        {
            var user = await _db.User.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(userDTO.UserName.ToLower()));

            if (user == null)
            {
                return "nouser";
            }
            else
            {
                if (!VerificarPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
                {
                    return "wrongpassword";
                }
                else
                {
                    return CrearToken(user);
                }
            }
        }

        public async Task<string> Register(UserDTO userDTO)
        {
            try
            {
                User user = _mapper.Map<UserDTO, User>(userDTO);  
                if (await UserExiste(user.UserName))
                {
                    return "existe";
                }

                CrearPasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _db.User.AddAsync(user);
                await _db.SaveChangesAsync();
                return CrearToken(user);
            }
            catch (Exception)
            {

                return "error";
            }
        }

        public async Task<bool> UserExiste(string username)
        {
            if (await _db.User.AnyAsync(x => x.UserName.ToLower().Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerificarPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private string CrearToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration
                .GetSection("AppSetting:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}

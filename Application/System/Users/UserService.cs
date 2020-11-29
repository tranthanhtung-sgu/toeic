using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Excepsions;
using Application.ViewModels.User;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        public UserService(UserManager<User> userManager, 
            SignInManager<User> signInManager, RoleManager<Role> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<string> Autheticate(LoginRequest request)
        {
            string securityKey = "this_is_super_long_security_key_for_token_validation_project_toeiconline_from_tung";
            var user = await _userManager.FindByNameAsync(request.UserName);
            if(user == null) return null;
            
            var result = await _signInManager.PasswordSignInAsync(user, request.password, request.isRememberMe, true);
            if(!result.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new []
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";", roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // create token
            var token = new JwtSecurityToken(
                issuer: "Tung",
                audience: "VanLaTung",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new User(){
                birthday = request.Dob,
                Address = request.Address,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                UserName =request.UserName
            };
            var result = await _userManager.CreateAsync(user, request.password);
            if(result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
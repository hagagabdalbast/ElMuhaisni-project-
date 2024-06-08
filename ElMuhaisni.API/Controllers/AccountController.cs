using ElMuhaisni.BL.DTO.Account;
using ElMuhaisni.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElMuhaisni.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            //Save User In Db
            ApplicationUser userModel = new ApplicationUser();
            userModel.UserName = registerDTO.UserName;
            userModel.Email = registerDTO.Email;

            

            IdentityResult Result = await userManager.CreateAsync(userModel, registerDTO.Password);

            if (Result.Succeeded)
            {
                await userManager.AddToRoleAsync(userModel, "User");
                return Ok("Added Success");
            }

            else
            {
                foreach (var item in Result.Errors)
                    ModelState.AddModelError("", item.Description);

                return BadRequest(ModelState);
            }

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Check
            ApplicationUser userModel = await userManager.FindByEmailAsync(loginDTO.Email);

            if (userModel != null)
            {
                //Check If Entered password is the password of given Email Or Not
                if (await userManager.CheckPasswordAsync(userModel, loginDTO.Password))
                {
                    //--------- Generate Token Based on Claims "Id - Name - Roles" + Jti ==> unique token key

                    // first generate claims
                    var Claims = new List<Claim>();

                    Claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id));
                    Claims.Add(new Claim(ClaimTypes.Name, userModel.UserName));

                    var roles = await userManager.GetRolesAsync(userModel);
                    foreach (var role in roles)
                    {
                        Claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    //add token identifier claim
                    Claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    //------------------------------ (** Generate Token That Contain Claims **) ------------------------------// 

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

                    var token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(30),
                        claims: Claims,
                        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });

                }
                else
                {
                    //return Unauthorized();
                    return BadRequest("Invalid Email Or Password");
                }
            }

            return BadRequest(loginDTO);

        }
    }
}

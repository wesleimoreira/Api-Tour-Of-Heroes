using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Api_Tour_Of_Heroes_Application.ViewModels;
using Api_Tour_Of_Heroes_Infrastructure.Services;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{   
    public class LoginController : BaseController
    {
        public LoginController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }


        [AllowAnonymous]
        [HttpPost("authentication")]       
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserViewModel model)
        {
            try
            {
                var user = await this.UserRepository.GetByIdAsync(model.Id);

                if (user == null)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "User not found",
                        data = new object(),
                        token = string.Empty
                    });
                }

                var token = TokenService.GenerateToken(this.Mapper.Map<User>(user));

                user.Password = string.Empty;

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "User successfully found",
                    data = user,
                    token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = new object(),
                    token = string.Empty
                });
            }
        }
    }
}

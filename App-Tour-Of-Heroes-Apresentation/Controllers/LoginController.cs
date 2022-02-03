using Api_Tour_Of_Heroes_Domain.Interfaces;
using Api_Tour_Of_Heroes_Infrastructure.Services;
using App_Tour_Of_Heroes_Apresentation.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }

        /// <summary>
        /// Returns a list of User
        /// </summary>      
        /// <returns> Retorna o token para autenticação </returns>
        /// <response code="200"> Retorna um token </response>        
        /// <response code="404"> Não possui o usuário </response>
        [AllowAnonymous]
        [HttpPost("authentication")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AuthenticateAsync(string userName, string password)
        {
            try
            {
                var user = await this.UserRepository.GetParameter(x => x.UserName == userName && x.Password == password);

                if (user is null) return ResponseNotFound("O Usuário/Senha estão errados!");

                var token = TokenService.GenerateToken(user);               

                return ResponseOk(token);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }
    }
}

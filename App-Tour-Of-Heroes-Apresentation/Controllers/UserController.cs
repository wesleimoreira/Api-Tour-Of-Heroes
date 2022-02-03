using Api_Tour_Of_Heroes_Application.ViewModels;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using App_Tour_Of_Heroes_Apresentation.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }

        /// <summary>
        /// Returns a list of User
        /// </summary>      
        /// <returns> retorna uma lista de usuários </returns>
        /// <response code="200"> Retorna a lista </response>        
        /// <response code="404"> Não possui usuários cadastrados </response>
        [AllowAnonymous]
        [HttpGet("user-list")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var listOfUser = this.Mapper.Map<IEnumerable<UserViewModel>>(await this.UserRepository.GetAllAsync());

                if (listOfUser.Any()) return ResponseOk(listOfUser);

                return ResponseNotFound("Não possui Usuários cadastrados!");

            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Returns a User by id
        /// </summary>
        /// <param name="id"></param>     
        /// <returns> retorna o usuário solicitado </returns>
        /// <response code="200"> retorna o usuário </response>        
        /// <response code="404"> Não possui usuários cadastrados </response>
        [AllowAnonymous]
        [HttpGet("user/{id:int}")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var hero = this.Mapper.Map<UserViewModel>(await this.UserRepository.GetByIdAsync(id));

                if (hero != null) return ResponseOk(hero);

                return ResponseNotFound("O Usuário não foi encontrado!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>   
        /// <returns> retorna o usuário cadastrado </returns>
        /// <response code="200"> usuário cadastrado</response>        
        /// <response code="404"> Não foi possivel cadastrar o usuário </response>
        [HttpPost("create-user")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync(string userName, string password, string role)
        {
            try
            {
                var newUser = new UserViewModel { UserName = userName, Password = password, Role = role };

                var createUser = await this.UserRepository.CreateAsync(this.Mapper.Map<User>(newUser));

                if (createUser == 1) return ResponseCreated("O Usuário foi criado com sucesso!");

                return ResponseNoContent();

            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="model"></param>  
        /// <returns> Retorna o usuário atualizado </returns>
        /// <response code="200"> Retorna o usuário atualizado </response>        
        /// <response code="404"> O usuário não está cadastrado </response>
        [HttpPut("update-user")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromQuery] UserViewModel model)
        {
            try
            {
                var updateHero = await this.UserRepository.UpdateAsync(this.Mapper.Map<User>(model));

                if (updateHero == 1) return ResponseOk("O Usuário foi alterado com sucesso!");

                return ResponseNotModified();
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove a hero
        /// </summary>
        /// <param name="id"></param>  
        /// <returns> retorna o identificador do usuário deletado </returns>
        /// <response code="200"> Retorna o identificados </response>        
        /// <response code="404"> O usuário não está cadastrado </response>
        [HttpDelete("delete-user/{id:int}")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var deleteHero = await this.UserRepository.DeleteAsync(this.Mapper.Map<User>(new UserViewModel { Id = id }));

                if (deleteHero == 1) return ResponseOk("O Usuário foi deletado com sucesso!");

                return ResponseNotFound("Não foi encontrado o usuário");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

    }
}

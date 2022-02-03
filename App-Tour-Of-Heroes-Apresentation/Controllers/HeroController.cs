using Api_Tour_Of_Heroes_Application.ViewModels;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using App_Tour_Of_Heroes_Apresentation.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class HeroController : BaseController
    {
        public HeroController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }

        /// <summary>
        /// Obter todos os hérois
        /// </summary>   
        /// <returns> retorna uma lista de hérois </returns>
        /// <response code="200"> retorna os hérois encontrados </response>        
        /// <response code="404"> Há lista de hérois esta vazia </response>
        [AllowAnonymous]
        [HttpGet("heroes-list")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var listOfHeroes = this.Mapper.Map<List<HeroViewModel>>(await this.HeroRepository.GetAllAsync());

                if (listOfHeroes.Count > 0) ResponseOk(listOfHeroes);

                return ResponseNotFound("Não foi encontrado Héroi registrado!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obter um héroi por identificador
        /// </summary>
        /// <param name="id"></param>    
        /// <returns> retorna um héroi expecifico </returns>
        /// <response code="200"> retorna o héroi </response>        
        /// <response code="404"> O héroi não foi encontrado </response>
        [AllowAnonymous]
        [HttpGet("hero/{id:int}")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var hero = this.Mapper.Map<HeroViewModel>(await this.HeroRepository.GetByIdAsync(id));

                if (hero != null) ResponseOk(hero);

                return ResponseNotFound("Não foi encontrado o Héroi!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// create a hero
        /// </summary>
        /// <param name="name"></param>    
        /// <returns> retorna o héroi criado </returns>
        /// <response code="200"> retorna o héroi criado </response>        
        /// <response code="404"> O héroi não foi criado </response>
        [HttpPost("create-hero")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAsync([FromQuery] string name)
        {
            try
            {
                var newHero = new HeroViewModel { Name = name };

                var createHero = await this.HeroRepository.CreateAsync(this.Mapper.Map<Hero>(newHero));

                if (createHero == 1) return ResponseOk("O Héroi foi criado com sucesso!");

                return ResponseNotFound("Não foi possivel criar um novo héroi!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="model"></param> 
        /// <returns> retorna o héroi atualizado </returns>
        /// <response code="200"> retorna o héroi atualizado </response>        
        /// <response code="404"> O héroi não foi encontrado </response>
        [HttpPut("update-hero")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromQuery] HeroViewModel model)
        {
            try
            {
                var updateHero = await this.HeroRepository.UpdateAsync(this.Mapper.Map<Hero>(model));

                if (updateHero == 1) return ResponseOk("O Héroi foi atualizado com sucesso!");

                return ResponseNotFound("O Héroi não foi encontrado!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }

        /// <summary>
        /// remove um héroi da lista
        /// </summary>
        /// <param name="id"></param>    
        /// <returns> O identificador do héroi removido </returns>
        /// <response code="200"> héroi removido com sucesso </response>        
        /// <response code="404"> Não foi encontrado o héroi </response>
        [HttpDelete("delete-hero/{id:int}")]
        [EstruturaRetorno(StatusCodes.Status200OK)]
        [EstruturaRetorno(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var isDeleteHero = await this.HeroRepository.DeleteAsync(await this.HeroRepository.GetByIdAsync(id));

                if (isDeleteHero == 1) return ResponseOk("Héroi removido com sucesso!");

                return ResponseNotFound("O Héroi não foi encontrado!");
            }
            catch (Exception ex)
            {
                return ResponseBadRequest(ex.Message);
            }
        }
    }
}

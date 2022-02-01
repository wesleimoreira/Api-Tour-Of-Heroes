using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Api_Tour_Of_Heroes_Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Api_Tour_Of_Heroes_Application.ViewModels;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class HeroController : BaseController
    {
        public HeroController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper) : base(userRepository, heroRepository, mapper)
        { }

        /// <summary>
        /// Returns a list of heroes
        /// </summary>       
        [AllowAnonymous]
        [HttpGet("heroes-list")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var listOfHeroes = this.Mapper.Map<List<HeroViewModel>>(await this.HeroRepository.GetAllAsync());

                if (listOfHeroes.Count == 0 || listOfHeroes == null)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "Hero list not found.",
                        data = Array.Empty<HeroViewModel>()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "list of heroes successfully found.",
                    data = listOfHeroes
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    data = Array.Empty<HeroViewModel>()
                });
            }
        }

        /// <summary>
        /// Returns a hero by id
        /// </summary>
        /// <param name="id"></param>      
        [AllowAnonymous]
        [HttpGet("hero/{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var hero = this.Mapper.Map<HeroViewModel>(await this.HeroRepository.GetByIdAsync(id));

                if (hero == null)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "hero not found",
                        dado = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "hero successfully found",
                    dado = hero
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    dado = new object()
                });
            }
        }

        /// <summary>
        /// create a hero
        /// </summary>
        /// <param name="name"></param>      
        [HttpPost("create-hero")]
        public async Task<IActionResult> CreateAsync([FromQuery] string name)
        {
            try
            {
                var newHero = new HeroViewModel { Name = name };

                var createHero = await this.HeroRepository.CreateAsync(this.Mapper.Map<Hero>(newHero));

                if (createHero != 1)
                {
                    return BadRequest(new
                    {
                        status = StatusCodes.Status400BadRequest,
                        message = "it was not possible to register the hero",
                        dado = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status201Created,
                    message = "hero created successfully",
                    dado = newHero
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    dado = new object()
                });
            }
        }

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="model"></param>       
        [HttpPut("update-hero")]
        public async Task<IActionResult> UpdateAsync([FromQuery] HeroViewModel model)
        {
            try
            {
                var updateHero = await this.HeroRepository.UpdateAsync(this.Mapper.Map<Hero>(model));

                if (updateHero != 1)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "could not update hero.",
                        dado = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "hero successfully updated",
                    dado = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    dado = new object()
                });
            }
        }

        /// <summary>
        /// Remove a hero
        /// </summary>
        /// <param name="id"></param>       
        [HttpDelete("delete-hero/{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var deleteHero = new HeroViewModel { Id = id };

                var isDeleteHero = await this.HeroRepository.DeleteAsync(this.Mapper.Map<Hero>(deleteHero));

                if (isDeleteHero != 1)
                {
                    return NotFound(new
                    {
                        status = StatusCodes.Status404NotFound,
                        message = "could not delete hero.",
                        dado = new object()
                    });
                }

                return Ok(new
                {
                    status = StatusCodes.Status200OK,
                    message = "hero successfully deleted",
                    dado = deleteHero
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = StatusCodes.Status400BadRequest,
                    message = ex.Message,
                    dado = new object()
                });
            }
        }
    }
}

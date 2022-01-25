using Api_Tour_Of_Heroes_Application.ViewModels;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    public class HeroController : BaseController
    {
        public HeroController(IHeroRepositoty heroRepository, IMapper mapper) : base(heroRepository, mapper)
        { }

        /// <summary>
        /// Returns a list of heroes
        /// </summary>       
        [HttpGet]
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
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
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
        /// <param name="model"></param>       
        [HttpPost]
        public async Task<IActionResult> CreateAsync(HeroViewModel model)
        {
            try
            {
                var createHero = await this.HeroRepository.CreateAsync(this.Mapper.Map<Hero>(model));

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
        /// Update a hero
        /// </summary>
        /// <param name="model"></param>       
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(HeroViewModel model)
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
        /// <param name="model"></param>        
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(HeroViewModel model)
        {
            try
            {
                var deleteHero = await this.HeroRepository.DeleteAsync(this.Mapper.Map<Hero>(model));

                if (deleteHero != 1)
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
    }
}

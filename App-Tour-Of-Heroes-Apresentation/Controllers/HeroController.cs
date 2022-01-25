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
        public async Task<ActionResult<List<HeroViewModel>>> GetAllAsync()
        {
            try
            {
                return Ok(this.Mapper.Map<List<HeroViewModel>>(await this.HeroRepository.GetAllAsync()));
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Returns a hero by id
        /// </summary>
        /// <param name="id"></param>      
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroViewModel>> GetByIdAsync(int id)
        {
            try
            {
                return Ok(this.Mapper.Map<HeroViewModel>(await this.HeroRepository.GetByIdAsync(id)));
            }
            catch
            {
                return NotFound();
            }
        }

        /// <summary>
        /// create a hero
        /// </summary>
        /// <param name="model"></param>       
        [HttpPost]
        public async Task<ActionResult<int>> CreateAsync(HeroViewModel model)
        {
            try
            {
                return Ok(await this.HeroRepository.CreateAsync(this.Mapper.Map<Hero>(model)));
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update a hero
        /// </summary>
        /// <param name="model"></param>       
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAsync(HeroViewModel model)
        {
            try
            {
                return Ok(await this.HeroRepository.UpdateAsync(this.Mapper.Map<Hero>(model)));
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Remove a hero
        /// </summary>
        /// <param name="model"></param>        
        [HttpDelete]
        public async Task<ActionResult<int>> DeleteAsync(HeroViewModel model)
        {
            try
            {
                return Ok(await this.HeroRepository.DeleteAsync(this.Mapper.Map<Hero>(model)));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

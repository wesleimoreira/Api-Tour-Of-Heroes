using Api_Tour_Of_Heroes_Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IHeroRepositoty HeroRepository;
        protected readonly IMapper Mapper;

        public BaseController(IHeroRepositoty heroRepository, IMapper mapper)
        {
            this.HeroRepository = heroRepository;
            this.Mapper = mapper;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api_Tour_Of_Heroes_Domain.Interfaces;

namespace App_Tour_Of_Heroes_Apresentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IUserRepository UserRepository;
        protected readonly IHeroRepository HeroRepository;
        protected readonly IMapper Mapper;

        public BaseController(IUserRepository userRepository, IHeroRepository heroRepository, IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.HeroRepository = heroRepository;
            this.Mapper = mapper;
        }
    }
}

using AutoMapper;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Application.ViewModels;

namespace Api_Tour_Of_Heroes_Application.Mappings
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Hero, HeroViewModel>().ReverseMap();
        }
    }
}

using Api_Tour_Of_Heroes_Domain.Data;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;

namespace Api_Tour_Of_Heroes_Infrastructure.Repositories
{
    public class HeroRepository : Repository<Hero>, IHeroRepositoty
    {
        public HeroRepository(DataContext context) : base(context) { }
    }
}

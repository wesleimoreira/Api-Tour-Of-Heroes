using Api_Tour_Of_Heroes_Domain.Data;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;

namespace Api_Tour_Of_Heroes_Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}

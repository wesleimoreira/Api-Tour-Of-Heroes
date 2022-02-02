using Api_Tour_Of_Heroes_Domain.Data;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api_Tour_Of_Heroes_Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public virtual async Task<User> GetParameter(Expression<Func<User, bool>> expression)
        {
           return await this._context.Set<User>().AsNoTracking().FirstAsync(expression);
        }
    }
}

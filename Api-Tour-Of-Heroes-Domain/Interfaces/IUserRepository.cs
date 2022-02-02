using Api_Tour_Of_Heroes_Domain.Entities;
using System.Linq.Expressions;

namespace Api_Tour_Of_Heroes_Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetParameter(Expression<Func<User, bool>> expression);
    }
}

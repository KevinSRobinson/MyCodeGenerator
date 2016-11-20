#region

#region

using System;
using System.Collections.Generic;
using System.Linq;
using Data.Models;

#endregion

namespace Data.Repositories
{

    #endregion

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MvYoutContext _context;

        public UserRepository(MvYoutContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> GetByUserId(Guid userId)
        {
            return _context.Users.Where(x => x.UserId == userId);
        }
    }

    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetByUserId(Guid userId);
    }
}
		using System;
		using System.Collections.Generic;
		using System.Linq;
		using Data;
public class UserRepository : Repository<User>, IUserRepository
{
    private MvYoutContext _context;

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

		
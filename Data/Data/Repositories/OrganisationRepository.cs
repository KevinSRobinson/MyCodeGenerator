		using System;
		using System.Collections.Generic;
		using System.Linq;
		using Data;
public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
{
    private MvYoutContext _context;

    public OrganisationRepository(MvYoutContext context) : base(context)
    {
        _context = context;
    }

	public IEnumerable<Organisation> GetByUserId(Guid userId)
    {
        return _context.Organisations.Where(x => x.UserId == userId);
    }
   
}
public interface IOrganisationRepository : IRepository<Organisation>
{
    IEnumerable<Organisation> GetByUserId(Guid userId);
}

		
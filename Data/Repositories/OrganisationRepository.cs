#region

#region

using Data.Models;

#endregion

namespace Data.Repositories
{

    #endregion

    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        private MvYoutContext _context;

        public OrganisationRepository(MvYoutContext context) : base(context)
        {
            _context = context;
        }
    }

    public interface IOrganisationRepository : IRepository<Organisation>
    {
    }
}
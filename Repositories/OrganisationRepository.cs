using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
{
    private SamepleDbContext _context;

    public OrganisationRepository(SamepleDbContext context) : base(context)
    {
        _context = context;
    }

    	 

 
  
}


public interface IOrganisationRepository : IRepository<Organisation>
{
    
    	 
    
}


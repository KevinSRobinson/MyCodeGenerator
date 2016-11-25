using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class SampleDbContextRepository : Repository<SampleDbContext>, ISampleDbContextRepository
{
    private SamepleDbContext _context;

    public SampleDbContextRepository(SamepleDbContext context) : base(context)
    {
        _context = context;
    }

     

 
  
}


public interface ISampleDbContextRepository : IRepository<SampleDbContext>
{
    
 
    
}


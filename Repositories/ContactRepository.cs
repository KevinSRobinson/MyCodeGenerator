using System;
using System.Collections.Generic;
using System.Linq;
using Data;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    private SamepleDbContext _context;

    public ContactRepository(SamepleDbContext context) : base(context)
    {
        _context = context;
    }

    							   public IEnumerable<Contact> GetByUserId(Guid userId)
                            {
                                 return _context.Contacts.Where(x => x.UserId == userId);
                            }
						 

 
  
}


public interface IContactRepository : IRepository<Contact>
{
    
    							   IEnumerable<Contact> GetByUserId(Guid userId);
						 
    
}


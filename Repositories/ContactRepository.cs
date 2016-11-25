using Data;
using System;
using System.Collections.Generic;
using System.Linq;

public class ContactRepository : Repository<Contact>, IContactRepository
{
    private SampleDbContext _context;

    public ContactRepository(SampleDbContext context) : base(context)
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


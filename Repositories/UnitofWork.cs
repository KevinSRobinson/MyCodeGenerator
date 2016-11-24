












using System;
using Data;

public interface IUnitOfWork : IDisposable
{
   
    IOrganisationRepository Organisations{get; set;} 
IContactRepository Contacts{get; set;} 

	void Save();
}


public class UnitOfWork : IUnitOfWork
{
    private SamepleDbContext _context;

    public UnitOfWork(SamepleDbContext context)
    {
        _context = context;
    }

	//Delete this default constructor if using an IoC container
	public UnitOfWork()
	{
		_context = new SamepleDbContext();
	}
	
   
    
	public IOrganisationRepository Organisations
    {
        get { return new OrganisationRepository(_context); }
    }
	
	public IContactRepository Contacts
    {
        get { return new ContactRepository(_context); }
    }
	
    public void Save()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}

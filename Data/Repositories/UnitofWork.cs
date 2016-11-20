#region

#region

using System;

#endregion

namespace Data.Repositories
{

    #endregion

    public interface IUnitOfWork : IDisposable
    {
        IOrganisationRepository Organisations { get; }
        IUserRepository Users { get; }
        
        void Save();
    }


    public class UnitOfWork : IUnitOfWork
    {
        private MvYoutContext _context;

        public UnitOfWork(MvYoutContext context)
        {
            _context = context;
        }

        //Delete this default constructor if using an IoC container
        public UnitOfWork()
        {
            _context = new MvYoutContext();
        }



        public IOrganisationRepository Organisations
        {
            get { return new OrganisationRepository(_context); }
        }


        public IUserRepository Users
        {
            get { return new UserRepository(_context); }
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
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
        }
    }
}
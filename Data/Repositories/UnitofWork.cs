#region

#region

using System;

#endregion

namespace Data.Repositories
{

    #endregion

    public interface IUnitOfWork : IDisposable
    {
        IWhereIVolunteerRepository WhereIVolunteers { get; }

        IOrganisationRepository Organisations { get; }

        IReviewRepository Reviews { get; }

        IPlanOfActionRepository PlanOfActions { get; }

        ISelfAssessmentRepository SelfAssessments { get; }

        IUserRepository Users { get; }

        IAwardRepository Awards { get; }

        IValidateSkillRepository ValidateSkills { get; }

        IOpportunityRepository Opportunitys { get; }

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


        public IWhereIVolunteerRepository WhereIVolunteers
        {
            get { return new WhereIVolunteerRepository(_context); }
        }

        public IOrganisationRepository Organisations
        {
            get { return new OrganisationRepository(_context); }
        }

        public IReviewRepository Reviews
        {
            get { return new ReviewRepository(_context); }
        }

        public IPlanOfActionRepository PlanOfActions
        {
            get { return new PlanOfActionRepository(_context); }
        }

        public ISelfAssessmentRepository SelfAssessments
        {
            get { return new SelfAssessmentRepository(_context); }
        }

        public IUserRepository Users
        {
            get { return new UserRepository(_context); }
        }

        public IAwardRepository Awards
        {
            get { return new AwardRepository(_context); }
        }

        public IValidateSkillRepository ValidateSkills
        {
            get { return new ValidateSkillRepository(_context); }
        }

        public IOpportunityRepository Opportunitys
        {
            get { return new OpportunityRepository(_context); }
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
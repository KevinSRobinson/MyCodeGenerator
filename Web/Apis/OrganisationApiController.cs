		
using Dto.DtoRepos;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class OrganisationsApiController : ApiBase
    {
        private readonly IOrganisationDtoRepo _organisationDtoRepo;

		#region "constructors"
			 public OrganisationsApiController() 
			{
				_organisationDtoRepo = new OrganisationDtoRepo();
			}

			public OrganisationsApiController(IOrganisationDtoRepo OrganisationDtoRepo)
			{
				_organisationDtoRepo = OrganisationDtoRepo;
			}
		#endregion
       
	    


	   [Route("api/Organisations")]
	   public IHttpActionResult GetAllOrganisations()
        {
              return Ok(_organisationDtoRepo.GetAll());

        }

        
		[Route("api/Organisations/{id}")]
        public IHttpActionResult GetOrganisation(int id)
        {
           return Ok(_organisationDtoRepo.GetById(id));
        }
    }
}
	
		
		
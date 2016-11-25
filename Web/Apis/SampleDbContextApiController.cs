		
using Dto.DtoRepos;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class SampleDbContextsApiController : ApiBase
    {
        private readonly ISampleDbContextDtoRepo _sampleDbContextDtoRepo;

		#region "constructors"
			 public SampleDbContextsApiController() 
			{
				_sampleDbContextDtoRepo = new SampleDbContextDtoRepo();
			}

			public SampleDbContextsApiController(ISampleDbContextDtoRepo SampleDbContextDtoRepo)
			{
				_sampleDbContextDtoRepo = SampleDbContextDtoRepo;
			}
		#endregion
       
	    


	   [Route("api/SampleDbContexts")]
	   public IHttpActionResult GetAllSampleDbContexts()
        {
              return Ok(_sampleDbContextDtoRepo.GetAll());

        }

        
		[Route("api/SampleDbContexts/{id}")]
        public IHttpActionResult GetSampleDbContext(int id)
        {
           return Ok(_sampleDbContextDtoRepo.GetById(id));
        }
    }
}
	
		
		
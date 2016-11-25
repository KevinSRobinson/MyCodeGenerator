		
using Dto.DtoRepos;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class ContactsApiController : ApiBase
    {
        private readonly IContactDtoRepo _contactDtoRepo;

		#region "constructors"
			 public ContactsApiController() 
			{
				_contactDtoRepo = new ContactDtoRepo();
			}

			public ContactsApiController(IContactDtoRepo ContactDtoRepo)
			{
				_contactDtoRepo = ContactDtoRepo;
			}
		#endregion
       
	    


	   [Route("api/Contacts")]
	   public IHttpActionResult GetAllContacts()
        {
              return Ok(_contactDtoRepo.GetAll());

        }

        
		[Route("api/Contacts/{id}")]
        public IHttpActionResult GetContact(int id)
        {
           return Ok(_contactDtoRepo.GetById(id));
        }
    }
}
	
		
		
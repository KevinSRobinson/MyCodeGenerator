		
		using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Data;
using dtoNames;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class ContactsApiController : ApiBase
    {
        private readonly UnitOfWork _unitOfWork;

		#region "constructors"
			 public ContactsApiController() 
			{
				_unitOfWork = new UnitOfWork();
			}

			public ContactsApiController(UnitOfWork unitOfWork)
			{
				_unitOfWork = unitOfWork;
			}
		#endregion
       
	    private void MapContact(ref Contact contact, ref ContactDto contactDto)
        {
         
	contact.Id = contactDto.Id;
contact.FirstName = contactDto.FirstName;
contact.LastName = contactDto.LastName;
   
    
        }


	   [Route("api/GetAllContacts")]
		  public IHttpActionResult GetAllContacts()
        {
            try
            {
               var  contacts = _unitOfWork.Contacts.GetAll();
               var results =  contacts.Select(x => new ContactdtoName()
                {
					Id = x.Id,
FirstName = x.FirstName,
LastName = x.LastName,
                });
                   
                return Ok(results);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }

        }

		[HttpPost]
		[Route("api/AddContact")]
		public IHttpActionResult AddContact(ContactDto contactDto)
        {
            try
            {
                var contact = new Contact ();

				MapContact(ref  contact , ref contactDto);
				 

                _unitOfWork.Contacts.Add(contact);
                _unitOfWork.Save();

                contactDto.Id = contact.Id;
                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

		[HttpPost]
		[Route("api/ModifyContact")]
        public IHttpActionResult ModifyContact(ContactDto contactDto)
        {
            try
            {
                var contact= _unitOfWork.Contacts.GetById(contactDto.Id);
                 MapContact(ref contact, ref contactDto);

				contact.Id = contactDto.Id;
contact.FirstName = contactDto.FirstName;
contact.LastName = contactDto.LastName;
					
                _unitOfWork.Save();
                
                return Ok(contactDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

        
		[Route("api/GetContacts/{id}")]
        public IHttpActionResult GetContact(int id)
        {
            var contact = _unitOfWork.Contacts.GetById(id);

            var contactDto = new ContactdtoName()
            {

				Id=contact.Id,
FirstName=contact.FirstName,
LastName=contact.LastName,
            };

            return Ok(contactDto);
        }
    }
}
	
		
		



using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface IContactDtoRepo
    {
        ContactDto GetById(int id);
        IEnumerable<ContactDto> GetAll();        
    }

    public class ContactDtoRepo : IContactDtoRepo
    {
        private readonly IUnitOfWork _unitOfWork;


        public ContactDtoRepo()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ContactDtoRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        


      #region Public Methods


            public ContactDto GetById(int id)
            {
                try
                {
                    var Contact = _unitOfWork.Contacts.GetById(id);
                    var ContactDto = new ContactDto();
                  
                    return ContactDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build Modify ContactDto ", ex);
                }
            }


            public IEnumerable<ContactDto> GetAll()
            {
                try
                {
                   var Contacts = _unitOfWork.Contacts.GetAll();
                   var results =  Contacts.Select(x => new ContactDto()
                    {
					    Id = x.Id,
FirstName = x.FirstName,
LastName = x.LastName,
UserId = x.UserId,
          
                    });
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build AddContactDto Dto", ex);
                }
            }
     
            
      #endregion 


    
}
}		
		

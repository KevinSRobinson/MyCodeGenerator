


using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface IContactDtoRepo
    {
        IEnumerable<ContactDto> GetAllcontacts();
        IEnumerable<ContactDto> GetUsercontacts(Guid id);
        ContactDto Addcontact(ContactDto contactDto, Guid userId);
        void Modifycontact(ContactDto contactDto);
        ContactDto Getcontact(int id);
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


        #region Mappers
        private void MapContact(ref Contact Contact, ref ContactDto contactDto)
        {
           	Contact.Id = contactDto.Id;
Contact.FirstName = contactDto.FirstName;
Contact.LastName = contactDto.LastName;
Contact.UserId = contactDto.UserId;
   
        }

        private void Mapcontact(ref ContactDto contactDto, ref Contact contact)
        {
          	contactDto.Id = contactDto.Id;
contactDto.FirstName = contactDto.FirstName;
contactDto.LastName = contactDto.LastName;
contactDto.UserId = contactDto.UserId;
          

        }

        #endregion 
        


      #region Public Methods


            public ContactDto Getcontact(int id)
            {
                try
                {
                    var Contact = _unitOfWork.contacts.GetById(id);
                    var contactDto = new ContactDto();
                    Mapcontact(ref contactDto, ref Contact);

                    return contactDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build Modify ContactDto ", ex);
                }
            }


            public IEnumerable<ContactDto> GetAllContacts()
            {
                try
                {
                   var Contacts = _unitOfWork.contacts.GetAll();
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
		



using Data;
using Dtos;
using Functional.Maybe;
using System;
using System.Collections.Generic;
using System.Linq;

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
            }

            private void Mapcontact(ref ContactDto contactDto, ref Contact contact)
            {
                contactDto.Id = contactDto.Id;
                contactDto.FirstName = contactDto.FirstName;
                contactDto.LastName = contactDto.LastName;
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
                throw new Exception("Failed to Build Modify contact Dto", ex);
            }
        }



        
        public Maybe<IEnumerable<ContactDto>> GetAllContacts()
        {

            var contacts = _unitOfWork.contacts.GetAll().ToMaybe();

            //
            if (contacts.HasValue())
            {
                return contacts.Select(x => new ContactDto()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                });
            }
            else
            {
                return Maybe<IEnumerable<ContactDto>>.Nothing;
            }
        }




        public Maybe<IEnumerable<ContactDto>> GetAllContacts1()
        {

            var contacts = _unitOfWork.contacts.GetAll().ToMaybe();

           
                            
            if (contacts.HasValue())
            {
                try
                {
                    return contacts.Value.Select(x => new ContactDto()
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                    });
                }
                catch (NullReferenceException nullReferenceException)
                {
                    throw new NullReferenceException("Something is null but I dont know what", nullReferenceException);
                }
                catch (Exception ex)
                {
                    throw new Exception("Something else happened", ex);
                }
            }
            else
            {
                return Maybe<IEnumerable<ContactDto>>.Nothing;
            }
        }



        #endregion


    }
}



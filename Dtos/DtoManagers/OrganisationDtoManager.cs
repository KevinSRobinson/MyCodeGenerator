



using Data.Models;
using Data.Repositories;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Dto.DtoRepos
{
    public interface IOrganisationDtoRepo
    {
        void MapOrganisation(ref Organisation OrganisationDto, ref OrganisationDto organisationDto);
        IEnumerable<OrganisationDto> GetAllOrganisations();

        OrganisationDto AddOrganisation(OrganisationDto organisationDto, Guid userId);
        void ModifyOrganisation(OrganisationDto organisationDto);
        OrganisationDto GetOrganisation(int id);
    }

    public class OrganisationDtoRepo : IOrganisationDtoRepo
    {
        private readonly IUnitOfWork _unitOfWork;


        public OrganisationDtoRepo()
        {
            _unitOfWork = new UnitOfWork();
        }

        public OrganisationDtoRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void MapOrganisation(ref Organisation organisation, ref OrganisationDto organisationDto)
        {
            organisation.Id = organisationDto.Id;
            organisation.OrgGuid = organisationDto.OrgGuid;
            organisation.OldId = organisationDto.OldId;
            organisation.OrganisationAdmin = organisationDto.OrganisationAdmin;
            organisation.OrganisationName = organisationDto.OrganisationName;
            organisation.Address1 = organisationDto.Address1;
            organisation.Address2 = organisationDto.Address2;
            organisation.ContactForename = organisationDto.ContactForename;
            organisation.ContactSurname = organisationDto.ContactSurname;
            organisation.Postcode = organisationDto.Postcode;
            organisation.Town = organisationDto.Town;
            organisation.Email = organisationDto.Email;
            organisation.Active = organisationDto.Active;
            organisation.Tel = organisationDto.Tel;

        }

        public void MapOrganisation(ref OrganisationDto organisation, ref Organisation organisationDto)
        {
            organisation.Id = organisationDto.Id;
            organisation.OrgGuid = organisationDto.OrgGuid;
            organisation.OldId = organisationDto.OldId;
            organisation.OrganisationAdmin = organisationDto.OrganisationAdmin;
            organisation.OrganisationName = organisationDto.OrganisationName;
            organisation.Address1 = organisationDto.Address1;
            organisation.Address2 = organisationDto.Address2;
            organisation.ContactForename = organisationDto.ContactForename;
            organisation.ContactSurname = organisationDto.ContactSurname;
            organisation.Postcode = organisationDto.Postcode;
            organisation.Town = organisationDto.Town;
            organisation.Email = organisationDto.Email;
            organisation.Active = organisationDto.Active;
            organisation.Tel = organisationDto.Tel;

        }

        public IEnumerable<OrganisationDto> GetAllOrganisations()
        {
            try
            {
                var organisations = _unitOfWork.Organisations.GetAll();
                var results = organisations.Select(x => new OrganisationDto()
                {
                    Id = x.Id,
                    OrgGuid = x.OrgGuid,
                    OldId = x.OldId,
                    OrganisationAdmin = x.OrganisationAdmin,
                    OrganisationName = x.OrganisationName,
                    Address1 = x.Address1,
                    Address2 = x.Address2,
                    ContactForename = x.ContactForename,
                    ContactSurname = x.ContactSurname,
                    Postcode = x.Postcode,
                    Town = x.Town,
                    Email = x.Email,
                    Active = x.Active,
                    Tel = x.Tel,
                });
                return results;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build AddOrganisation Dto", ex);
            }
        }



        public OrganisationDto AddOrganisation(OrganisationDto organisationDto, Guid userId)
        {
            try
            {
                var organisation = new Organisation();

                MapOrganisation(ref organisation, ref organisationDto);


                _unitOfWork.Organisations.Add(organisation);
                _unitOfWork.Save();

                organisationDto.Id = organisation.Id;
                return organisationDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build AddOrganisation Dto", ex);
            }
        }

        public void ModifyOrganisation(OrganisationDto organisationDto)
        {
            try
            {
                var organisation = _unitOfWork.Organisations.GetById(organisationDto.Id);
                MapOrganisation(ref organisation, ref organisationDto);

                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build Modify Organisation Dto", ex);
            }
        }

        public OrganisationDto GetOrganisation(int id)
        {
            try
            {
                var organisation = _unitOfWork.Organisations.GetById(id);
                var organisationDto = new OrganisationDto();
                MapOrganisation(ref organisationDto, ref organisation);

                return organisationDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Build Modify Organisation Dto", ex);
            }
        }
    }
}



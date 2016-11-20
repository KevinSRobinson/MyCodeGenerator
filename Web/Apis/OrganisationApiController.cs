
using Data.Models;
using Data.Repositories;
using Dtos;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace Api
{
    [EnableCors("*", "*", "*")]
    public class OrganisationsApiController : ApiBase
    {
        private readonly UnitOfWork _unitOfWork;

        #region "constructors"
        public OrganisationsApiController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public OrganisationsApiController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        private void MapOrganisation(ref Organisation organisation, ref OrganisationDto organisationDto)
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


        [Route("api/GetAllOrganisations")]
        public IHttpActionResult GetAllOrganisations()
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

                return Ok(results);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }

        }

        [HttpPost]
        [Route("api/AddOrganisation")]
        public IHttpActionResult AddOrganisation(OrganisationDto organisationDto)
        {
            try
            {
                var organisation = new Organisation();

                MapOrganisation(ref organisation, ref organisationDto);


                _unitOfWork.Organisations.Add(organisation);
                _unitOfWork.Save();

                organisationDto.Id = organisation.Id;
                return Ok(organisationDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

        [HttpPost]
        [Route("api/ModifyOrganisation")]
        public IHttpActionResult ModifyOrganisation(OrganisationDto organisationDto)
        {
            try
            {
                var organisation = _unitOfWork.Organisations.GetById(organisationDto.Id);
                MapOrganisation(ref organisation, ref organisationDto);

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

                _unitOfWork.Save();

                return Ok(organisationDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }


        [Route("api/GetOrganisations/{id}")]
        public IHttpActionResult GetOrganisation(int id)
        {
            var organisation = _unitOfWork.Organisations.GetById(id);

            var organisationDto = new OrganisationDto()
            {

                Id = organisation.Id,
                OrgGuid = organisation.OrgGuid,
                OldId = organisation.OldId,
                OrganisationAdmin = organisation.OrganisationAdmin,
                OrganisationName = organisation.OrganisationName,
                Address1 = organisation.Address1,
                Address2 = organisation.Address2,
                ContactForename = organisation.ContactForename,
                ContactSurname = organisation.ContactSurname,
                Postcode = organisation.Postcode,
                Town = organisation.Town,
                Email = organisation.Email,
                Active = organisation.Active,
                Tel = organisation.Tel,
            };

            return Ok(organisationDto);
        }
    }
}



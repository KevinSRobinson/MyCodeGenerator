		
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
         
	organisation.Name = organisationDto.Name;
   
    
        }


	   [Route("api/GetAllOrganisations")]
		  public IHttpActionResult GetAllOrganisations()
        {
            try
            {
               var  organisations = _unitOfWork.Organisations.GetAll();
               var results =  organisations.Select(x => new OrganisationdtoName()
                {
					Name = x.Name,
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
                var organisation = new Organisation ();

				MapOrganisation(ref  organisation , ref organisationDto);
				 

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
                var organisation= _unitOfWork.Organisations.GetById(organisationDto.Id);
                 MapOrganisation(ref organisation, ref organisationDto);

				organisation.Name = organisationDto.Name;
					
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

            var organisationDto = new OrganisationdtoName()
            {

				Name=organisation.Name,
            };

            return Ok(organisationDto);
        }
    }
}
	
		
		
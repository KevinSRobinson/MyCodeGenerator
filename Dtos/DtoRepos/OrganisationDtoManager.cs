
















using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface IOrganisationDtoRepo
    {
        IEnumerable<OrganisationDto> GetAllorganisations();
        IEnumerable<OrganisationDto> GetUserorganisations(Guid id);
        OrganisationDto Addorganisation(OrganisationDto organisationDto, Guid userId);
        void Modifyorganisation(OrganisationDto organisationDto);
        OrganisationDto Getorganisation(int id);
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


        #region Mappers
        private void MapOrganisation(ref Organisation Organisation, ref OrganisationDto organisationDto)
        {
           	Organisation.Name = organisationDto.Name;
   
        }

        private void Maporganisation(ref OrganisationDto organisationDto, ref Organisation organisation)
        {
          	organisationDto.Name = organisationDto.Name;
          

        }

        #endregion 
        


      #region Public Methods


            public OrganisationDto Getorganisation(int id)
            {
                try
                {
                    var Organisation = _unitOfWork.organisations.GetById(id);
                    var organisationDto = new OrganisationDto();
                    Maporganisation(ref organisationDto, ref Organisation);

                    return organisationDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build Modify organisation Dto", ex);
                }
            }


            public IEnumerable<OrganisationDto> GetAllOrganisations()
            {
                try
                {
                   var Organisations = _unitOfWork.organisations.GetAll();
                   var results =  Organisations.Select(x => new OrganisationDtoDto()
                    {
					    Name = x.Name,
                    });
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build AddOrganisationDto Dto", ex);
                }
            }
     

      #endregion 


    
}
		
		

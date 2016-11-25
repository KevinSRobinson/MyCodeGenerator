


using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface IOrganisationDtoRepo
    {
        OrganisationDto GetById(int id);
        IEnumerable<OrganisationDto> GetAll();        
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

      
        


      #region Public Methods


            public OrganisationDto GetById(int id)
            {
                try
                {
                    var Organisation = _unitOfWork.Organisations.GetById(id);
                    var OrganisationDto = new OrganisationDto();
                  
                    return OrganisationDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build Modify OrganisationDto ", ex);
                }
            }


            public IEnumerable<OrganisationDto> GetAll()
            {
                try
                {
                   var Organisations = _unitOfWork.Organisations.GetAll();
                   var results =  Organisations.Select(x => new OrganisationDto()
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
}		
		

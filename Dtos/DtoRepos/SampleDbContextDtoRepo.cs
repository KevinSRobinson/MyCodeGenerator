


using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Dtos;
namespace Dto.DtoRepos
{
    public interface ISampleDbContextDtoRepo
    {
        SampleDbContextDto GetById(int id);
        IEnumerable<SampleDbContextDto> GetAll();        
    }

    public class SampleDbContextDtoRepo : ISampleDbContextDtoRepo
    {
        private readonly IUnitOfWork _unitOfWork;


        public SampleDbContextDtoRepo()
        {
            _unitOfWork = new UnitOfWork();
        }

        public SampleDbContextDtoRepo(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
        


      #region Public Methods


            public SampleDbContextDto GetById(int id)
            {
                try
                {
                    var SampleDbContext = _unitOfWork.SampleDbContexts.GetById(id);
                    var SampleDbContextDto = new SampleDbContextDto();
                  
                    return SampleDbContextDto;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build Modify SampleDbContextDto ", ex);
                }
            }


            public IEnumerable<SampleDbContextDto> GetAll()
            {
                try
                {
                   var SampleDbContexts = _unitOfWork.SampleDbContexts.GetAll();
                   var results =  SampleDbContexts.Select(x => new SampleDbContextDto()
                    {
					    Organisations = x.Organisations,
Contacts = x.Contacts,
          
                    });
                    return results;
                }
                catch (Exception ex)
                {
                    throw new Exception("Failed to Build AddSampleDbContextDto Dto", ex);
                }
            }
     
            
      #endregion 


    
}
}		
		

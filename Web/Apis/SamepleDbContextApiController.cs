		
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
    public class SamepleDbContextsApiController : ApiBase
    {
        private readonly UnitOfWork _unitOfWork;

		#region "constructors"
			 public SamepleDbContextsApiController()
			{
				_unitOfWork = new UnitOfWork();
			}

			public SamepleDbContextsApiController(UnitOfWork unitOfWork)
			{
				_unitOfWork = unitOfWork;
			}
		#endregion
       
	    private void MapSamepleDbContext(ref SamepleDbContext samepleDbContext, ref SamepleDbContextDto samepleDbContextDto)
        {
         
	samepleDbContext.Organisations = samepleDbContextDto.Organisations;
samepleDbContext.Contacts = samepleDbContextDto.Contacts;
   
    
        }


	   [Route("api/GetAllSamepleDbContexts")]
		  public IHttpActionResult GetAllSamepleDbContexts()
        {
            try
            {
               var  samepleDbContexts = _unitOfWork.SamepleDbContexts.GetAll();
               var results =  samepleDbContexts.Select(x => new SamepleDbContextdtoName()
                {
					Organisations = x.Organisations,
Contacts = x.Contacts,
                });
                   
                return Ok(results);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }

        }

		[HttpPost]
		[Route("api/AddSamepleDbContext")]
		public IHttpActionResult AddSamepleDbContext(SamepleDbContextDto samepleDbContextDto)
        {
            try
            {
                var samepleDbContext = new SamepleDbContext ();

				MapSamepleDbContext(ref  samepleDbContext , ref samepleDbContextDto);
				 

                _unitOfWork.SamepleDbContexts.Add(samepleDbContext);
                _unitOfWork.Save();

                samepleDbContextDto.Id = samepleDbContext.Id;
                return Ok(samepleDbContextDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

		[HttpPost]
		[Route("api/ModifySamepleDbContext")]
        public IHttpActionResult ModifySamepleDbContext(SamepleDbContextDto samepleDbContextDto)
        {
            try
            {
                var samepleDbContext= _unitOfWork.SamepleDbContexts.GetById(samepleDbContextDto.Id);
                 MapSamepleDbContext(ref samepleDbContext, ref samepleDbContextDto);

				samepleDbContext.Organisations = samepleDbContextDto.Organisations;
samepleDbContext.Contacts = samepleDbContextDto.Contacts;
					
                _unitOfWork.Save();
                
                return Ok(samepleDbContextDto);
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, this);
            }
        }

        
		[Route("api/GetSamepleDbContexts/{id}")]
        public IHttpActionResult GetSamepleDbContext(int id)
        {
            var samepleDbContext = _unitOfWork.SamepleDbContexts.GetById(id);

            var samepleDbContextDto = new SamepleDbContextdtoName()
            {

				Organisations=samepleDbContext.Organisations,
Contacts=samepleDbContext.Contacts,
            };

            return Ok(samepleDbContextDto);
        }
    }
}
	
		
		
using CarRental.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MakerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;    
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var makerList = _unitOfWork.Maker.GetAll();
            return Ok(makerList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            var maker = _unitOfWork.Maker.Get(u=> u.Id == id);
            if(maker == null)
            {
                return NotFound();  
            }
            return Ok(maker);
        }
    }
}

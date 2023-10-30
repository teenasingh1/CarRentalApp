using CarRental.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var modelList = _unitOfWork.Model.GetAll();
            return Ok(modelList);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var model = _unitOfWork.Model.Get(u => u.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}

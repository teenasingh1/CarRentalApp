using CarRental.Api.Models;
using CarRental.Api.Models.Request;
using CarRental.Api.Models.Response;
using CarRental.DataAccess.Repository.IRepository;
using CarRental.Models.Models;
using CarRental.Models.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        [HttpGet]
        // [FromQuery] attribute specifies that the query parameters should be bound from the URL query string
        public async Task<IActionResult> GetAll([FromQuery] int makerId=-1,[FromQuery] int modelId = -1, [FromQuery] int rentalPrice=-1)
        {
            IEnumerable<Car> carList = _unitOfWork.Car.GetAll(includeProperties: "Maker,Model");
            //to see if the modelId query parameter is not equal to -1. If it is not, the code filters the carList variable to only
            //include the cars that have the specified model ID
            if (makerId != -1)
            {
                carList = carList.Where(u => u.MakerId == makerId);
            }
            if (modelId != -1)
            {
                carList = carList.Where(u => u.ModelId == modelId);
            }
            if (rentalPrice != -1)
            {
                carList = carList.Where(u => u.RentalPrice <= rentalPrice);
            }


            IEnumerable<GetCarResponse> response = carList.Select(car =>
            {
                var agreementListIncludingParticularCar = _unitOfWork.Agreement.GetAll(a => a.CarId == car.Id);
                bool agreement=agreementListIncludingParticularCar.Any((a) => a.AgreementStatus != AgreementStatusEnum.Closed);
                return new GetCarResponse(
                car.Id,
                car.Name,
                car.Maker,
                car.Model,
                car.RentalPrice,
                car.CarImage,
                //agreement variable is true, the expression evaluates to AgreementStatusEnum.Active.
                //If the agreement variable is false, the expression evaluates to AgreementStatusEnum.Closed.
                agreement ? AgreementStatusEnum.Active  : AgreementStatusEnum.Closed
                );
            });
            
            return Ok(response); 
        }
       

        [HttpGet]
        [Route("{id}")]
        
        public async Task<IActionResult> GetCar([FromRoute] string id )
        {
            var car = _unitOfWork.Car.Get(c => c.Id == id, includeProperties: "Maker,Model");
            var agreement = _unitOfWork.Agreement.Get(a => a.CarId == car.Id);
            GetCarResponse response = new GetCarResponse
            ( 
                 car.Id,
                 car.Name,
                 car.Maker,
                 car.Model,
                 car.RentalPrice,   
                 car.CarImage,
                 agreement != null ? agreement.AgreementStatus : AgreementStatusEnum.Closed
            );
            
            if (car == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CreateCarRequest request)
        {
            Car car = new Car
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                MakerId = request.MakerId,
                ModelId = request.ModelId,
                RentalPrice = request.RentalPrice,
                CarImage = request.CarImage
            };
            _unitOfWork.Car.Add(car);
            _unitOfWork.Save();
            return Ok(car);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCar([FromBody]UpdateCarRequest request)
        {
            Car car= _unitOfWork.Car.Get(c=>c.Id == request.Id);
            if (car != null)
            {
                car.Name = request.Name;
                car.MakerId = request.MakerId;
                car.ModelId = request.ModelId;
                car.RentalPrice = request.RentalPrice;
                car.CarImage = request.CarImage;
                _unitOfWork.Car.Update(car);
                _unitOfWork.Save();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCar([FromBody] UpdateCarRequest request)
        {
            Car car = _unitOfWork.Car.Get(c => c.Id == request.Id);
            if (car != null)
            {
                Agreement agreement =_unitOfWork.Agreement.Get(a => a.CarId == car.Id);
                if(agreement != null)
                {
                    _unitOfWork.Agreement.Remove(agreement);
                }
                _unitOfWork.Car.Remove(car);
                _unitOfWork.Save();
            }
            return NotFound();
        }
    }
}

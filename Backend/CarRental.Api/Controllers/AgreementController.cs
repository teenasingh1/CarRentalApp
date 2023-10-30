using CarRental.Api.Models.Request;
using CarRental.Api.Models.Response;
using CarRental.DataAccess.Repository.IRepository;
using CarRental.Models.Models;
using CarRental.Models.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CarRental.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;   
        private readonly UserManager<ApplicationUser> _userManager; 
        public AgreementController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        //uses the _unitOfWork object to get all of the agreements from the database
        public async Task<IActionResult> GetAll() 
        {
            IEnumerable<Agreement> agreementList = _unitOfWork.Agreement.GetAll();
            if (agreementList != null)
            {
                IEnumerable<GetAgreementResponse> response = agreementList.Select(a => {

                    Car car = _unitOfWork.Car.Get(c => c.Id == a.CarId,includeProperties:"Model,Maker");

                    return new GetAgreementResponse(
                        a.Id,
                        new GetCarResponse(
                        car.Id,
                        car.Name,
                        car.Maker,
                        car.Model,
                        car.RentalPrice,
                        car.CarImage,
                        null
                        ),
                        a.StartDate,
                        a.EndDate,
                        a.TotalCost,
                        a.AgreementStatus
                    );
                });
                return Ok(response);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("user-agreements")]
        [Authorize]
        public async Task<IActionResult> GetUserAgreements()
        {
           
            IEnumerable<Agreement> agreementList = _unitOfWork.Agreement.GetAll();
            //get the ID of the current user 
            //then filters the agreementList variable to only include the agreements that are associated with the current user.
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            agreementList = agreementList.Where(a => a.ApplicationUserId == userId );

            if (agreementList != null)
            {
                IEnumerable<GetAgreementResponse> response = agreementList.Select(a => {
                    Car car = _unitOfWork.Car.Get(c => c.Id == a.CarId, includeProperties: "Model,Maker");
                    return new GetAgreementResponse(
                        a.Id,
                        new GetCarResponse(
                        car.Id,
                        car.Name,
                        car.Maker,
                        car.Model,
                        car.RentalPrice,
                        car.CarImage,
                        null
                        ),
                        a.StartDate,
                        a.EndDate,
                        a.TotalCost,
                        a.AgreementStatus
                    );
                });
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var agreement = _unitOfWork.Agreement.Get(u=>u.Id==id,includeProperties:"Car");
            Car car = _unitOfWork.Car.Get(c => c.Id == agreement.CarId,includeProperties:"Model,Maker");
            if (agreement != null)
            {
                var response = new GetAgreementResponse(
                   agreement.Id,
                    new GetCarResponse(
                        car.Id,
                        car.Name,
                        car.Maker,
                        car.Model,
                        car.RentalPrice,
                        car.CarImage,
                        null
                        ),
                   agreement.StartDate,
                   agreement.EndDate,
                   agreement.TotalCost,
                   agreement.AgreementStatus
                   );

                return Ok(response);
            }
            return NotFound();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAgreement([FromBody] CreateAgreementRequest request)
        {
            //This line gets the ID of the current user.
            string userId = User.Claims.First(c => c.Type == "UserID").Value;

            var agreement = new Agreement
            {
                Id = Guid.NewGuid().ToString(),
                CarId = request.CarId,
                Car = null,
                ApplicationUserId = userId,
                ApplicationUser = null,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalCost = request.TotalCost,
                AgreementStatus= AgreementStatusEnum.Active
            };

            //This line adds the new Agreement object to the unit of work.
            _unitOfWork.Agreement.Add(agreement);
            _unitOfWork.Save();
            return Ok(agreement);
        }


        [HttpPut]
        [Authorize]
        //{id} parameter in the route specifies the ID of the agreement that the return request is for
        [Route("return-request/{id}")]
        public async Task<IActionResult> HandleReturnRequest([FromBody] ReturnRequest request, [FromRoute] string id)
        {

            var agreement = _unitOfWork.Agreement.Get(u => u.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }
            //to see if the booking status in the request is valid. If the booking status is invalid,
            //the method returns a BadRequest() result with the message "Invalid Booking Status"
            if (!Enum.TryParse<AgreementStatusEnum>(request.AgreementStatus, out var parsedAgreementStatus))
            {
                return BadRequest("Invalid Booking Status");
            }

            agreement.AgreementStatus = parsedAgreementStatus;

            _unitOfWork.Agreement.Update(agreement);
            _unitOfWork.Save();
            return Ok(agreement);

        }


        [HttpPut]
        [Authorize]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAgreement([FromBody] UpdateAgreementRequest request, [FromRoute] string id)
        {
            var agreement = _unitOfWork.Agreement.Get(u => u.Id == id);
            
            if (agreement == null)
            {
                return NotFound();
            }

            agreement.StartDate = request.StartDate;
            agreement.EndDate=request.EndDate;
            agreement.TotalCost = request.TotalCost;
            _unitOfWork.Agreement.Update(agreement);
            _unitOfWork.Save();
            return Ok(agreement);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveAgreement([FromRoute] string id)
        {
            var agreement = _unitOfWork.Agreement.Get(u => u.Id == id);
            if (agreement == null)
            {
                return NotFound();
            }

            _unitOfWork.Agreement.Remove(agreement);
            _unitOfWork.Save();
            return Ok(agreement);
        }
    }
}

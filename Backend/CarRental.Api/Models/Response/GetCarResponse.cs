using CarRental.Models.Models;
using CarRental.Models.Models.Enums;

namespace CarRental.Api.Models.Response
{
    public record GetCarResponse
    (
        string Id,
        string Name,
        Maker Maker,
        Model Model,
        int RentalPrice,
        string CarImage,
        AgreementStatusEnum? AgreementStatus  
    );
}

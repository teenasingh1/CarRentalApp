using CarRental.Models.Models;
using CarRental.Models.Models.Enums;

namespace CarRental.Api.Models.Response
{
    public record GetAgreementResponse
    (
        string Id,
        GetCarResponse Car,
        DateTime StartDate,
        DateTime EndDate,
        int TotalCost,
        AgreementStatusEnum AgreementStatus
    );
}

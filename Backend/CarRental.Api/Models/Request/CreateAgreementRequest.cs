using CarRental.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Api.Models.Request
{
    public record CreateAgreementRequest
    (
        string CarId,

        DateTime StartDate,
        
        DateTime EndDate,

        int TotalCost
    );
}

using CarRental.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarRental.Models.Models.Enums;

namespace CarRental.Api.Models.Request
{
    public record ReturnRequest
    (
        string AgreementStatus,
        //nullable type
        DateTime? ReturnRequestDate
    );
}

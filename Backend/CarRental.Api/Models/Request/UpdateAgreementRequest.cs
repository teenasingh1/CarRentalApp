namespace CarRental.Api.Models.Request
{
    public record UpdateAgreementRequest
    (

        DateTime StartDate,

        DateTime EndDate,

        int TotalCost
        
    );
}

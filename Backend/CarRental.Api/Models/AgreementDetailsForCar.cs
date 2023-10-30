namespace CarRental.Api.Models
{
    public record AgreementDetailsForCar(
        string Id,
        DateTime StartDate,
        DateTime EndDate,
        int TotalCost,
        DateTime? ReturnRequest
        );
}

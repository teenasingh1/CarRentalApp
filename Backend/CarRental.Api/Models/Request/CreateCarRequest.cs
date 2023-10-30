﻿using CarRental.Models.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Api.Models.Request
{
    public record CreateCarRequest
    (
        string Name,
        int MakerId,
        int ModelId,
        int RentalPrice,
        string? CarImage
    );
}

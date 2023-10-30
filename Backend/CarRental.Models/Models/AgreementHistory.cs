using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class AgreementHistory
    {
        [Key] public string Id { get; set; }

        [Required] public string CarId { get; set; }

        [Required] public string CarName { get; set; }

        [Required] public string CarModel { get; set; }

        [Required] public string CarMaker { get; set; }

        [Required] public string CarImage { get; set; }

        [Required] public string ApplicationUserId { get; set;}

        [Required] public DateTime StartDate { get; set;}

        [Required] public DateTime EndDate { get; set;}

        public int TotalCost { get; set;}

    }
}

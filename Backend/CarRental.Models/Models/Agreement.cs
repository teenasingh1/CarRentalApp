using CarRental.Models.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class Agreement
    {
        public string Id { get; set; }

        [Required] public string CarId { get; set; }
        [ForeignKey("CarId")]
        //navigation prop car
        public Car? Car { get; set; }

        [Required] public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser{ get; set; }

        [Required]public DateTime StartDate { get; set; }

        [Required]public DateTime EndDate { get; set; }

        public int TotalCost { get; set; }

        public AgreementStatusEnum AgreementStatus { get; set; }

    }
}

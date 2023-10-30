using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class Car
    {
        [Key] public string Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public int MakerId { get; set; }

        [ForeignKey("MakerId")]
        public Maker Maker {get; set;}

        [Required] public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        public Model Model { get; set; }
        [Required] public int RentalPrice { get; set; }
        public string? CarImage { get; set; }
 
    }
}

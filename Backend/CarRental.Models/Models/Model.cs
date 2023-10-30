using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ModelName { get; set; }
    }
}

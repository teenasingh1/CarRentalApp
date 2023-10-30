using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class Maker
    {
        [Key]
        public int Id { get; set; }  
        
        [Required]
        public string MakerName { get; set; }  

    }
}

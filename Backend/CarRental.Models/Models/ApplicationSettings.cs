using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Models
{
    public class ApplicationSettings
    {
        //The JWT secret is a string that is used to sign and validate JWT tokens.
        public string JWT_Secret { get; set; }  
        public string Client_URL { get; set; }
    }
}

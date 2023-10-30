using CarRental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Repository.IRepository
{
    public interface IMakerRepository : IRepository<Maker>
    {
        void Update(Maker obj);
    }
}

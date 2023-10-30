using CarRental.DataAccess.Data;
using CarRental.DataAccess.Repository.IRepository;
using CarRental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Repository
{
    public class AgreementRepository : Repository<Agreement> ,IAgreementRepository
    {
        private readonly ApplicationDbContext _db;
        public AgreementRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Agreement obj)
        {
            _db.Agreements.Update(obj);
        }
    }
}

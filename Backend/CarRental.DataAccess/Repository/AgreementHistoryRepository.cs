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
    public class AgreementHistoryRepository : Repository<AgreementHistory> ,IAgreementHistoryRepository
    {
        private readonly ApplicationDbContext _db;
        public AgreementHistoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(AgreementHistory obj)
        {
            _db.AgreementHistories.Update(obj);
        }
    }
}

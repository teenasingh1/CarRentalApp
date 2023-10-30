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
    public class MakerRepository : Repository<Maker>, IMakerRepository
    {
        private readonly ApplicationDbContext _db;
        public MakerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Maker obj)
        {
            _db.Makers.Update(obj);
        }
    }
}

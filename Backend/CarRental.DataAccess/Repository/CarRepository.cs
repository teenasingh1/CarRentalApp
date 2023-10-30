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
    public class CarRepository : Repository<Car> ,ICarRepository
    {
        private readonly ApplicationDbContext _db;
        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Car obj)
        {
            _db.Cars.Update(obj);
        }
    }
}

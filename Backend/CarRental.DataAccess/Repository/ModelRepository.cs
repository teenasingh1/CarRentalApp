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
    public class ModelRepository : Repository<Model> , IModelRepository
    {
        private readonly ApplicationDbContext _db;
        public ModelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Model obj)
        {
            _db.Models.Update(obj);
        }
    }
}

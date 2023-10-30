using CarRental.DataAccess.Data;
using CarRental.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICarRepository Car { get; set; }

        public IAgreementRepository Agreement { get; set; } 
        public IModelRepository Model { get; set; } 
        public IMakerRepository Maker { get; set; } 
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;

            Car = new CarRepository(_db);
            Agreement = new AgreementRepository(_db);
            Model = new ModelRepository(_db);
            Maker = new MakerRepository(_db);   
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

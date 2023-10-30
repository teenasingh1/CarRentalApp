using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICarRepository Car { get; }
        IAgreementRepository Agreement { get; } 
        IMakerRepository Maker { get; }
        IModelRepository Model { get; } 
        void Save();
    }
}

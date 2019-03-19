using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEWS.Entity;
using ProjectEWS.Interface;

namespace ProjectEWS.Service
{
    public class MasterService : IMasterService
    {
        UnitOfWork.UnitOfWork _unitOfWork = new UnitOfWork.UnitOfWork();
        public DbSet<Master> Custom()
        {
            return _unitOfWork.MasterRepository.Custom();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Master> Get()
        {
            return _unitOfWork.MasterRepository.Get();
        }

        public Master GetByID(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Master master)
        {
            throw new NotImplementedException();
        }

        public void Update(Master master)
        {
            throw new NotImplementedException();
        }
    }
}

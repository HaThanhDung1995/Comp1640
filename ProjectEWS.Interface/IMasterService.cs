using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEWS.Entity;

namespace ProjectEWS.Interface
{
    public interface IMasterService
    {
        IEnumerable<Master> Get();
        Master GetByID(int Id);
        void Insert(Master master);
        void Update(Master master);
        void Delete(int Id);
        DbSet<Master> Custom();
    }
}

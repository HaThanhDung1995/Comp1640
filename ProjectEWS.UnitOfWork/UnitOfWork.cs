using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEWS.Entity;
using ProjectEWS.Repository;

namespace ProjectEWS.UnitOfWork
{
    public class UnitOfWork
    {
        private DataContext _context = new DataContext();
        private GenericRepository<Master> masterRepository;
        private GenericRepository<Role> roleRepository;
        private GenericRepository<MasterRole> masterRoleRepository;

        public GenericRepository<Master> MasterRepository
        {
            get
            {
                if (this.masterRepository == null)
                {
                    this.masterRepository = new GenericRepository<Master>(_context);
                }
                return masterRepository;
            }
        }
        public GenericRepository<Role> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<Role>(_context);
                }
                return roleRepository;
            }
        }
        public GenericRepository<MasterRole> MasterRoleRepository
        {
            get
            {
                if (this.masterRoleRepository == null)
                {
                    this.masterRoleRepository = new GenericRepository<MasterRole>(_context);
                }
                return masterRoleRepository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

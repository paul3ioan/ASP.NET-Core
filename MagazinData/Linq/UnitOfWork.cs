using System;
using System.Collections.Generic;
using System.Text;
namespace MagazinData
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DepozitContext _depozitContext;
        public UnitOfWork(DepozitContext depozitContext)
        {
            _depozitContext = depozitContext;
        }
        public void Commit()
        {
            _depozitContext.SaveChanges();
        }
    }
}

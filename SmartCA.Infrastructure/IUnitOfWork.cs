using SmartCA.Infrastructure.DomainBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure
{
    public interface IUnitOfWork
    {
        void RegisterAdd(EntityBase entity, IUnitOfWorkRepository reporitory);
        void RegisterChanged(EntityBase entity, IUnitOfWorkRepository reporitory);
        void RegisterRemoved(EntityBase entity, IUnitOfWorkRepository reporitory);
        void Commit();
    }
}

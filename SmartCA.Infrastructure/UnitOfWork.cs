using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<EntityBase, IUnitOfWorkRepository> addedEdtities;
        private Dictionary<EntityBase, IUnitOfWorkRepository> changedEdtities;
        private Dictionary<EntityBase, IUnitOfWorkRepository> deletedEdtities;

        public UnitOfWork()
        {
            this.addedEdtities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
            this.changedEdtities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
            this.deletedEdtities = new Dictionary<EntityBase, IUnitOfWorkRepository>();
        }

        public void Commit()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                foreach (EntityBase entity in this.deletedEdtities.Keys)
                {
                    this.deletedEdtities[entity].PersistDeletedItem(entity);
                }
                foreach (EntityBase entity in this.addedEdtities.Keys)
                {
                    this.addedEdtities[entity].PersistDeletedItem(entity);
                }
                foreach (EntityBase entity in this.changedEdtities.Keys)
                {
                    this.changedEdtities[entity].PersistDeletedItem(entity);
                }
                scope.Complete();
            }
            this.deletedEdtities.Clear();
            this.addedEdtities.Clear();
            this.changedEdtities.Clear();
        }

        public void RegisterAdd(EntityBase entity, IUnitOfWorkRepository reporitory)
        {
            this.addedEdtities.Add(entity,reporitory);
        }

        public void RegisterChanged(EntityBase entity, IUnitOfWorkRepository reporitory)
        {
            this.changedEdtities.Add(entity, reporitory);
        }

        public void RegisterRemoved(EntityBase entity, IUnitOfWorkRepository reporitory)
        {
            this.deletedEdtities.Add(entity, reporitory);
        }
    }
}

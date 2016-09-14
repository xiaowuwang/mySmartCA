using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.RepositoryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCA.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T>, IUnitOfWorkRepository where T : EntityBase
    {
        private IUnitOfWork unitOfWork;

        protected RepositoryBase()
            : this(null)
        {
        }

        protected RepositoryBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region IRepository<T> Members

        public T this[object key]
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }
        public void Remove(T item)
        {
            throw new NotImplementedException();
        }
        public T FindBy(object key)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUnitOfWorkRepository Members

        public void PersistDeletedItem(EntityBase item)
        {
            throw new NotImplementedException();
        }

        public void PersistNewItem(EntityBase item)
        {
            throw new NotImplementedException();
        }

        public void PersistUpdatedItem(EntityBase item)
        {
            throw new NotImplementedException();
        }
        #endregion

        protected abstract void PersistNewItem(T item);
        protected abstract void PersistUpdatedItem(T item);
        protected abstract void PersistDeletedItem(T item);
    }
}

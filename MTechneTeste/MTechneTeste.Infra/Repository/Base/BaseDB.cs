using MTechneTeste.Domain.Entities.Base;
using MTechneTeste.Domain.Interfaces.Repository.Base;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MTechneTeste.Infra.Repository.Base
{
    public class BaseDB<T> : IBaseDB<T>, IDisposable where T : Entity
    {
        public readonly ISession Session;
        private ITransaction transaction = null;
        public BaseDB(ISessionFactory sessionFactory)
        {
            this.Session = sessionFactory.OpenSession();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            await Session.DeleteAsync(entity);
        }

        public virtual void DeleteInUniqueTransaction(T entity)
        {
            this.Session.Delete(entity);
        }

        public virtual void DeleteInUniqueTransaction(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Session.Delete(entity);
                this.Session.Flush();
            }
        }

        public virtual void Delete(T entity)
        {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
                this.Session.Delete(entity);
                this.Session.Flush();
                transaction.Commit();
            }
        }
        public virtual void Dispose()
        {
            this.Session.Dispose();
        }
        public virtual IList<T> Find(Expression<Func<T, bool>> restriction)
        {
            return Session.Query<T>().Where(restriction).ToList();
        }

        public virtual async Task<IList<T>> FindAsync(Expression<Func<T, bool>> restriction)
        {
            return await Session.Query<T>().Where(restriction).ToListAsync();
        }

        public virtual void Flush()
        {
            this.Session.Flush();
        }

        public virtual IList<T> GetAll()
        {
            return this.Session.CreateCriteria<T>().List<T>();
        }

        public virtual IList<T> GetAllPaged(int page, int maxRecords)
        {
            var criteria = Session.CreateCriteria(typeof(T));
            criteria.SetFirstResult(page * maxRecords - maxRecords);
            criteria.SetMaxResults(maxRecords);
            return criteria.List<T>();
        }

        public virtual IList<T> GetByColumnName(string columnName, object value)
        {
            return Session.CreateCriteria(typeof(T)).Add(NHibernate.Criterion.Restrictions.Eq(columnName, value)).List<T>();
        }

        public virtual IList<T> GetByColumns(params KeyValuePair<string, object>[] parameters)
        {
            var criteria = Session.CreateCriteria(typeof(T));
            for (int i = 0; i < parameters.Count(); i++)
            {
                criteria.Add(NHibernate.Criterion.Restrictions.Eq(parameters[i].Key, parameters[i].Value));
            }
            return criteria.List<T>();
        }

        public virtual T GetById(int id)
        {
            return this.Session.Get<T>(id);
        }

        public virtual void Refresh(T entity)
        {
            this.Session.Refresh(entity);
        }

        public virtual void Save(IEnumerable<T> entities)
        {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
                foreach (var entity in entities)
                {
                    if (entity is IBaseId)
                    {
                        if (((IBaseId)entity).Id == 0)
                            this.Session.Save(entity);
                        else
                            this.Session.Update(entity);
                    }
                    else
                    {
                        this.Session.Save(entity);
                    }

                }
                transaction.Commit();
            }
        }

        public virtual T Save(T entity, bool setEntity = true)
        {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
                if (entity is IBaseId)
                {
                    if (((IBaseId)entity).Id == 0)
                        this.Session.Save(entity);
                    else
                        this.Session.Update(entity);
                }
                else
                {
                    this.Session.Save(entity);
                }
                this.Session.Flush();
                transaction.Commit();
            }
            return entity;
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            await Session.SaveAsync(entity);
            return entity;
        }

        public virtual void SaveInUniqueTransaction(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Session.SaveOrUpdate(entity);
            }
        }

        public virtual void SaveInTransaction(T entity)
        {
            this.Session.Save(entity);
        }

        public virtual T Save(T entity)
        {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
                this.Session.Save(entity);
                this.Session.Flush();
                transaction.Commit();
            }
            return entity;
        }

        public virtual void SaveOrUpdateInUniqueTransaction(T entity)
        {
            this.Session.SaveOrUpdate(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Session.UpdateAsync(entity);
        }
        public virtual void UpdateInUniqueTransaction(T entity)
        {
            this.Session.Update(entity);
        }

        public virtual T Update(T entity)
        {
            using (ITransaction transaction = this.Session.BeginTransaction())
            {
                this.Session.Update(entity);
                transaction.Commit();
            }
            return entity;
        }
        public virtual void OpenTransaction()
        {
            this.transaction = this.Session.BeginTransaction();
        }
        public virtual void CommitTransaction()
        {
            if (transaction != null) this.transaction.Commit();
        }
        public virtual async Task CommitTransactionAsync()
        {
            if (transaction != null) await this.transaction.CommitAsync();
        }
        public virtual void RoolbackTransaction()
        {
            if (transaction != null) transaction.Rollback();
        }
        public virtual async Task RoolbackTransactionAsync()
        {
            if (transaction != null) await transaction.RollbackAsync();
        }
    }
}

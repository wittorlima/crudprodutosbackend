using CRUD.Domain.Constants;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces.Repositories;
using CRUD.Domain.Util;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace CRUD.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
    {
        protected ISession Session { get; set; }

        public RepositoryBase(ISession session)
        {
            Session = session;
        }

        public virtual ICollection<T> GetAll(QuerySettings querySettings)
        {
            var query = this.Session.QueryOver<T>();

            var countQuery = query.ToRowCountQuery().FutureValue<int>();

            if (querySettings.Page > 0)
                query.Skip((querySettings.Page - 1) * querySettings.RecordPerPage).Take(querySettings.RecordPerPage);

            var result = query.OrderBy(x => x.Id).Asc.Future();

            querySettings.TotalRecord = countQuery.Value;

            return result.ToList();
        }

        public virtual ICollection<T> GetAll(QuerySettings querySettings, Expression<Func<T, object>> path)
        {
            var query = this.Session.QueryOver<T>().OrderBy(path).Asc;

            var countQuery = query.ToRowCountQuery().FutureValue<int>();

            if (querySettings.Page > 0)
                query.Skip((querySettings.Page - 1) * querySettings.RecordPerPage).Take(querySettings.RecordPerPage);

            var result = query.Future();

            querySettings.TotalRecord = countQuery.Value;

            return result.ToList();
        }

        public virtual ICollection<T> GetAll(QuerySettings querySettings, Expression<Func<T, bool>> expression)
        {
            var query = this.Session.QueryOver<T>()
                .Where(expression);

            var countQuery = query.ToRowCountQuery().FutureValue<int>();

            if (querySettings.Page > 0)
                query.Skip((querySettings.Page - 1) * querySettings.RecordPerPage).Take(querySettings.RecordPerPage);

            var result = query.Future();

            querySettings.TotalRecord = countQuery.Value;

            return result.ToList();
        }

        public ICollection<T> GetAll(QuerySettings querySettings, Expression<Func<T, bool>> expression, Expression<Func<T, object>> path, OrderBy orderBy)
        {
            var query = this.Session.QueryOver<T>().Where(expression);

            switch (orderBy)
            {
                case OrderBy.Asc:
                    query = query.OrderBy(path).Asc;
                    break;
                case OrderBy.Desc:
                    query = query.OrderBy(path).Desc;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy));
            }

            var countQuery = query.ToRowCountQuery().FutureValue<int>();

            if (querySettings.Page > 0)
                query.Skip((querySettings.Page - 1) * querySettings.RecordPerPage).Take(querySettings.RecordPerPage);

            var result = query.Future();

            querySettings.TotalRecord = countQuery.Value;

            return result.ToList();
        }

        public virtual ICollection<T> GetAll(QuerySettings querySettings, Expression<Func<T, object>> path, OrderBy orderBy)
        {
            var query = this.Session.QueryOver<T>();

            switch (orderBy)
            {
                case OrderBy.Asc:
                    query = query.OrderBy(path).Asc;
                    break;
                case OrderBy.Desc:
                    query = query.OrderBy(path).Desc;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBy));
            }

            var countQuery = query.ToRowCountQuery().FutureValue<int>();

            if (querySettings.Page > 0)
                query.Skip((querySettings.Page - 1) * querySettings.RecordPerPage).Take(querySettings.RecordPerPage);

            var result = query.Future();

            querySettings.TotalRecord = countQuery.Value;

            return result.ToList();
        }

        public virtual T GetById(int modelId)
        {
            var result = this.Session.QueryOver<T>()
                .Where(x => x.Id == modelId)
                .SingleOrDefault();

            return result;
        }

        public virtual void SaveOrUpdate(T model)
        {
            using (var transaction = Session.BeginTransaction())
            {
                this.Session.SaveOrUpdate(model);
                transaction.Commit();
            }

        }

        public virtual void Merge(T model)
        {
            using (var transaction = Session.BeginTransaction())
            {
                this.Session.Merge(model);
                transaction.Commit();
            }

        }

        public void Delete(T model)
        {
            using (var transaction = Session.BeginTransaction())
            {
                this.Session.Delete(model);
                transaction.Commit();
            }
        }

        public void Delete(int id)
        {
            using (var transaction = Session.BeginTransaction())
            {
                var model = this.Session.Get<T>(id);
                this.Session.Delete(model);
                transaction.Commit();
            }
        }

        public void Flush()
        {
            this.Session.Flush();
        }

        public ICollection<T> GetAll()
        {
            var query = this.Session.QueryOver<T>();

            var result = query.OrderBy(x => x.Id).Asc.Future();

            return result.ToList();
        }
    }
}

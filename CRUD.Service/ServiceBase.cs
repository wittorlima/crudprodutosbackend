using CRUD.Domain.Constants;
using CRUD.Domain.Entities;
using CRUD.Domain.Interfaces.Repositories;
using CRUD.Domain.Interfaces.Services;
using CRUD.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRUD.Service
{
    public class ServiceBase<T> : IServiceBase<T> where T : ModelBase
    {
        protected IRepositoryBase<T> Repository { get; set; }

        public ServiceBase(IRepositoryBase<T> repository)
        {
            this.Repository = repository;
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            this.Repository.Flush();
        }

        public ICollection<T> GetAll(QuerySettings settings)
        {
            return this.Repository.GetAll(settings);
        }

        public ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, bool>> expression)
        {
            return this.Repository.GetAll(settings, expression);
        }

        public ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, object>> path, OrderBy orderBy)
        {
            return this.Repository.GetAll(settings, path, orderBy);
        }

        public ICollection<T> GetAll()
        {
            return this.Repository.GetAll();
        }

        public ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, bool>> expression, Expression<Func<T, object>> path, OrderBy orderBy)
        {
            return this.Repository.GetAll(settings, expression, path, orderBy);
        }

        public T GetById(int modelId)
        {
            return this.Repository.GetById(modelId);
        }

        public void SaveOrUpdate(T model)
        {
            this.Repository.SaveOrUpdate(model);
        }
    }
}

using CRUD.Domain.Constants;
using CRUD.Domain.Entities;
using CRUD.Domain.Util;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CRUD.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : ModelBase
    {
        ICollection<T> GetAll(QuerySettings settings);

        ICollection<T> GetAll();

        ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, bool>> expression);

        ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, object>> path, OrderBy orderBy);

        ICollection<T> GetAll(QuerySettings settings, Expression<Func<T, bool>> expression, Expression<Func<T, object>> path, OrderBy orderBy);

        T GetById(int modelId);

        void SaveOrUpdate(T model);

        void Delete(T model);

        void Delete(int id);

        void Flush();
    }
}

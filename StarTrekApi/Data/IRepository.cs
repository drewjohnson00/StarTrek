using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointRobertsSoftware.StarTrek.Api.Data
{
    public interface IRepository<TEntity, in TKey> where TEntity : class
    {
        Task<TEntity> GetAsync(TKey id);
        void Save(TEntity entity);
        void Delete(TEntity entity);
    }
}

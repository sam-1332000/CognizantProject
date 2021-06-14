using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Repository
{
    public interface IProductRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);

    }

}

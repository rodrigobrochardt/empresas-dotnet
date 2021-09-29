using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IBaseRepository<TEntity> where TEntity : class {

        Task<TEntity> Add(TEntity obj);
        Task<TEntity> Update(TEntity obj);
        Task<TEntity> Remove(TEntity obj);
        void Dispose();
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();

    }
}

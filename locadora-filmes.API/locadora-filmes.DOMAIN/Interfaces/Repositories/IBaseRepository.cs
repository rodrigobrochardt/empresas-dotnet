using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IBaseRepository<TEntity> where TEntity : class {

       
        void Dispose();
       

    }
}

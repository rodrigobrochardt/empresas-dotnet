using locadora_filmes.DOMAIN.Interfaces.Repositories;
using locadora_filmes.INFRA.Data.Context;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class {

        protected SqlServerContext Db = new SqlServerContext();

        public void Dispose() {
            Db.Dispose();
        }
    }
}

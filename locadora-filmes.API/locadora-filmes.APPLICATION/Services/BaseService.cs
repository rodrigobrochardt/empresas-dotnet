using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.Interfaces;
using locadora_filmes.DOMAIN.Interfaces.Repositories;

namespace locadora_filmes.APPLICATION.Services {
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class {

        private readonly IBaseRepository<TEntity> baseRepository;
        public BaseService(IBaseRepository<TEntity> baseRepository) {
            this.baseRepository = baseRepository;
        }

        protected Response Ok(object obj) {

            return new Response(200, obj);
        }

        protected Response BadRequest(object value) {
            return new Response(400, value);
        }

        protected Response Unauthorized(string value) {
            return new Response(401, $"Usuário de identificação {value} não é administrador");
        }

        protected Response NoContent(object value) {
            return new Response(204, value);
        }

        protected Response Conflict(string value) {
            return new Response(409, value);
        }

    }
}

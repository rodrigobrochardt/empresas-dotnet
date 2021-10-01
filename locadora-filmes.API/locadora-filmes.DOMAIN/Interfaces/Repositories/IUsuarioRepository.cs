using locadora_filmes.DOMAIN.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IUsuarioRepository : IBaseRepository<Usuario> {

        Task<Usuario> Add(Usuario obj);
        Task<Usuario> Update(Usuario obj);
        Task<Usuario> Remove(Usuario obj);
        Task<Usuario> GetById(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> Get(int pagina, int quantidade);
        Task<IEnumerable<Usuario>> GetDesligados(int pagina = 0, int quantidade = 0);
        Task<IEnumerable<Usuario>> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0);
        Task<Usuario> GetByEmail(string email);
    }
}

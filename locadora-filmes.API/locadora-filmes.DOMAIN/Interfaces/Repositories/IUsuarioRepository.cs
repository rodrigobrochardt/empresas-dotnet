using locadora_filmes.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IUsuarioRepository : IBaseRepository<Usuario> {

        Task<IEnumerable<Usuario>> Get(int pagina, int quantidade);
        Task<IEnumerable<Usuario>> GetDesligados(int pagina = 0, int quantidade = 0);
        Task<IEnumerable<Usuario>> GetOrdemAlfabetica(int pagina = 0, int quantidade = 0);
    }
}

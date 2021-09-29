using locadora_filmes.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IUsuarioRepository : IBaseRepository<Usuario> {

        Task<IEnumerable<Administrador>> Get(int pagina, int quantidade);
        Task<IEnumerable<Administrador>> GetDesligados(int pagina = 0, int quantidade = 0);
        Task<IEnumerable<Administrador>> GetOrdemAlfabetica(int pagina = 0, int quantidade = 0);
    }
}

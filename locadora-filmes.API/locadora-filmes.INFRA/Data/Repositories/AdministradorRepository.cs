using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class AdministradorRepository : BaseRepository<Administrador>, IAdministradorRepository {

        public async Task<IEnumerable<Administrador>> Get(int pagina, int quantidade) {
            try {
                return this.Db.Set<Administrador>()
                        .AsNoTracking()
                        .Skip(pagina)
                        .Take(quantidade)
                        .ToList();

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Administrador>> GetDesligados(int pagina = 0, int quantidade = 0) {
            try {
                var result = this.Db.Set<Administrador>().AsNoTracking();
                if (pagina > 0 && quantidade > 0) {
                    result.Skip(pagina)
                            .Take(quantidade);
                }
                result.Where(e => e.Status == "EX")
                        .ToList();

                return result;
         
            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Administrador>> GetOrdemAlfabetica(int pagina = 0, int quantidade = 0) {
            try {
                var result = this.Db.Set<Administrador>().AsNoTracking();
                if (pagina > 0 && quantidade > 0) {
                    result.Skip(pagina)
                            .Take(quantidade);
                }
                result.OrderBy(e => e.Nome)
                        .ToList();

                return result;
       
            } catch (Exception except) {

                throw except.InnerException;
            }
        }
    }
}

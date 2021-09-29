using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository {

        public async Task<IEnumerable<Filme>> Get(int pagina, int quantidade) {
            try {
                return this.Db.Set<Filme>()
                        .AsNoTracking()
                        .Skip(pagina)
                        .Take(quantidade)
                        .ToList();

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByFilters(string diretor = "", string titulo = "", List<string> generos = null, List<string> atores = null, int pagina = 0, int quantidade = 0) {
            try {
                var result = this.Db.Set<Filme>().AsNoTracking();
                if (pagina > 0 && quantidade > 0) {
                    result.Skip(pagina)
                            .Take(quantidade);
                }
                if (!String.IsNullOrEmpty(diretor)) {
                    result.Where(e => e.Diretor == diretor);
                }
                if (!String.IsNullOrEmpty(titulo)) {
                    result.Where(e => e.Titulo == titulo);
                }
                if (generos.Count > 0) {
                    result.Where(e => e.Genero == generos);
                }
                if (generos.Count > 0) {
                    result.Where(e => e.Atores == atores);
                }
                result.ToList();

                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0) {
            try {
                var result = this.Db.Set<Filme>().AsNoTracking();
                if(pagina > 0 && quantidade > 0) {
                    result.Skip(pagina)
                            .Take(quantidade);
                }
                result.OrderBy(e => e.Titulo)
                        .ToList();

                return result;
                
            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByPontuacao(int pagina = 0, int quantidade = 0) {
            try {
                var result = this.Db.Set<Filme>().AsNoTracking();
                if (pagina > 0 && quantidade > 0) {
                    result.Skip(pagina)
                            .Take(quantidade);
                }
                result.OrderBy(e => e.Pontuacao)
                        .ToList();

                return result;
            } catch (Exception except) {

                throw except.InnerException;
            }
        }
    }
}

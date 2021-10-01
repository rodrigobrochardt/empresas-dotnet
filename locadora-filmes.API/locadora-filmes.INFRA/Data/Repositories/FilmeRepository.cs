using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository {

        public async Task<Filme> Add(Filme obj) {
            try {
                Db.Set<Filme>().Add(obj);
                await Db.SaveChangesAsync();
                return obj;
            } catch (Exception except) {

                throw except.InnerException;
            }

        }

        public async Task<IEnumerable<Filme>> GetAll() {
            try {
                return Db.Set<Filme>().Where(e => e.Status == "AT")
                        .AsNoTracking()
                        .ToList();

            } catch (Exception except) {

                throw except.InnerException;

            }

        }

        public async Task<Filme> GetById(int id) {
            try {
                var entity = Db.Set<Filme>().AsNoTracking()
                               .Where(e => (e.Id == id) && (e.Status == "AT"))
                               .FirstOrDefault();

                return entity;

            } catch (Exception except) {

                throw except.InnerException;

            }
        }

        public async Task<Filme> Remove(Filme obj) {
            try {
                var entity = Db.Set<Filme>().AsNoTracking()
                                .Where(e => (e.Status == "AT") && e.Id == obj.Id)
                                .FirstOrDefault();
                if (entity != null) {
                    Db.Entry(obj).State = EntityState.Modified;
                    await Db.SaveChangesAsync();
                    return obj;
                }

                return entity;
            } catch (Exception except) {

                throw except.InnerException;

            }


        }

        public async Task<Filme> Update(Filme obj) {
            try {
                var entity = Db.Set<Filme>().AsNoTracking()
                               .Where(e => (e.Status == "AT") && e.Id == obj.Id)
                               .FirstOrDefault();
                if (entity != null) {
                    Db.Entry(obj).State = EntityState.Modified;
                    await Db.SaveChangesAsync();
                    return obj;
                }

                return entity;

            } catch (Exception except) {

                throw except.InnerException;

            }

        }

        public async Task<IEnumerable<Filme>> Get(int pagina, int quantidade) {
            try {
                var context = this.Db.Set<Filme>();
                IQueryable<Filme> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.Where(e => e.Status == "AT");

                var result = query.AsNoTracking().ToList();
                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByFilters(string diretor = "", string titulo = "",List<String> generos = null, List<String> atores = null, int pagina = 0, int quantidade = 0) {
            try {
                generos = generos.Where(x => !string.IsNullOrEmpty(x)).ToList();
                atores = atores.Where(x => !string.IsNullOrEmpty(x)).ToList();

                var context = this.Db.Set<Filme>().AsNoTracking();
                IEnumerable<Filme> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                if (!String.IsNullOrEmpty(diretor)) {
                    query = query.Where(e => e.Diretor == diretor);
                }
                if (!String.IsNullOrEmpty(titulo)) {
                    query = query.Where(e => e.Titulo == titulo);
                }
                if (generos.Count > 0 ) {
                    query = query.Where(e => generos.Any(w => e.Genero.ToLower().Contains((string)w.Trim().ToLower()))).AsEnumerable();
                }
                if (atores.Count > 0) {
                    query = query.Where(e => atores.Any(w => e.Atores.ToLower().Contains((string)w.Trim().ToLower()))).AsEnumerable();
                }
                query = query.Where(e => e.Status == "AT" );

                var result = query.ToList();
                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0) {
            try {
                var context = this.Db.Set<Filme>();
                IQueryable<Filme> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.OrderBy(e => e.Titulo);
                query = query.Where(e => e.Status == "AT");

                var result = query.AsNoTracking().ToList();
                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Filme>> GetByPontuacao(int pagina = 0, int quantidade = 0, decimal pontuacao = 0) {
            try {
               var context = this.Db.Set<Filme>();
                IQueryable<Filme> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                if(pontuacao > 0) {
                    query = query.Where(e => e.Pontuacao >= pontuacao);
                }
                query = query.OrderByDescending(e => e.Pontuacao);
                query = query.Where(e => e.Status == "AT");

                var result = query.AsNoTracking().ToList();
                return result;
            } catch (Exception except) {

                throw except.InnerException;
            }
        }
    }
}

using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository {

        public async Task<Usuario> Add(Usuario obj) {
            try {
                Db.Set<Usuario>().Add(obj);
                await Db.SaveChangesAsync();
                return obj;
            } catch (Exception except) {

                throw except.InnerException;
            }

        }

        public async Task<IEnumerable<Usuario>> GetAll() {
            try {
                return Db.Set<Usuario>()
                        .Where(e => e.Status == "AT" && e.Cargo == UsuarioCargoEnm.CLIENTE)
                        .AsNoTracking()
                        .ToList();

            } catch (Exception except) {

                throw except.InnerException;

            }

        }

        public async Task<Usuario> GetById(int id) {
            try {
                var entity = Db.Set<Usuario>().AsNoTracking()
                               .Where(e => (e.Id == id) && (e.Status == "AT"))
                               .FirstOrDefault();

                return entity;
            } catch (Exception except) {

                throw except.InnerException;

            }
        }

        public async Task<Usuario> Remove(Usuario obj) {
            try {
                var entity = Db.Set<Usuario>().AsNoTracking()
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

        public async Task<Usuario> Update(Usuario obj) {
            try {
                var entity = Db.Set<Usuario>().AsNoTracking()
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

        public async Task<IEnumerable<Usuario>> Get(int pagina, int quantidade) {
            try {
                var context = this.Db.Set<Usuario>();
                IQueryable<Usuario> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.Where(e => e.Status == "AT" && e.Cargo == UsuarioCargoEnm.CLIENTE);

                var result = query.AsNoTracking().ToList();
                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Usuario>> GetDesligados(int pagina = 0, int quantidade = 0) {
            try {
                var context = this.Db.Set<Usuario>();
                IQueryable<Usuario> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.Where(e => e.Status == "EX" && e.Cargo == UsuarioCargoEnm.CLIENTE);

                var result = query.AsNoTracking().ToList();
                return result;

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<IEnumerable<Usuario>> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0) {
            try {
                var context = this.Db.Set<Usuario>();
                IQueryable<Usuario> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.OrderBy(e => e.Nome);
                query = query.Where(e => e.Status == "AT" && e.Cargo == UsuarioCargoEnm.CLIENTE);

                var result = query.AsNoTracking().ToList();
                return result;
            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public async Task<Usuario> GetByEmail(string email) {
            try {
                var entity = Db.Set<Usuario>()
                                .Where(e => (e.Email.ToLower() == email.ToLower()) && (e.Status == "AT"))
                                .FirstOrDefault();

                return entity;

            } catch (Exception except) {

                throw except.InnerException;

            }
        }
    }
}

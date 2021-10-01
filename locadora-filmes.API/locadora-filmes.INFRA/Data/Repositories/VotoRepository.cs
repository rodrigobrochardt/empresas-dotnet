using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace locadora_filmes.INFRA.Data.Repositories {
    public class VotoRepository : BaseRepository<Voto>, IVotoRepository {


        public async Task<Voto> Add(Voto obj) {
            try {
                Db.Set<Voto>().Add(obj);
                await Db.SaveChangesAsync();

                FilmeRepository filmeRepo = new FilmeRepository();
                Filme filme= await filmeRepo.GetById(obj.FilmeId);
                filme.AddVoto(obj.Nota);
                filmeRepo.Update(filme);

                return obj;
            } catch (Exception except) {

                throw except.InnerException;
            }

        }

        public async Task<Voto> GetById(int id) {
            try {
                var entity = Db.Set<Voto>().AsNoTracking()
                               .Where(e => (e.Id == id) && (e.Status == "AT"))
                               .FirstOrDefault();

                return entity;
            } catch (Exception except) {

                throw except.InnerException;

            }
        }

        public async Task<Voto> Remove(Voto obj) {
            try {
                var entity = Db.Set<Voto>().AsNoTracking()
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

        public async Task<Voto> Update(Voto obj) {
            try {
                var entity = Db.Set<Voto>().AsNoTracking()
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

        public async Task<IEnumerable<Voto>> GetByUserId(int id, int pagina = 0, int quantidade = 0) {
            try {
                var context = this.Db.Set<Voto>();
                IQueryable<Voto> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.Where(e => e.Status == "AT" && e.UsuarioId == id);

                var result = query.AsNoTracking().ToList();
                return result;
            } catch (Exception except) {

                throw except.InnerException;

            }
        }

        public async Task<IEnumerable<Voto>> GetByFilmId(int id, int pagina = 0, int quantidade = 0) {
            try {
                var context = this.Db.Set<Voto>();
                IQueryable<Voto> query = context;
                if (pagina >= 0 && quantidade > 0) {
                    query = query.Skip(pagina).Take(quantidade);
                }
                query = query.Where(e => e.Status == "AT" && e.FilmeId == id);

                var result = query.AsNoTracking().ToList();
                return result;
            } catch (Exception except) {

                throw except.InnerException;

            }
        }

        public async Task<Voto> GetByUserAndFilm(int userId, int filmId) {
            try {
                var entity = Db.Set<Voto>().AsNoTracking()
                               .Where(e => (e.UsuarioId == userId) &&(e.FilmeId == filmId) && (e.Status == "AT"))
                               .FirstOrDefault();

                return entity;
            } catch (Exception except) {

                throw except.InnerException;

            }
        }

    }
}

using locadora_filmes.DOMAIN.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IVotoRepository : IBaseRepository<Voto> {

        Task<Voto> Add(Voto obj);
        Task<Voto> Update(Voto obj);
        Task<Voto> Remove(Voto obj);
        Task<Voto> GetById(int id);
        Task<IEnumerable<Voto>> GetByUserId(int id, int pagina, int quantidade);
        Task<IEnumerable<Voto>> GetByFilmId(int id, int pagina, int quantidade);
        Task<Voto> GetByUserAndFilm(int userId, int filmId);

    }
}

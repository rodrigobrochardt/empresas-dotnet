using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IVotoService : IBaseService<VotoModel>
    {
        Task<Response> Add(VotoModel obj);
        Task<Response> Update(VotoModel obj);
        Task<Response> Remove(int id);
        Task<Response> GetById(int id);
        Task<Response> GetByUserId(int id, int pagina, int quantidade);
        Task<Response> GetByFilmId(int id, int pagina, int quantidade);
        Task<Response> GetByUserAndFilm(int userId, int filmId);
    }
}

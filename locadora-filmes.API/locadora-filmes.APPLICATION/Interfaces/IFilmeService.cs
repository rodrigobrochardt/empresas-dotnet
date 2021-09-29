using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IFilmeService : IBaseService<FilmeModel>
    {
        Task<Response> Add(FilmeModel obj);
        Task<Response> Update(FilmeModel obj);
        Task<Response> Remove(int id);
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        void Dispose();
    }
}

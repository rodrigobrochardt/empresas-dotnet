using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        Task<Response> Add(UsuarioModel obj);
        Task<Response> Update(UsuarioModel obj);
        Task<Response> Remove(int id);
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        void Dispose();
        Task<Response> Authenticate(UsuarioModel obj);
    }
}

using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IAdministradorService : IBaseService<AdministradorModel>
    {
        Task<Response> Add(AdministradorModel obj);
        Task<Response> Update(AdministradorModel obj);
        Task<Response> Remove(int id);
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        void Dispose();
        Task<Response> Authenticate(UsuarioModel obj);

    }
}

using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IUsuarioService : IBaseService<UsuarioModel>
    {
        Task<Response> Add(UsuarioModel obj);
        Task<Response> Update(UsuarioModel obj, string userIdentity);
        Task<Response> Remove(int id, string userIdentity);
        Task<Response> GetAll(string userIdentity);
        Task<Response> GetById(int id, string userIdentity);
        Task<Response> GetByEmail(string email, string userIdentity);
        void Dispose();
        Task<Response> Get(int pagina, int quantidade, string userIdentity);
        Task<Response> GetDesligados(string userIdentity,int pagina = 0, int quantidade = 0);
        Task<Response> GetByOrdemAlfabetica(string userIdentity, int pagina = 0, int quantidade = 0);
        Task<Response> Authenticate(UsuarioModel obj);
        Task<Boolean> HasPermission(string email);
    }
}

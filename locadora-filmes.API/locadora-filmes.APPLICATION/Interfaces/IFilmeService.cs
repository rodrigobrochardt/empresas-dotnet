using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.DOMAIN.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Interfaces
{
    public interface IFilmeService : IBaseService<FilmeModel>
    {
        Task<Response> Add(FilmeModel obj, string userIdentity);
        Task<Response> Update(FilmeModel obj, string userIdentity);
        Task<Response> Remove(int id, string userIdentity);
        Task<Response> GetAll();
        Task<Response> GetById(int id);
        Task<Response> GetByFilters(string diretor = "", 
                                    string titulo = "",
                                    List<string> generos = null,
                                    List<string> atores = null,
                                    int pagina = 0,
                                    int quantidade = 0);

        Task<Response> Get(int pagina, int quantidade);
        Task<Response> GetByPontuacao(int pagina = 0, int quantidade = 0, decimal pontuacao = 0);
        Task<Response> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0);
        void Dispose();
    }
}

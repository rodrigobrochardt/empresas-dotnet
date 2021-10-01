using locadora_filmes.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Interfaces.Repositories {
    public interface IFilmeRepository : IBaseRepository<Filme> {

        Task<Filme> Add(Filme obj);
        Task<Filme> Update(Filme obj);
        Task<Filme> Remove(Filme obj);
        Task<Filme> GetById(int id);
        Task<IEnumerable<Filme>> GetAll();
        Task<IEnumerable<Filme>> GetByFilters(String diretor = "",
                                                String titulo = "", 
                                                List<String> generos = null, 
                                                List<String> atores = null,
                                                int pagina = 0,
                                                int quantidade = 0);

        Task<IEnumerable<Filme>> Get(int pagina, int quantidade);
        Task<IEnumerable<Filme>> GetByPontuacao(int pagina = 0, int quantidade = 0, decimal pontuacao = 0);
        Task<IEnumerable<Filme>> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0);

    }
}

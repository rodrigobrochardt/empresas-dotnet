using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.AutoMapper;
using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using locadora_filmes.APPLICATION.Interfaces;

namespace locadora_filmes.APPLICATION.Services
{
    public class FilmeService : BaseService<Filme>, IFilmeService, IDisposable
    {
        private readonly IFilmeRepository filmeRepository;
        private readonly IUsuarioService usuarioService;
        public FilmeService(IFilmeRepository filmeRepository, IUsuarioService usuarioService) : base(filmeRepository)
        {
            this.filmeRepository = filmeRepository;
            this.usuarioService = usuarioService;
        }

        public async Task<Response> Add(FilmeModel obj, string userIdentity)
        {
           
            Boolean isUserAdm = await usuarioService.HasPermission(userIdentity);

            if (isUserAdm) {
                var entity = new Filme(obj);

                if (entity.IsValid()) {
                    entity.SetStatus("AT");
                    entity.SetAuditoria($"FILME CRIADO EM {DateTime.Now}");
                    var result = await filmeRepository.Add(entity);

                    return Ok(result);
                }
                return BadRequest(entity.GetValidationResults());
            } else {
                return Unauthorized(userIdentity);
            }
        }

        public async Task<Response> GetAll()
        {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<FilmeModel>>(await filmeRepository.GetAll());

            return Ok(entity);
        }

        public async Task<Response> GetById(int id)
        {

            var entity = AutoMapperConfig.mapper.Map<FilmeModel>(await filmeRepository.GetById(id));

            return Ok(entity);

        }

        public async Task<Response> Remove(int id, string userIdentity)
        {
            Boolean isUserAdm = await usuarioService.HasPermission(userIdentity);

            if (isUserAdm) {
                var entity = new Filme(await filmeRepository.GetById(id));
                if (entity.IsValid()) {
                    entity.SetStatus("EX");
                    entity.SetAuditoria($"FILME EXCLUIDO EM {DateTime.Now}");
                    return Ok(await filmeRepository.Remove(entity));

                }
                return BadRequest(entity.GetValidationResults());
            } else {
                return Unauthorized(userIdentity);
            }
        }

        public async Task<Response> Update(FilmeModel obj, string userIdentity)
        {
            try
            {
                Boolean isUserAdm = await usuarioService.HasPermission(userIdentity);

                if (isUserAdm) {
                    var entity = new Filme(obj);
                    if (entity.IsValid()) {

                        entity.SetAuditoria($"FILME ATUALIZADO EM {DateTime.Now}");
                        return Ok(await filmeRepository.Update(entity));

                    }
                    return BadRequest(entity.GetValidationResults());
                } else {
                    return Unauthorized(userIdentity);
                }
            }
            catch (Exception except)
            {

                throw except.InnerException;
            }


        }

        public void Dispose()
        {
            filmeRepository.Dispose();
        }

        public async Task<Response> GetByFilters(string diretor = "", string titulo = "", List<string> generos = null, List<string> atores = null, int pagina = 0, int quantidade = 0) {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<FilmeModel>>(await filmeRepository.GetByFilters(diretor, titulo,generos,atores,pagina,quantidade));

            return Ok(entity);
        }

        public async Task<Response> Get(int pagina, int quantidade) {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<FilmeModel>>(await filmeRepository.Get(pagina, quantidade));

            return Ok(entity);
        }

        public async Task<Response> GetByPontuacao(int pagina = 0, int quantidade = 0, decimal pontuacao = 0) {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<FilmeModel>>(await filmeRepository.GetByPontuacao(pagina, quantidade, pontuacao));

            return Ok(entity);
        }

        public async Task<Response> GetByOrdemAlfabetica(int pagina = 0, int quantidade = 0) {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<FilmeModel>>(await filmeRepository.GetByOrdemAlfabetica(pagina, quantidade));

            return Ok(entity);
        }
    }
}

using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.AutoMapper;
using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using locadora_filmes.APPLICATION.Interfaces;

namespace locadora_filmes.APPLICATION.Services {
    public class VotoService : BaseService<Voto>, IVotoService, IDisposable {
        private readonly IVotoRepository votoRepository;

        public VotoService(IVotoRepository votoRepository) : base(votoRepository) {
            this.votoRepository = votoRepository;
        }

        public async Task<Response> Add(VotoModel obj) {

            var entity = new Voto(obj);
            var votoExiste =  AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.GetByUserAndFilm(entity.UsuarioId, entity.FilmeId));
            if (votoExiste != null) {
                return Conflict("Voto já existe");
            }

            if (entity.IsValid()) {
                entity.SetStatus("AT");
                entity.SetAuditoria($"VOTO CRIADO EM {DateTime.Now}");
                var result = AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.Add(entity));

                return Ok(result);
            }
            return BadRequest(entity.GetValidationResults());
        }

        public async Task<Response> GetById(int id) {

            var entity = AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.GetById(id));
            return Ok(entity);


        }

        public async Task<Response> GetByUserId(int id, int pagina = 0, int quantidade = 0) {

            var entity = AutoMapperConfig.mapper.Map<IEnumerable<VotoModel>>(await votoRepository.GetByUserId(id, pagina, quantidade));

            return Ok(entity);

        }

        public async Task<Response> GetByFilmId(int id, int pagina = 0, int quantidade = 0) {

            var entity = AutoMapperConfig.mapper.Map<IEnumerable<VotoModel>>(await votoRepository.GetByFilmId(id, pagina, quantidade));

            return Ok(entity);

        }

        public async Task<Response> GetByUserAndFilm(int userId, int filmeId) {

            var entity = AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.GetByUserAndFilm(userId, filmeId));

            return Ok(entity);

        }

        public async Task<Response> Remove(int id) {

            var entity = await votoRepository.GetById(id);
            if (entity == null) {
                return Ok(entity);
            } else {
                entity = new Voto(entity);

                if (entity.IsValid()) {
                    entity.SetStatus("EX");
                    entity.SetAuditoria($"VOTO EXCLUIDO EM {DateTime.Now}");
                    var result = AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.Remove(entity));
                    return Ok(result);

                }
                return BadRequest(entity.GetValidationResults());
            }


        }

        public async Task<Response> Update(VotoModel obj) {

            var entity = new Voto(obj);
            if (entity.IsValid()) {

                entity.SetAuditoria($"VOTO ATUALIZADO EM {DateTime.Now}");
                var result = AutoMapperConfig.mapper.Map<VotoModel>(await votoRepository.Update(entity));

                return Ok(result);

            }
            return BadRequest(entity.GetValidationResults());

        }

        public void Dispose() {
            votoRepository.Dispose();
        }

    }
}

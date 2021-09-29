using locadora_filmes.APPLICATION.AutoMapper;
using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.Interfaces;
using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace locadora_filmes.APPLICATION.Services
{
    public class AdministradorService : BaseService<Administrador>, IAdministradorService, IDisposable
    {
        private readonly IAdministradorRepository administradorRepository;
        public AdministradorService(IAdministradorRepository administradorRepository) : base(administradorRepository)
        {
            this.administradorRepository = administradorRepository;
        }

        public async Task<Response> Add(AdministradorModel obj)
        {
            var entity = new Administrador(obj);
            if (entity.IsValid())
            {
                return Ok(await administradorRepository.Add(entity));
            }
            return BadRequest(entity.GetValidationResults());
        }

        public async Task<Response> GetAll()
        {
            var entity = AutoMapper.AutoMapperConfig.mapper.Map<IEnumerable<AdministradorModel>>(await administradorRepository.GetAll());

            return Ok(entity);
        }

        public async Task<Response> GetById(int id)
        {

            var entity = AutoMapper.AutoMapperConfig.mapper.Map<Administrador>(await administradorRepository.GetById(id));

            return Ok(entity);

        }

        public async Task<Response> Remove(int id)
        {
            var entity = new Administrador(await administradorRepository.GetById(id));
            if (entity.IsValid())
            {
                return Ok(await administradorRepository.Remove(entity));

            }
            return BadRequest(entity.GetValidationResults());
        }

        public async Task<Response> Update(AdministradorModel obj)
        {
            try
            {
                var entity = new Administrador(obj);
                if (entity.IsValid())
                {
                    return Ok(await administradorRepository.Update(entity));

                }
                return BadRequest(entity.GetValidationResults());
            }
            catch (Exception except)
            {

                throw except.InnerException;
            }
        }

        public async Task<Response> Authenticate(UsuarioModel obj) {
            try {
                var verifyAnnotation = AutoMapperConfig.mapper.Map<Usuario>(obj);
                if (verifyAnnotation.IsValid()) {
                    var entity = await administradorRepository.GetById(obj.Id);
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(obj.Senha, entity.Senha);
                    if (isValidPassword && obj.Email == entity.Email) {


                        var token = TokenService.GenerateToken(entity);
                        entity.Senha = "";
                        return Ok(new { entity = entity, token = token });
                    }
                    return BadRequest(obj);
                }
                return BadRequest(obj);

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public void Dispose()
        {
            administradorRepository.Dispose();
        }


    }
}

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
    public class UsuarioService : BaseService<Usuario>, IUsuarioService, IDisposable
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Add(UsuarioModel obj)
        {
            
            var entity = new Usuario(obj);
            
            if (entity.IsValid())
            {
                entity.Senha = BCrypt.Net.BCrypt.HashPassword(entity.Senha);
                return Ok(await usuarioRepository .Add(entity));
            }
            return BadRequest(entity.GetValidationResults());
        }

        public async Task<Response> GetAll()
        {
            var entity = AutoMapperConfig.mapper.Map<IEnumerable<UsuarioModel>>(await usuarioRepository.GetAll());

            return Ok(entity);
        }

        public async Task<Response> GetById(int id)
        {

            var entity = AutoMapperConfig.mapper.Map<Usuario>(await usuarioRepository.GetById(id));

            return Ok(entity);

        }

        public async Task<Response> Remove(int id)
        {
            var entity = new Usuario(await usuarioRepository.GetById(id));
            if (entity.IsValid())
            {
                return Ok(await usuarioRepository .Remove(entity));

            }
            return BadRequest(entity.GetValidationResults());

        }

        public async Task<Response> Update(UsuarioModel obj)
        {
            try
            {
                var entity = new Usuario(obj);
                if (entity.IsValid())
                {
                    return Ok(await usuarioRepository.Update(entity));

                }
                return BadRequest(entity.GetValidationResults());
            }
            catch (Exception except)
            {

                throw except.InnerException;
            }


        }
        public async Task<Response> Authenticate(UsuarioModel obj)
        {
            try
            {
                var verifyAnnotation = AutoMapperConfig.mapper.Map<Usuario>(obj);
                if (verifyAnnotation.IsValid())
                {
                    var entity = await usuarioRepository.GetById(obj.Id);
                    bool isValidPassword = BCrypt.Net.BCrypt.Verify(obj.Senha,entity.Senha);
                    if( isValidPassword && obj.Email == entity.Email)
                    {
                        

                        var token = TokenService.GenerateToken(entity);
                        entity.Senha = "";
                        return Ok(new { entity = entity, token = token });
                    }
                    return BadRequest(obj);
                }
                return BadRequest(obj);

            }
            catch (Exception except)
            {

                throw except.InnerException;
            }
        }

        public void Dispose()
        {
            usuarioRepository.Dispose();
        }

    }
}

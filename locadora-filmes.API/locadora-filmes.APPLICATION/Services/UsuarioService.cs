using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.AutoMapper;
using locadora_filmes.DOMAIN.Entities;
using locadora_filmes.DOMAIN.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using locadora_filmes.APPLICATION.Interfaces;

namespace locadora_filmes.APPLICATION.Services {
    public class UsuarioService : BaseService<Usuario>, IUsuarioService, IDisposable {
        private readonly IUsuarioRepository usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository) {
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<Response> Add(UsuarioModel obj) {

            var entity = new Usuario(obj);

            if (entity.IsValid()) {
                entity.SetStatus("AT");
                entity.SetAuditoria($"USUARIO CRIADO EM {DateTime.Now}");
                entity.EncryptPassword();
                var result = AutoMapperConfig.mapper.Map<UsuarioModel>(await usuarioRepository.Add(entity));

                return Ok(result);
            }
            return BadRequest(entity.GetValidationResults());
        }

        public async Task<Response> GetAll(string userIdentity) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {

                var entity = AutoMapperConfig.mapper.Map<IEnumerable<UsuarioModel>>(await usuarioRepository.GetAll());
                return Ok(entity);

            } else {
                return Unauthorized(userIdentity);
            }


        }

        public async Task<Response> GetById(int id, string userIdentity) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = AutoMapperConfig.mapper.Map<UsuarioModel>(await usuarioRepository.GetById(id));
                return Ok(entity);
            } else {
                return Unauthorized(userIdentity);
            }

        }

        public async Task<Response> GetByEmail(string email, string userIdentity) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = AutoMapperConfig.mapper.Map<UsuarioModel>(await usuarioRepository.GetByEmail(email));

                return Ok(entity);
            } else {
                return Unauthorized(userIdentity);

            }
        }

        public async Task<Response> Remove(int id, string userIdentity) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = await usuarioRepository.GetById(id);
                if (entity == null) {
                    return Ok(entity);
                } else {
                    entity = new Usuario(entity);

                    if (entity.IsValid()) {
                        entity.SetStatus("EX");
                        entity.SetAuditoria($"USUARIO EXCLUIDO EM {DateTime.Now}");
                        var result = AutoMapperConfig.mapper.Map<UsuarioModel>(await usuarioRepository.Remove(entity));
                        return Ok(result);

                    }
                    return BadRequest(entity.GetValidationResults());
                }
            } else {
                return Unauthorized(userIdentity);

            }

        }

        public async Task<Response> Update(UsuarioModel obj, string userIdentity) {
            try {
                Boolean isAdm = await HasPermission(userIdentity);

                if (isAdm) {
                    var entity = new Usuario(obj);
                    if (entity.IsValid()) {
                        if (entity.Senha != null) {
                            entity.EncryptPassword();
                        }
                        entity.SetAuditoria($"USUARIO ATUALIZADO EM {DateTime.Now}");
                        var result = AutoMapperConfig.mapper.Map<UsuarioModel>(await usuarioRepository.Update(entity));

                        return Ok(result);

                    }
                    return BadRequest(entity.GetValidationResults());
                } else {
                    return Unauthorized(userIdentity);

                }
            } catch (Exception except) {

                throw except.InnerException;
            }


        }
        public async Task<Response> Authenticate(UsuarioModel obj) {
            try {
                var verifyAnnotation = AutoMapperConfig.mapper.Map<Usuario>(obj);
                if (verifyAnnotation.IsValid()) {
                    var entity = await usuarioRepository.GetByEmail(obj.Email);
                    if (entity != null) {
                        bool isValidPassword = BCrypt.Net.BCrypt.Verify(obj.Senha, entity.Senha);
                        if (isValidPassword && obj.Email == entity.Email) {


                            var token = TokenService.GenerateToken(entity);
                            return Ok(new { entity = AutoMapperConfig.mapper.Map<UsuarioModel>(entity), token = token });
                        }
                        return BadRequest(obj);
                    } else {
                        return NoContent(obj);
                    }

                }
                return BadRequest(obj);

            } catch (Exception except) {

                throw except.InnerException;
            }
        }

        public void Dispose() {
            usuarioRepository.Dispose();
        }

        public async Task<Response> Get(int pagina, int quantidade, string userIdentity) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = AutoMapperConfig.mapper.Map<IEnumerable<UsuarioModel>>(await usuarioRepository.Get(pagina, quantidade));

                return Ok(entity);
            } else {
                return Unauthorized(userIdentity);
            }
        }

        public async Task<Response> GetDesligados(string userIdentity, int pagina = 0, int quantidade = 0) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = AutoMapperConfig.mapper.Map<IEnumerable<UsuarioModel>>(await usuarioRepository.GetDesligados(pagina, quantidade));

                return Ok(entity);
            } else {
                return Unauthorized(userIdentity);
            }
        }

        public async Task<Response> GetByOrdemAlfabetica(string userIdentity, int pagina = 0, int quantidade = 0) {
            Boolean isAdm = await HasPermission(userIdentity);

            if (isAdm) {
                var entity = AutoMapperConfig.mapper.Map<IEnumerable<UsuarioModel>>(await usuarioRepository.GetByOrdemAlfabetica(pagina, quantidade));

                return Ok(entity);
            } else {
                return Unauthorized(userIdentity);
            }
        }

        public async Task<Boolean> HasPermission(string email) {
            Usuario entity = await usuarioRepository.GetByEmail(email);
            if (entity == null) {
                return false;
            }
            return entity.HasPermission(); ;
        }
    }
}

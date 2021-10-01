using locadora_filmes.APPLICATION.Commons;
using locadora_filmes.APPLICATION.Interfaces;
using locadora_filmes.DOMAIN.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace locadora_filmes.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase {
        private readonly IUsuarioService usuarioService;
 

        public UsuarioController(IUsuarioService usuarioService) {
            this.usuarioService = usuarioService;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        [Authorize]
        public async Task<Response> GetAll() {
            var userIdentity = User.Claims.FirstOrDefault().Value;
            return await usuarioService.GetAll(userIdentity);



        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Response> Get(int id) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.GetById(id,userIdentity);

        }

        // GET api/<UsuarioController>/5
        [HttpGet("usuarios_desligados/")]
        [Authorize]
        public async Task<Response> GetDesligados([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.GetDesligados(userIdentity,pagina, quantidade);

        }

        // GET: api/<UsuarioController>
        [HttpGet("paginado")]
        [Authorize]
        public async Task<Response> Get([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.Get(pagina, quantidade, userIdentity);

        }

        // GET: api/<UsuarioController>
        [HttpGet("ordem_alfabetica")]
        [Authorize]
        public async Task<Response> GetByOrdemAlfabetica([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {
            var userIdentity = User.Claims.FirstOrDefault().Value;


            return await usuarioService.GetByOrdemAlfabetica(userIdentity,pagina, quantidade);

        }

        // GET api/<UsuarioController>/5
        [HttpGet("email/{email}")]
        [Authorize]
        public async Task<Response> GetByEmail(string email) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.GetByEmail(userIdentity,email);

        }

        // POST api/<UsuarioController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<Response> Post([FromBody] UsuarioModel value) {

            return await usuarioService.Add(value);
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("")]
        [Authorize]
        public async Task<Response> Put([FromBody] UsuarioModel value) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.Update(value, userIdentity);
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Response> Delete(int id) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await usuarioService.Remove(id, userIdentity);
        }

        // POST api/<HomeController>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UsuarioModel usuario) {
            return await usuarioService.Authenticate(usuario);
        }
    }
}

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
    public class FilmeController : ControllerBase {
        private readonly IFilmeService filmeService;
 

        public FilmeController(IFilmeService filmeService) {
            this.filmeService = filmeService;
        }

        // GET: api/<FilmeController>
        [HttpGet]
        [Authorize]
        public async Task<Response> GetAll() {
            return await filmeService.GetAll();



        }

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Response> Get(int id) {

            return await filmeService.GetById(id);

        }

        // GET api/<FilmeController>/5
        [HttpGet("filtros/")]
        [Authorize]
        public async Task<Response> GetByFilters([FromQuery] string diretor = "", [FromQuery] string titulo = "",
                                                    [FromQuery] List<string> generos = null, [FromQuery] List<string> atores = null,
                                                    [FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {

            return await filmeService.GetByFilters(diretor, titulo, generos, atores, pagina, quantidade);

        }

        // GET: api/<FilmeController>
        [HttpGet("paginado")]
        [Authorize]
        public async Task<Response> Get([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {

            return await filmeService.Get(pagina, quantidade);

        }

        // GET: api/<FilmeController>
        [HttpGet("ordem_alfabetica")]
        [Authorize]
        public async Task<Response> GetByOrdemAlfabetica([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {

            return await filmeService.GetByOrdemAlfabetica(pagina, quantidade);

        }

        // GET api/<FilmeController>/5
        [HttpGet("pontuacao")]
        [Authorize]
        public async Task<Response> GetByPontuacao([FromQuery] int pagina = 0, [FromQuery] int quantidade = 0, [FromQuery] decimal pontuacao = 0 ) {

            return await filmeService.GetByPontuacao(pagina,quantidade,pontuacao);

        }

        // POST api/<FilmeController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<Response> Post([FromBody] FilmeModel value) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await filmeService.Add(value,userIdentity);
        }

        // PUT api/<FilmeController>/5
        [HttpPut("")]
        [Authorize]
        public async Task<Response> Put([FromBody] FilmeModel value) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await filmeService.Update(value, userIdentity);
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Response> Delete(int id) {
            var userIdentity = User.Claims.FirstOrDefault().Value;

            return await filmeService.Remove(id, userIdentity);
        }
    }
}

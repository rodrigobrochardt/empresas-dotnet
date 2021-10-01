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
    public class VotoController : ControllerBase {
        private readonly IVotoService votoService;


        public VotoController(IVotoService votoService) {
            this.votoService = votoService;
        }


        // GET api/<VotoController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<Response> Get(int id) {

            return await votoService.GetById(id);

        }

        // GET api/<VotoController>/5
        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<Response> GetByUserId(int userId, [FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {

            return await votoService.GetByUserId(userId, pagina, quantidade);

        }

        // GET api/<VotoController>/5
        [HttpGet("filme/{filmeId}")]
        [Authorize]
        public async Task<Response> GetByFilmId(int filmeId, [FromQuery] int pagina = 0, [FromQuery] int quantidade = 0) {

            return await votoService.GetByFilmId(filmeId, pagina, quantidade);

        }

        // GET api/<VotoController>/5
        [HttpGet("user/{userId}/filme/{filmeId}")]
        [Authorize]
        public async Task<Response> GetByFilmId(int userId, int filmeId) {

            return await votoService.GetByUserAndFilm(userId, filmeId);

        }


        // POST api/<VotoController>
        [HttpPost]
        [Authorize]
        public async Task<Response> Post([FromBody] VotoModel value) {

            return await votoService.Add(value);
        }

        // PUT api/<VotoController>/5
        [HttpPut("")]
        [Authorize]
        public async Task<Response> Put([FromBody] VotoModel value) {

            return await votoService.Update(value);
        }

        // DELETE api/<VotoController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<Response> Delete(int id) {

            return await votoService.Remove(id);
        }
    }
}

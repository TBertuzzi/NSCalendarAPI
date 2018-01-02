using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSCalendarAPI.Models;
using NSCalendarAPI.Services;
using NSCalendarAPI.Helpers;

namespace NSCalendarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private readonly GameService _gameService;

        public GamesController()
        {
            _gameService = new GameService();
        }

        [HttpGet("{chave}")]
        public async Task<ActionResult> Get(string chave)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            var games = await _gameService.ObterGames();

            if (games == null) return NotFound();

            return Ok(games);
        }

        [HttpPost("{chave}")]
        public async Task<ActionResult> Post(string chave, [FromBody]Game game)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            await _gameService.InserirGame(game);

            return Ok();
        }

        [HttpPut("{chave}")]
        public async Task<ActionResult> Put(string chave, [FromBody]Game game)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            if (game.Id == 0) return NotFound();

            await _gameService.AtualizarGame(game);

            return Ok();
        }
    }
}
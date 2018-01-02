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

        // GET games/values
        [HttpGet("{chave}")]
        // public IEnumerable<Game> Get(string key)
        public async Task<ActionResult> Get(string chave)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            var games = await _gameService.ObterGames();

            if (games == null)
                return NotFound();

            return Ok(games);
        }

        [HttpPost("{chave}")]
        public ActionResult Post(string chave, [FromBody]Game game)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            _gameService.InserirGame(game);

            return Ok();
        }

    }
}
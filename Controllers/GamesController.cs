using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSCalendarAPI.Models;
using NSCalendarAPI.Services;
using NSCalendarAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace NSCalendarAPI.Controllers
{
    /// <summary>
    /// Serviço Correspondente a Games.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Games")]
    public class GamesController : Controller
    {
        private readonly GameService _gameService;

        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Obtem Todos os Games.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <returns>Todos os Games da Base</returns>
        /// <remarks>
        /// Retorna <c>404</c> Se não encontrar nenhum Game.
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave estiver vazia</response>       
        /// <response code="401">Se a chave estiver incorreta</response>     
        [HttpGet("{chave}")]
        public async Task<ActionResult> Get([Required]string chave)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            var games = await _gameService.ObterGames();

            if (games == null) return NotFound();

            return Ok(games);
        }

        /// <summary>
        /// Insere um novo Game.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <param name="game">Game para ser inserido</param>
        /// <returns>Resultado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave ou o game estiverem vazios</response>       
        /// <response code="401">Se a chave estiver incorreta</response>    
        [HttpPost("{chave}")]
        public async Task<ActionResult> Post([Required]string chave, [Required][FromBody]Game game)
        {
            if (string.IsNullOrEmpty(chave) || game == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            await _gameService.InserirGame(game);

            return Ok();
        }

        /// <summary>
        /// Atualiza um Game.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <param name="game">Game para ser atualizado</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Retorna <c>404</c> Se não encontrar o game para atualizar.
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave ou o game estiverem vazios</response>  
        /// <response code="401">Se a chave estiver incorreta</response> 
        [HttpPut("{chave}")]
        public async Task<ActionResult> Put([Required]string chave, [Required][FromBody]Game game)
        {
            if (string.IsNullOrEmpty(chave) || game == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            if (game.Id == 0) return NotFound();

            await _gameService.AtualizarGame(game);

            return Ok();
        }
    }
}
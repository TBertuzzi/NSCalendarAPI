using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSCalendarAPI.Services;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NSCalendarAPI.Controllers
{
    /// <summary>
    /// Serviço Correspondente a Screenshots.
    /// </summary>
    [Produces("application/json")]
    [Route("api/Screenshot")]
    public class ScreenshotController : Controller
    {
        private readonly ScreenshotService _screenshotService;

        public ScreenshotController(ScreenshotService screenshotService)
        {
            _screenshotService = screenshotService;
        }

        /// <summary>
        /// Obtem Todos as Screenshots.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <param name="idGame">Chave para utilizar a API</param>
        /// <returns>Todos os Games da Base</returns>
        /// <remarks>
        /// Retorna <c>404</c> Se não encontrar nenhuma Screenshot.
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave estiver vazia ou o IdGame for 0</response>       
        /// <response code="401">Se a chave estiver incorreta</response>     
        [HttpGet("{chave}/{idGame:int}")]
        public async Task<ActionResult> Get([Required]string chave, [Required]int idGame)
        {
            if (string.IsNullOrEmpty(chave) || idGame == 0) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            var screenshots = await _screenshotService.ObterScreenshots();

            if (screenshots == null) return NotFound();

            return Ok(screenshots);
        }

        /// <summary>
        /// Insere uma nova Screenshot.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <param name="screenshot">Screenshot para ser inserida</param>
        /// <returns>Resultado</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave ou a screenshot estiverem vazios</response>       
        /// <response code="401">Se a chave estiver incorreta</response>  
        [HttpPost("{chave}")]
        public async Task<ActionResult> Post([Required]string chave, [FromBody]Screenshot screenshot)
        {
            if (string.IsNullOrEmpty(chave) || screenshot == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            await _screenshotService.InserirScreenshot(screenshot);

            return Ok();
        }

        /// <summary>
        /// Atualiza uma Screenshot.
        /// </summary>
        /// <param name="chave">Chave para utilizar a API</param>
        /// <param name="screenshot">Screenshot para ser atualizada</param>
        /// <returns>Resultado</returns>
        /// <remarks>
        /// Retorna <c>404</c> Se não encontrar a screenshot para atualizar.
        /// </remarks>
        /// <response code="200">Sucesso</response>
        /// <response code="400">Se a chave ou a screenshot estiverem vazios</response>     
        /// <response code="401">Se a chave estiver incorreta</response> 
        [HttpPut("{chave}")]
        public async Task<ActionResult> Put([Required]string chave, [Required][FromBody]Screenshot screenshot)
        {
            if (string.IsNullOrEmpty(chave) || screenshot == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            if (screenshot.Id == 0) return NotFound();

            await _screenshotService.AtualizarScreenshot(screenshot);

            return Ok();
        }
    }
}
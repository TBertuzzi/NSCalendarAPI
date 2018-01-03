using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSCalendarAPI.Services;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Models;

namespace NSCalendarAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Screenshot")]
    public class ScreenshotController : Controller
    {
        private readonly ScreenshotService _screenshotService;

        public ScreenshotController(ScreenshotService screenshotService)
        {
            _screenshotService = screenshotService;
        }

        [HttpGet("{chave}/{idGame:int}")]
        public async Task<ActionResult> Get(string chave,int idGame)
        {
            if (string.IsNullOrEmpty(chave)) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            var screenshots = await _screenshotService.ObterScreenshots();

            if (screenshots == null) return NotFound();

            return Ok(screenshots);
        }

        [HttpPost("{chave}")]
        public async Task<ActionResult> Post(string chave, [FromBody]Screenshot screenshot)
        {
            if (string.IsNullOrEmpty(chave) || screenshot == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            await _screenshotService.InserirScreenshot(screenshot);

            return Ok();
        }

        [HttpPut("{chave}")]
        public async Task<ActionResult> Put(string chave, [FromBody]Screenshot screenshot)
        {
            if (string.IsNullOrEmpty(chave) || screenshot == null) return BadRequest();

            if (!Seguranca.VerificaChave(chave)) return Unauthorized();

            if (screenshot.Id == 0) return NotFound();

            await _screenshotService.AtualizarScreenshot(screenshot);

            return Ok();
        }
    }
}
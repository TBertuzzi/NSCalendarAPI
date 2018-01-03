using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSCalendarAPI.Models;
using NSCalendarAPI.Repository;

namespace NSCalendarAPI.Services
{
    public class ScreenshotService
    {
        private readonly ScreenshotRepository _screenshotRepository;
        public ScreenshotService(ScreenshotRepository screenshotRepository)
        {
            _screenshotRepository = screenshotRepository;
        }

        internal async Task<IEnumerable<Screenshot>> ObterScreenshots()
        {
            return await Task.Run(() => _screenshotRepository.ObterTodos());
        }

        internal async Task InserirScreenshot(Screenshot screenshot)
        {
            await Task.Run(() => _screenshotRepository.Inserir(screenshot));
        }

        internal async Task AtualizarScreenshot(Screenshot screenshot)
        {
            await Task.Run(() => _screenshotRepository.Atualizar(screenshot));
        }
    }
}

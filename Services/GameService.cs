using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSCalendarAPI.Models;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Repository;

namespace NSCalendarAPI.Services
{
    public class GameService
    {
        internal IEnumerable<Game> ObterGames()
        {
            GameRepository gameRepository = new GameRepository();
            return  gameRepository.ObterTodos();
        }

        internal void InserirGame(Game game)
        {
            GameRepository gameRepository = new GameRepository();
            gameRepository.Inserir(game);
        }

        internal async Task<IEnumerable<Game>> ObterGamesOrdenados()
        {
            GameRepository gameRepository = new GameRepository();
            return await gameRepository.ObterGamesOrdenados();
        }

        
    }
}

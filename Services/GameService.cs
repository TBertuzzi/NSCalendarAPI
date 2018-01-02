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
        internal async Task<IEnumerable<Game>> ObterGames()
        {
            GameRepository gameRepository = new GameRepository();

            //Game Teste = new Game();
            //Teste.Id = 1;
            //Teste.IdGame = 1;
            //Teste.ImgUrl = "";
            //Teste.Lancado = true;
            //Teste.Nome = "TESTE";
            //gameRepository.Inserir(Teste);


          
            return await gameRepository.ObterTodos();
        }

        internal void InserirGame(Game game)
        {
            GameRepository gameRepository = new GameRepository();
            gameRepository.Inserir(game);
        }
    }
}

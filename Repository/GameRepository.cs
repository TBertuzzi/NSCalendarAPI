using LiteDB;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Repository
{
    public class GameRepository : LiteDBConnection<Game>
    {
        public GameRepository()
        {
          
        }

        public async Task<IEnumerable<Game>> ObterGamesOrdenados()
        {
            var games = await Task.Run(() => _liteRepository.Query<Game>().ToEnumerable().OrderBy(x=> x.DataLancamento));
            return games;
        }

    }
}

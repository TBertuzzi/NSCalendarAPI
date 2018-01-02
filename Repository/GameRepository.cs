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

        public override IEnumerable<Game> ObterTodos()
        {
            return base.ObterTodos().OrderBy(x => x.DataLancamento);
        }
    }
}

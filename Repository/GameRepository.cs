using LiteDB;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Repository
{
    public class GameRepository
    {
        LiteDBConnection<Game> _liteDBConnection;
        public GameRepository()
        {
            _liteDBConnection = new LiteDBConnection<Game>();
        }

        public async Task<IEnumerable<Game>> ObterTodos()
        {

            return await _liteDBConnection.ObterTodos("DataLancamento");
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    // Get Games
            //    var games = db.GetCollection<Game>("games");

            //    // Index document using a document property
            //    games.EnsureIndex(x => x.DataLancamento);

            //    // Use Linq to query documents
            //    return games.FindAll();
            //}
        }

        public void Inserir(Game game)
        {
            _liteDBConnection.Inserir(game);
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    // Get Games
            //    var games = db.GetCollection<Game>("games");

            //    games.Insert(game);
            //}
        }

        public void Atualizar(Game game)
        {
            _liteDBConnection.Atualizar(game);
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    // Get Games
            //    var games = db.GetCollection<Game>("games");

            //    games.Update(game);
            //}
        }

        public Game ObterPorID(int id)
        {
            return _liteDBConnection.ObterPorID(id);
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    // Get Games
            //    var games = db.GetCollection<Game>("games");

            //    return games.Find(x => x.Id == Id).FirstOrDefault();
            //}
        }
    }
}

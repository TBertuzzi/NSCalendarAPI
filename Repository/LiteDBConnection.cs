using LiteDB;
using NSCalendarAPI.Helpers;
using NSCalendarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSCalendarAPI.Repository
{
    //Classe generica para Manipular as funções do LITEDB
    public class LiteDBConnection<T> where T : IModelBase
    {
        private string _tabela;
        LiteRepository _liteRepository;
        public LiteDBConnection()
        {
            _tabela = typeof(T).Name;
            _liteRepository = new LiteRepository(Constantes.DBName);
        }

        public async Task<IEnumerable<T>> ObterTodos(string index)
        {
            var games = await Task.Run(() => _liteRepository.Query<T>().ToEnumerable());


            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    var games = db.GetCollection<T>(_tabela);

            //    games.EnsureIndex(index);

            //    return await Task.Run(() => games.FindAll());
            //}

            return games;
        }

        public void Inserir(T item)
        {
            _liteRepository.Insert<T>(item);
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    var games = db.GetCollection<T>(_tabela);

            //    games.Insert(item);
            //}
        }

        public void Atualizar(T item)
        {
            _liteRepository.Update<T>(item);

            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    var games = db.GetCollection<T>(_tabela);

            //    games.Update(item);
            //}
        }

        public T ObterPorID(int id)
        {
            var game =  _liteRepository.Query<T>().Where(x => x.Id == id).ToEnumerable().FirstOrDefault();
            return game;
            //using (var db = new LiteDatabase(Constantes.DBName))
            //{
            //    var games = db.GetCollection<T> (_tabela);

            //    return games.Find(x => x.Id == Id).FirstOrDefault();
            //}
        }
    }
}

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
        public LiteRepository _liteRepository;
        public LiteDBConnection()
        {

            _liteRepository = new LiteRepository(Constantes.DBName);
        }

        public IEnumerable<T> ObterTodos()
        {
            var games = _liteRepository.Query<T>().ToEnumerable();
            return games;
        }

        public void Inserir(T item)
        {
            _liteRepository.Insert<T>(item);
        }

        public void Atualizar(T item)
        {
            _liteRepository.Update<T>(item);
        }

        public T ObterPorID(int id)
        {
            var game = _liteRepository.Query<T>().Where(x => x.Id == id).ToEnumerable().FirstOrDefault();
            return game;
        }
    }
}

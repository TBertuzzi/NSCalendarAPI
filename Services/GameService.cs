﻿using System;
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
        private readonly GameRepository _gameRepository;
        public GameService (GameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        internal async Task InserirGame(Game game)
        {
            await Task.Run(() => _gameRepository.Inserir(game));
        }

        internal async Task<IEnumerable<Game>> ObterGames()
        {
            return await Task.Run(() => _gameRepository.ObterTodos());
        }

        internal async Task AtualizarGame(Game game)
        {
            await Task.Run(() => _gameRepository.Atualizar(game));
        }
    }
}

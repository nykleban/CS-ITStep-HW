using GameStoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB.Repositories
{
    public interface IGame
    {
        void Add(Game game);
        Game? Get(int id);
        IEnumerable<Game> GetAll();
        void Update(Game updatedGame);
        void Remove(int id);
    }
}

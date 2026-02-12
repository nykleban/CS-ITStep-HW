using GameStoreDB.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB.Repositories
{
    public interface IGenre
    {
        void Add(Genre genre);
        Genre? Get(int id);
        IEnumerable<Genre> GetAll();
        void Update(Genre updatedGenre);
        void Remove(int id);
    }
}

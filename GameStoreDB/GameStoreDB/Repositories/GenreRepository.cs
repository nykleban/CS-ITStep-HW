using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using GameStoreDB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreDB.Repositories
{
    public class GenreRepository
    {
        public readonly AppDbContext context;
        public GenreRepository(AppDbContext context)
        {
            this.context = context;
        }
        private void save()
        {
            context.SaveChanges();
        }
        public void Add(Genre genre)
        {
           context.Genres.Add(genre);
           save();
        }

        public Genre? Get(int id)
        {
            return context.Genres.FirstOrDefault(g => g.Id == id);
        }
        public void Remove(int id)
        {
            var genre = Get(id);
            if (genre != null)
            {
                context.Genres.Remove(genre);
                save();
            }
        }


        public void Update(Genre updatedGenre)
        {
            var genre = Get(updatedGenre.Id);
            if (genre != null)
            {
                genre.Name = updatedGenre.Name;
                save();
            }
        }

        public IEnumerable<Genre> GetByGame(int gameId)
        {
            var genres = context.Games.Include(x=> x.Genres).First(g => g.Id == gameId).Genres.ToList();
            return genres;
        }
    }
}

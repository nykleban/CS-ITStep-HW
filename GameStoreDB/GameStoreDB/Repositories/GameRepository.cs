using System;
using System.Collections.Generic;
using System.Text;
using GameStoreDB.Entities;


namespace GameStoreDB.Repositories
{
    public class GameRepository : IGame
    {
        private readonly AppDbContext context;
        public GameRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(Game game)
        {
            context.Games.Add(game);
            save();
        }

        private void save()
        {
            context.SaveChanges();
        }

        public Game? Get(int id)
        {
            var game = context.Games.FirstOrDefault(g => g.Id == id);
            return game;

        }
        public IEnumerable<Game> GetAll()
        {
            return context.Games.ToList();
        }
        public void Update(Game updatedGame)
        {
            var game = Get(updatedGame.Id);
            if (game != null)
            {
                game.Name = updatedGame.Name;
                game.ReleaseDate = updatedGame.ReleaseDate;
                game.Rating = updatedGame.Rating;
                game.PublisherId = updatedGame.PublisherId;
                save();
            }
        }
        public void Remove(int id)
        {
            var game = Get(id);
            if (game != null)
            {
                context.Games.Remove(game);
                save();
            }
        }
      
        public IEnumerable<Game> GetByGenre(int genreId)
        {
            return context.Games.Where(g => g.Genres.Any(g => g.Id == genreId)).ToList();
        }
        public IEnumerable<Game> GetByPublisher(int publisherId)
        {
            return context.Games.Where(g => g.PublisherId == publisherId).ToList();
        }
    }
}
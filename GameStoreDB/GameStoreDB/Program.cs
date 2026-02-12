using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GameStoreDB.Entities;


namespace GameStoreDB
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var db = new AppDbContext();

            //eager loading
            var gamesWithGenres = await db.Games.Include(g => g.Genres).ToListAsync();

            //explicit loading
            var game = await db.Games.ToListAsync();
            foreach (var g in game)
            {
                await db.Entry(g).Collection(g => g.Genres).LoadAsync();
            }

            var gameRepo = new GameStoreDB.Repositories.GameRepository(db);
            var genreRepo = new GameStoreDB.Repositories.GenreRepository(db);


            //для виводу та Seed використав ГПТ, все інше написав сам
            // 1) Виводить всі ігри вказаного жанру
            Console.Write("\nВведи GenreId: ");
            if (int.TryParse(Console.ReadLine(), out int genreId))
            {
                var gamesByGenre = gameRepo.GetByGenre(genreId);

                Console.WriteLine($"\nІгри жанру (Id={genreId}):");
                foreach (var g in gamesByGenre)
                {
                    Console.WriteLine("- " + g);
                }
            }
            else
            {
                Console.WriteLine("❌ Невірний GenreId");
            }

            // 2) Виводить жанри вказаної гри
            Console.Write("\nВведи GameId: ");
            if (int.TryParse(Console.ReadLine(), out int gameId))
            {
                var genresOfGame = genreRepo.GetByGame(gameId);

                Console.WriteLine($"\nЖанри гри (GameId={gameId}):");
                foreach (var gen in genresOfGame)
                {
                    Console.WriteLine("- " + gen);
                }
            }
            else
            {
                Console.WriteLine("❌ Невірний GameId");
            }

            // 3) Виводить всі ігри видавця
            Console.Write("\nВведи PublisherId: ");
            if (int.TryParse(Console.ReadLine(), out int publisherId))
            {
                var gamesByPublisher = gameRepo.GetByPublisher(publisherId);

                Console.WriteLine($"\nІгри видавця (PublisherId={publisherId}):");
                foreach (var g in gamesByPublisher)
                {
                    Console.WriteLine("- " + g);
                }
            }
            else
            {
                Console.WriteLine("❌ Невірний PublisherId");
            }

           
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameStoreDB.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
        public double Rating { get; set; }  = 0.0;
        [ForeignKey("PublisherID")]
        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public ICollection<Genre> Genres = new HashSet<Genre>();
        public override string ToString()
        {
            return $"Game: {Name}, Rating: {Rating}, Genres: {Genres.Count}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Game> Games = new HashSet<Game>();

        public override string ToString()
        {
            return $"Genre: {Name}, Games: {Games.Count}";
        }

    }
}

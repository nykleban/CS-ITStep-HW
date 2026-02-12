using System;
using System.Collections.Generic;
using System.Text;

namespace GameStoreDB.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; } = 0;
        public string? Country { get; set; }
        public string? Email { get; set; }
        public ICollection<Game> Games = new HashSet<Game>();
        public override string ToString()
        {
            return $"Publisher: {Name}, Country: {Country}, Games: {Games.Count}";
        }
    }
}

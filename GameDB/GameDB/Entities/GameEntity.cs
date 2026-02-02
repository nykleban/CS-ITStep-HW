using System;
using System.Collections.Generic;
using System.Text;

namespace GameDB.Entities
{
    public class GameEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Studio { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;
        public GameMode Mode { get; set; }
        public int CopiesSold { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VolleyballDB.Entities
{
    internal class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> HomeGames { get; set; } = new();
        public List<Game> AwayGames { get; set; } = new();
    }
}

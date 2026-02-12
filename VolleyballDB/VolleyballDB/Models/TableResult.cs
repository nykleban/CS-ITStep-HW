using System;
using System.Collections.Generic;
using System.Text;
using VolleyballDB.Entities;

namespace VolleyballDB.Models
{
    internal class TableResult
    {
        public Team Team { get; set; }
        public int TotalPoints { get; set; }
        public int GamesPlayed { get; set; }

        public override string ToString()
        {
            return $"{Team.Name}\t/\t{GamesPlayed}\t/\t{TotalPoints}";
        }
    }
}

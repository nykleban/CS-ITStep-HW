using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VolleyballDB.Entities
{
    internal class Game
    {
        public int Id { get; set; }
        public Team TeamHome { get; set; }
        public Team TeamAway { get; set; }

        [ForeignKey(nameof(TeamHome))]
        public int TeamHomeId { get; set; }

        [ForeignKey(nameof(TeamAway))]
        public int TeamAwayId { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.DTO
{
    class Penalty
    {
        public string matchId { get; set; }
        public int team1Id { get; set; }

        public int team2Id { get; set; }
        public int team1Score { get; set; }
        public int team2Score { get; set; }

    }
}

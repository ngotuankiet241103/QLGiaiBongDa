using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.DTO
{
    class Tournament
    {
        public int tournamentId { get; set; }
        public string tournamentName { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string country { get; set; }
        public string description { get; set; }
    }
}

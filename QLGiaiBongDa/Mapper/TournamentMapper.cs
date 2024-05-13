using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class TournamentMapper : ModelMapper<Tournament>
    {
        private static TournamentMapper tournamentMapper = null;
        public Tournament map(DataRow row)
        {
            return new Tournament() {
                  tournamentId = Int32.Parse(row["tournament_id"].ToString()),
                  country = row["country"].ToString(),
                  description = row["description"].ToString(),
                  startDate = DateTime.Parse(row["start_date"].ToString()),
                  endDate = DateTime.Parse(row["end_date"].ToString()),
                  tournamentName = row["tournament_name"].ToString()
            };
        }
        public static TournamentMapper GetInstance()
        {
            if (tournamentMapper == null)
            {
                tournamentMapper = new TournamentMapper();
            }
            return tournamentMapper;
        }
    }
}

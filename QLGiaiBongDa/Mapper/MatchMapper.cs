using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class MatchMapper : ModelMapper<Matches>
    {
        private static MatchMapper matchMapper = null;
        public Matches map(DataRow row)
        {
            return new Matches() {
                homeTeamId = Int32.Parse(row["home_team_id"].ToString()),
                awayTeamId = Int32.Parse(row["away_team_id"].ToString()),
                matchId = row["match_id"].ToString(),
                matchDate = DateTime.Parse(row["match_date"].ToString())
            };
        }
        public static MatchMapper GetInstance()

        {
            if(matchMapper == null)
            {
                matchMapper = new MatchMapper();
            }
            return matchMapper;
        }
    }
}

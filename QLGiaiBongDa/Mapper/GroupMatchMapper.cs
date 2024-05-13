using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class GroupMatchMapper : ModelMapper<GroupMatch>
    {
        private static GroupMatchMapper group = null;
        public GroupMatch map(DataRow row)
        {
            return new GroupMatch() {
                homeTeamId = Int32.Parse(row["home_team_id"].ToString()),
                awayTeamId = Int32.Parse(row["away_team_id"].ToString()),
                matchId = row["match_id"].ToString(),
                matchDate = DateTime.Parse(row["match_date"].ToString()),

            };
        }
        public static GroupMatchMapper GetInstance()
        {
            if (group== null)
            {
                group = new GroupMatchMapper();
            }
            return group;
        }

    }
}

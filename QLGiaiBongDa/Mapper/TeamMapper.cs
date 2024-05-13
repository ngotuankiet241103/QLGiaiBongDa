using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class TeamMapper : ModelMapper<Team>
    {
        private static TeamMapper teamMapper = null;
        public Team map(DataRow row)
        {
            return new Team()
            {
                teamId = Int32.Parse(row["team_id"].ToString()),
                teamName = row["team_name"].ToString(),
                country = row["country"].ToString()
            };
        }
        public static TeamMapper GetInstance()
        {
            if (teamMapper == null)
            {
                teamMapper = new TeamMapper();
            }
            return teamMapper;
        }
    }
}

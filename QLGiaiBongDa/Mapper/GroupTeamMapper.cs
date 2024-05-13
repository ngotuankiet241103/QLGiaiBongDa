using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class GroupTeamMapper : ModelMapper<GroupTeam>
    {
        private static GroupTeamMapper groupTeamMapper = null;
        public GroupTeam map(DataRow row)
        {
            return new GroupTeam() { 
              
                win = Int32.Parse(row["win"].ToString()),
                draw  = Int32.Parse(row["draw"].ToString()),
                lose = Int32.Parse(row["lose"].ToString()),
                num = Int32.Parse(row["num"].ToString()),
                point  = Int32.Parse(row["point"].ToString()),
                teamId = Int32.Parse(row["teamId"].ToString())

            };
        }
        public static GroupTeamMapper GetInstance()
        {
            if (groupTeamMapper == null)
            {
                groupTeamMapper = new GroupTeamMapper();
            }
            return groupTeamMapper;

        }
    }
}
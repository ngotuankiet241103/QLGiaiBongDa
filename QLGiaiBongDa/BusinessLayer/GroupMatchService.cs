using QLGiaiBongDa.DTO;
using QLGiaiBongDa.Mapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class GroupMatchService : BaseServiceImpl<GroupMatch>
    {
        private static GroupMatchMapper group = GroupMatchMapper.GetInstance();
        public GroupMatch findByMatchId(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
         {
                new SqlParameter("@matchId",matchId)
         };
            return findOne("SP_GroupMatches_SelectByMatchId", group, sqlParameters);
        }
        public void updateByMatchId(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
         {
                new SqlParameter("@matchId",matchId)
         };
            save("SP_GroupMatches_Update", sqlParameters);
        }
        private SqlParameter[] createParam(GroupMatch groupMatch)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@home_team_id",groupMatch.homeTeamId),
                    new SqlParameter("@away_team_id",groupMatch.awayTeamId),
                    new SqlParameter("@match_date",groupMatch.matchDate),
                    new SqlParameter("@group_id",groupMatch.groupId)
            };
            return sqlParameters;
        }
        internal void saveGroupMatch(GroupMatch groupMatch)
        {
            save("SP_GroupMatches_Save", createParam(groupMatch));
        }

        internal void finishMatch(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
        {
                new SqlParameter("@matchId",matchId)
        };
            save("SP_GroupMatches_Finish", sqlParameters);
        }
    }
}

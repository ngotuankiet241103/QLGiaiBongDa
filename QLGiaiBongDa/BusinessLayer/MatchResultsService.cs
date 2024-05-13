using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class MatchResultsService : BaseServiceImpl<MatchResults>
    {
        public DataTable getByGroupId(int groupId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter("@groupId",groupId)
           };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_GroupMatches_Select", sqlParameters);
        }
        public void saveMatchResult(MatchResults matchResults)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                    new SqlParameter("@matchId",matchResults.matchId),
                    new SqlParameter("@homeTeamScore",matchResults.homeTeamScore),
                    new SqlParameter("@awayTeamScore",matchResults.awayTeamScore),
             };
            save("SP_MatchResuls_Save", sqlParameters);
        }
        public void updateMatchResult(string matchId, Boolean isHomeTeam,int score)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@matchId",matchId),
                    new SqlParameter("@isHomeTeam",isHomeTeam),
                    new SqlParameter("@score",score),
            };
            save("SP_MatchResults_Update", sqlParameters);
        }

        
    }
}

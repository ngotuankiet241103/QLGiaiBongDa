using QLGiaiBongDa.DTO;
using QLGiaiBongDa.Mapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class MatchesService : BaseServiceImpl<Matches>
    {
        private static MatchMapper matchMapper = MatchMapper.GetInstance();
        private SqlParameter[] createParam(Matches matches)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@knockoutMatches_id", matches.knockoutMatchId),
                new SqlParameter("@match_date",matches.matchDate),
                new SqlParameter("@home_team_id",matches.homeTeamId),
                new SqlParameter("@away_team_id",matches.awayTeamId)
           

             };
            return sqlParameters;

        }
        public void saveMatches(Matches matches)
        {
            save("SP_Matches_Save", createParam(matches));
        }

        internal DataTable findByKnockoutMatchId(int knockoutMatchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                new SqlParameter("@knockoutMatchId", knockoutMatchId),
           


             };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_Match_SelectByKnockoutMatchId", sqlParameters);
        }

        internal Matches findByMatchId(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@matchId", matchId),
             };
            return findOne("SP_Match_SelectByMatchId",matchMapper,sqlParameters);
        }

        internal void finishMatch(string matchId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
                {
                new SqlParameter("@matchId", matchId),
             };
            save("SP_Matches_Finish",sqlParameters);
        }
    }
}

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
    class TeamService : BaseServiceImpl<Team>
    {
        private static TeamMapper teamMapper = TeamMapper.GetInstance();
        public Team findById(int id)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
         {
                new SqlParameter("@teamId",id)
         };
            return findOne("SP_Team_SelectById",teamMapper , sqlParameters);
        }
        private SqlParameter[] createPram(Team team)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
         {
                new SqlParameter("@teamId",team.teamId),
                new SqlParameter("@teamName",team.teamName),
                new SqlParameter("@country",team.country)
         };
            return sqlParameters;
        }

        internal object findAllByTournamentId(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                        new SqlParameter("@tournamentId",tournamentId)
               };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_TournamentTeam_SELECT", sqlParameters);
        }

        internal List<Team> findTeamByTournamentId(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                        new SqlParameter("@tournamentId",tournamentId)
               };

            return findByCondition("SP_TournamentTeam_SelectByTournamentId", teamMapper, sqlParameters);
        }
        internal object findAll()
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable,"SP_Teams_Select",null);
        }

        public void saveTeam(Team team)
        {
            save("SP_Team_Save", createPram(team));
        }
        internal bool existTeamName(string teamName)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
       {
                new SqlParameter("@teamName",teamName)
       };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table,"SP_Team_ExistTeamName", sqlParameters).Rows.Count > 0;
        }

        internal DataTable findByTournamentId(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
               {
                        new SqlParameter("@tournamentId",tournamentId)
               };
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_Team_SelectByTournamentId", sqlParameters);
        }
    }
}

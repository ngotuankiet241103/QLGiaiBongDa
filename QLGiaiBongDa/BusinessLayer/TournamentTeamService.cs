using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.BusinessLayer
{
    class TournamentTeamService : BaseServiceImpl<TournamentTeam>
    {
        public void saveTournamentTeam(TournamentTeam tournamentTeam)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                    new SqlParameter("@tournamentId", tournamentTeam.tournamentId),
                    new SqlParameter("@teamId", tournamentTeam.teamId),
                  
             };
            save("SP_Tournament_Team_Save", sqlParameters);
        }

        internal void deleteByTournamentId(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@tournamentId", tournamentId)
                    

            };
            save("SP_Tournament_Team_Delete", sqlParameters);
        }
    }
}

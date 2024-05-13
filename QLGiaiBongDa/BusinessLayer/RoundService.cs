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
    class RoundService : BaseServiceImpl<Round>
    {
        private RoundMapper roundMapper = RoundMapper.GetInstance();
        public List<Round> findAllByTournamentId(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@tournamentId",tournamentId)
            };
            return findByCondition("SP_Rounds_Select", roundMapper, sqlParameters);
        }
        private SqlParameter[] createParam(Round round)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
               new SqlParameter("@id",round.roundId),
                new SqlParameter("@tournamentId",round.touramentId),
                new SqlParameter("@roundName",round.roundName),
                new SqlParameter("@startDate",round.startDate),
                new SqlParameter("@endDate",round.endDate)

           };
            return sqlParameters;
        }
        public int saveRound(Round round)
        {
            return save("SP_Round_Save", createParam(round));
        }
    }
}

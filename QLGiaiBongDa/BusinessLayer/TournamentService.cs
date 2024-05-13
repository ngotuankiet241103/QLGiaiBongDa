using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DataLayer;
using System.Data;
using QLGiaiBongDa.DTO;
using System.Data.SqlClient;
using QLGiaiBongDa.Mapper;

namespace QLGiaiBongDa.BusinessLayer
{
    class TournamentService : BaseServiceImpl<Tournament>
    {
        private static TournamentMapper tournamentMapper = TournamentMapper.GetInstance();
        public TournamentService()
        {
        }
        public DataTable getAllTournament(ref string err)
        {
            DataTable table = new DataTable();
            return DB.GetDataTable(ref table, "SP_Tournament_Select",null);
        }
        private SqlParameter[] createParam(Tournament tournament)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                    new SqlParameter("@id", tournament.tournamentId),
                    new SqlParameter("@name", tournament.tournamentName),
                    new SqlParameter("@startDate", tournament.startDate),
                    new SqlParameter("@endDate", tournament.endDate),
                    new SqlParameter("@country", tournament.country),
                    new SqlParameter("@description", tournament.description)
             };
            return sqlParameters;
        }

        internal DataTable findAll()
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable,"SP_Tournament_Select", null);
        }

        public void saveTournament(Tournament tournament)
        {
            save("SP_Tournament_Save", createParam(tournament));
        }

        internal Tournament findById(int tournamentId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
             {
                    new SqlParameter("@id", tournamentId),

             };
            return findOne("SP_Tournament_Select", tournamentMapper, sqlParameters);
        }
    }
}

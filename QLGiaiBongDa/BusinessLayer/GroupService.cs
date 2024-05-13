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
    class GroupService : BaseServiceImpl<Group>
    {
        private static GroupMapper groupMapper = GroupMapper.GetInstance();
       public List<Group> findByRoundId(int roundId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
          {
                new SqlParameter("@roundId",roundId)
          };
            return findByCondition("SP_Groups_Select", groupMapper, sqlParameters);
        }
        private SqlParameter[] createParam(Group group)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
         {
               new SqlParameter("@id", group.groupId),
               new SqlParameter("@groupName",group.groupName),
               new SqlParameter("@roundId",group.roundId),
               new SqlParameter("@startDate",group.startDate), 
               new SqlParameter("@endDate", group.endDate),
               new SqlParameter("@maxTeam", 4)

         };
            return sqlParameters;
        }
        public int saveGroup(Group group)
        {
            return save("SP_Group_Save", createParam(group));
            
        }


    }
}

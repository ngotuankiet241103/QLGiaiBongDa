using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    class GroupMapper : ModelMapper<Group>
    {
        private static GroupMapper groupMapper = null;
        public Group map(DataRow row)
        {
            return new Group() { 
                roundId = Int32.Parse(row["round_id"].ToString()),
                groupId = Int32.Parse(row["group_id"].ToString()),
                groupName = row["group_name"].ToString(),
                startDate = DateTime.Parse(row["start_date"].ToString()),
                endDate = DateTime.Parse(row["end_date"].ToString())

            };
        }
        public static GroupMapper GetInstance()
        {
            if (groupMapper == null)
            {
                groupMapper = new GroupMapper();
            }
            return groupMapper;
        }
    }
}

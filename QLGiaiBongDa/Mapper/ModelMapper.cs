using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiaiBongDa.Mapper
{
    interface ModelMapper<T>
    {
        T map(DataRow row);
    }
}

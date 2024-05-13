using QuanLyBanHang.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace QLGiaiBongDa.BusinessLayer
{
    class System : BaseServiceImpl<DTO.User>
    {
        
      

        public DataTable LoginCheck(ref string err, string userName, string password)
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable, "SP_User_Login",
                  new SqlParameter("@Account", userName),
                  new SqlParameter("@AccPass", password));
        }

        public DataTable GetGroupUser(ref string err)
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable, "SP_GroupUser_SelectToCombo", null);
        }

        internal object findAll()
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable, "SP_Users_Select", null);
        }

        internal void saveAccount(DTO.User user)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@GroupID", user.groupId),
                new SqlParameter("@FullName", user.fullName),
                new SqlParameter("@UserName", user.userName),
                new SqlParameter("@Password", user.password),
                new SqlParameter("@UserId", user.userId)
            };
            save("SP_Users_Save", sqlParameters);
        }

        internal string updatePassword(string password, string newPassword)
        {
            string userId = Cls_Main.maNguoiDung;
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@Password", password),
                new SqlParameter("@NewPassword", newPassword),
                new SqlParameter("@UserId", userId)
            };
            DataRow row = null;
           return DB.GetOneRow(ref row,"SP_Users_UpdatePassword", sqlParameters)["Message"].ToString();
        }

        internal DataRow findByUserId(int userId)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@UserId", userId)
            
            };
            DataRow row = null;
            return DB.GetOneRow(ref row, "SP_Users_Select", sqlParameters);
        }

        public DataTable GetFunctionListByUser(ref string err, string groupID)
        {
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("@GroupID", groupID)
            };
            return DB.GetDataTable(ref dataTable, "SP_Decentralize_SelectToGrid", sqlParameters);
        }

        public int UpdateDecentralize(ref string err, string funcId, string groupId, int tong)
        {
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[] {
                 new SqlParameter("@FuncID", funcId),
                 new SqlParameter("@GroupID", groupId),
                 new SqlParameter("@Total", tong)
            };
            return DB.GetDataTable(ref dataTable, "SP_Decentralize_InsertAndUpdate", sqlParameters).Rows.Count;
        }

        internal object getAllGroupUser()
        {
            DataTable dataTable = new DataTable();
            return DB.GetDataTable(ref dataTable, "SP_GroupUser_Select", null);
        }

        public DataTable GetPermissionList(ref string err, string userId)
        {
            DataTable dataTable = new DataTable();
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", Int32.Parse(userId))
            };
            return DB.GetDataTable(ref dataTable, "SP_Decentralize_Select", sqlParameters);
        }

    }
}

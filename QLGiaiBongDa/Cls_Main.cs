using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGiaiBongDa
{
    class Cls_Main
    {
        public static string path = "server=MSI\\SQLEXPRESS; database=QuanLyGiaiBongDa; Integrated Security=True";

        public static string tenNguoiDung = string.Empty;
        public static string maNguoiDung = string.Empty;
        public static Hashtable htbPermission = new Hashtable();

        public static bool CheckQuyen(Form frm, QUYEN quyen)
        {
            foreach (string key in htbPermission.Keys)
            {
                if (key.Equals(frm.Name))
                {
                    return (Convert.ToInt32(htbPermission[key].ToString()) & ((int)quyen)) == ((int)quyen) ? true : false;
                    //15&2==2?true:false
                }
            }
            return false;
        }

        public static void DinhDangDatagridView(DataGridView dgv)
        {
            dgv.Font = new Font("Arial", 12F, FontStyle.Regular);
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
            {
                BackColor = Color.DarkGray,
            };
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12F, FontStyle.Bold),
            };
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowTemplate.Height = 32;
            dgv.BackgroundColor = Color.White;
        }

        internal static void logout()
        {
            tenNguoiDung = string.Empty;
            maNguoiDung = string.Empty;
            htbPermission = new Hashtable();
        }
    
    }
}

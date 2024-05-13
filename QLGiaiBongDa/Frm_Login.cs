using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.DataLayer;

namespace QLGiaiBongDa
{
    public partial class Frm_Login : Form
    {

        BusinessLayer.System db;
        string err = string.Empty;
        DataTable dtUser;
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            db = new BusinessLayer.System();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                if (!string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    if (loginCheck(txtTaiKhoan.Text, txtMatKhau.Text))
                    {
                        Cls_Main.tenNguoiDung = dtUser.Rows[0]["UserName"].ToString();
                        Cls_Main.maNguoiDung = dtUser.Rows[0]["UserId"].ToString();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Thong tin tai khoan khong dung");
                    }
                }
                else
                {
                    MessageBox.Show("Chua nhap mat khau");
                }
            }
            else
            {
                MessageBox.Show("Chua nhap tai khoan");
            }
        }

        private bool loginCheck(string taiKhoan, string matKhau)
        {
            dtUser = new DataTable();
            dtUser = db.LoginCheck(ref err, taiKhoan, matKhau);
            if (dtUser.Rows.Count > 0)
            {
                if (dtUser.Rows[0]["Code"].ToString().Equals("1"))
                {
                    GetPermissionValue(dtUser.Rows[0]["UserId"].ToString());
                    return true;
                }
            }
            return false;
        }

        private void GetPermissionValue(string userId)
        {
           
            DataTable dtQuyen = new DataTable();
            dtQuyen = db.GetPermissionList(ref err, userId);

            if (dtQuyen.Rows.Count > 0)
            {
                Cls_Main.htbPermission = new Hashtable();
                foreach (DataRow item in dtQuyen.Rows)
                {
                    string total = !item["Total"].ToString().Equals("")? item["Total"].ToString() : "0";
                    Cls_Main.htbPermission.Add(item["Alias"], Convert.ToInt32(total));
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_SignUp frm_SignUp = new Frm_SignUp();
            frm_SignUp.ShowDialog();
        }
    }
}

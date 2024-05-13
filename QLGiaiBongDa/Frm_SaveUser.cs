using QLGiaiBongDa.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGiaiBongDa
{
    public partial class Frm_SaveUser : Form
    {
        public Frm_SaveUser()
        {
            InitializeComponent();
        }
        private int UserId = 0;
        private BusinessLayer.System accountService;
        private User user;
        public Frm_SaveUser(int userId)
        {
            this.UserId = userId;
           
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            String fullName = txtFullName.Text;
            String userName = txtUserName.Text;
            String password = cboRole.Text;
           
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || cboRole.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ");
                return;
            }
            user = new User()
            {
                userId = this.UserId,
                fullName = fullName,
                userName = userName,
                password = password,
                groupId = Int32.Parse(cboRole.SelectedValue.ToString())

            };
            accountService.saveAccount(user);
            this.Close();
        }

        private void Frm_SaveUser_Load(object sender, EventArgs e)
        {
            this.accountService = new BusinessLayer.System();
            loadCbo();
            if (UserId > 0)
            {
                this.txtPassword.Enabled = false;
                DataRow row = accountService.findByUserId(this.UserId);
                txtFullName.Text = row["FullName"].ToString();
                txtUserName.Text = row["Account"].ToString();
                cboRole.SelectedValue = row["GroupId"];
            }
           
        }
        private void loadCbo()
        {
            cboRole.DataSource = accountService.getAllGroupUser();
            cboRole.ValueMember = "GroupId";
            cboRole.DisplayMember = "GroupName";
            cboRole.SelectedIndex = -1;
            cboRole.Text = "Chọn vai trò";
        }
    }
}

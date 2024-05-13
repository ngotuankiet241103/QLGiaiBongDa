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
    public partial class Frm_SignUp : Form
    {
        public Frm_SignUp()
        {
            InitializeComponent();
        }
        BusinessLayer.System accountService;


        private void button1_Click(object sender, EventArgs e)
        {
            String fullName = txtFullName.Text;
            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            if(string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin ");
                return;
            }
            User user = new User() { 
                fullName = fullName,
                userName = userName,
                password = password,
                groupId = 0
            
            };
            accountService.saveAccount(user);

        }

        private void Frm_SignUp_Load(object sender, EventArgs e)
        {
            this.accountService = new BusinessLayer.System();
        }
    }
}

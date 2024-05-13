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
    public partial class Frm_ChangePassword : Frm_Base
    {
        public Frm_ChangePassword()
        {
            InitializeComponent();
        }
        BusinessLayer.System userService;
        private void button1_Click(object sender, EventArgs e)
        {
            String password = textBox1.Text;
            String newPassword = textBox2.Text;
            String confirmPass = textBox3.Text;
            if(string.IsNullOrEmpty(password) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (!newPassword.Equals(confirmPass)){
                MessageBox.Show("Mật khẩu không giống ");
            }
            userService = new BusinessLayer.System();
            String message =  userService.updatePassword(password, newPassword);
            MessageBox.Show(message);
            clearTextBox();
        }
        private void clearTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}

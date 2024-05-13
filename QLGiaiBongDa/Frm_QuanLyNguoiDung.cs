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
    public partial class Frm_QuanLyNguoiDung : Frm_Base
    {
        public Frm_QuanLyNguoiDung()
        {
            InitializeComponent();
        }
        private BusinessLayer.System userService;
        private void Frm_QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            userService = new BusinessLayer.System();
            loadUsers();
        }

        private void loadUsers()
        {
            dataGridView1.DataSource = userService.findAll();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_SaveUser frm = new Frm_SaveUser();
            frm.ShowDialog();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count < 1)
            {
                MessageBox.Show("Vui lòng chọn người dùng ");
                return;
            }
            int userId = Int32.Parse(dataGridView1.SelectedRows[0].Cells["userId"].Value.ToString());
            Frm_SaveUser frm_SaveUser = new Frm_SaveUser(userId);
            frm_SaveUser.ShowDialog();
        }
    }
}

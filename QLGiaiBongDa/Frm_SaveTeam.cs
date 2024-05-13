using QLGiaiBongDa.BusinessLayer;
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
    public partial class Frm_SaveTeam : Form
    {
        private int teamId = 0;
        public Frm_SaveTeam()
        {
            InitializeComponent();
        }
        public Frm_SaveTeam(int id)
        {
            this.teamId = id;
            InitializeComponent();
        }
        private TeamService teamService;
        private void Frm_SaveTeam_Load(object sender, EventArgs e)
        {
            teamService = new TeamService();
            if (teamId > 0)
            {
                this.label1.Text = "Cập nhập đội bóng";
                this.btnSave.Text = "Sửa";
            }
            else
            {
                this.label1.Text = "Thêm đội bóng";
                this.btnSave.Text = "Thêm";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ");
                return;
            }
            string teamName = textBox1.Text;
            string country = textBox2.Text;
            Boolean check = teamService.existTeamName(teamName);
            if (check)
            {
                MessageBox.Show("Tên đội bóng đã tồn tại");
                return;
            }
            Team team = new Team() { 
                teamId = 0,
                teamName = teamName,
                country = country            
            };
            teamService.saveTeam(team);
            this.Close();
        }
    }
}

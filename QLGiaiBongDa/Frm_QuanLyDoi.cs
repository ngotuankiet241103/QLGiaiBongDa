using QLGiaiBongDa.BusinessLayer;
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
    public partial class Frm_QuanLyDoi : Frm_Base
    {
        public Frm_QuanLyDoi()
        {
            InitializeComponent();
        }
        TeamService teamService;
        private void Frm_QuanLyDoi_Load(object sender, EventArgs e)
        {
            teamService = new TeamService();
            loadTeams();
        }
        private void loadTeams()
        {
            dataGridView1.DataSource = teamService.findAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_SaveTeam frm_SaveTeam = new Frm_SaveTeam();
            frm_SaveTeam.ShowDialog();
            loadTeams();
        }

        
    }
}

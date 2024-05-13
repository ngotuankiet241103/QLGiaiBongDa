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
    public partial class Frm_QuanLyCauThu : Frm_Base
    {
        public Frm_QuanLyCauThu()
        {
            InitializeComponent();
        }
        private TeamService teamService;
        private PlayerService playerService;
        private void Frm_QuanLyCauThu_Load(object sender, EventArgs e)
        {
            teamService = new TeamService();
            playerService = new PlayerService();
            loadCbo();
        }
        private void loadCbo()
        {
            comboBox1.DataSource = teamService.findAll();
            comboBox1.ValueMember = "team_id";
            comboBox1.DisplayMember = "team_name";
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = "-- Team --";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex >= -1 && comboBox1.SelectedValue != null)
            {
                try
                {
                    int value = Int32.Parse(comboBox1.SelectedValue.ToString());
                    dataGridView1.DataSource = playerService.getByTeamId(value);
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_SavePlayer frm = new Frm_SavePlayer();
            frm.ShowDialog();
            comboBox1.SelectedIndex = 0;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void btnThemExcel_Click(object sender, EventArgs e)
        {
            Frm_SavePlayerByFile frm = new Frm_SavePlayerByFile();
            frm.ShowDialog();
            comboBox1.SelectedIndex = 0;
        }
    }
}

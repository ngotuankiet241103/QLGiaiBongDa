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
    public partial class Frm_QuanlyDoiTG : Frm_Base
    {
        public Frm_QuanlyDoiTG()
        {
            InitializeComponent();
        }

        private TournamentService tournamentService;
        private TeamService teamService;
        private void Frm_QuanlyDoiTG_Load(object sender, EventArgs e)
        {
            tournamentService = new TournamentService();
            teamService = new TeamService();
            loadCbo();
        }
        private void loadCbo()
        {
            cboTournaments.DataSource = tournamentService.findAll();
            cboTournaments.ValueMember = "tournament_id";
            cboTournaments.DisplayMember = "tournament_name";
            cboTournaments.SelectedIndex = -1;
            cboTournaments.Text = "-- Choose tournament";
        }
        int tournamentId;
        private void cboTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTournaments.SelectedIndex < 0)
            {
                return;
            }

            if (cboTournaments.SelectedIndex >= 0)
            {
                try
                {
                      
                    tournamentId = Int32.Parse(cboTournaments.SelectedValue.ToString());
                    
                    dataGridView1.DataSource = teamService.findByTournamentId(tournamentId).DefaultView;
                }
                catch (Exception ex)
                {

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cboTournaments.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giải đấu");
                return;
            }
            
            Frm_SaveTournamentTeam frm = new Frm_SaveTournamentTeam(tournamentId);
            frm.ShowDialog();
        }

        private void cboTournaments_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}

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
    public partial class Frm_SaveTournamentTeam : Form
    {
        public Frm_SaveTournamentTeam()
        {
            InitializeComponent();
        }
        private int tournamentId;
        public Frm_SaveTournamentTeam(int id)
        {
            this.tournamentId = id;
            InitializeComponent();
        }
        TeamService teamService;
        TournamentTeamService tournamentTeamService;
        private void Frm_SaveTournamentTeam_Load(object sender, EventArgs e)
        {
            teamService = new TeamService();
            tournamentTeamService = new TournamentTeamService();
            dataGridView1.DataSource = teamService.findAllByTournamentId(this.tournamentId);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tournamentTeamService.deleteByTournamentId(this.tournamentId);
            for(int i=0;i <= dataGridView1.Rows.Count - 2; i++)
            {
               
                Boolean isChoose = Boolean.Parse(dataGridView1.Rows[i].Cells["isChoose"].Value.ToString());
                if (isChoose)
                {
                    int teamId = Int32.Parse(dataGridView1.Rows[i].Cells["teamId"].Value.ToString());
                  
                    TournamentTeam tournamentTeam = new TournamentTeam() { 
                        tournamentId = this.tournamentId,
                        teamId = teamId
                    
                    };
                    tournamentTeamService.saveTournamentTeam(tournamentTeam);
                }
            }
        }
    }
}

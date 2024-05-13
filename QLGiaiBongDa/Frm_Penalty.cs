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
    public partial class Frm_Penalty : Form
    {
        public Frm_Penalty()
        {
            InitializeComponent();
        }
        private string matchId;
        public Frm_Penalty(string matchId)
        {
            this.matchId = matchId;
            InitializeComponent();
        }
        private MatchesService matchService;
        private Matches matches;
        private TeamService teamService;
        private PenaltyService penaltyService;
        private void Frm_Penalty_Load(object sender, EventArgs e)
        {
            matchService = new MatchesService();
            teamService = new TeamService();
            penaltyService = new PenaltyService();
            loadMatch();
        }
        private void loadMatch()
        {
            matches = matchService.findByMatchId(this.matchId);
            this.team1.Text = teamService.findById(matches.homeTeamId).teamName + "";
            this.team2.Text = teamService.findById(matches.awayTeamId).teamName + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int homeTeamScore = Int32.Parse(textBox1.Text);
            int awayTeamScore = Int32.Parse(textBox2.Text);
            Penalty penalty = new Penalty() { 
                matchId = this.matchId,
                team1Id = matches.homeTeamId,
                team1Score = homeTeamScore,
                team2Id = matches.awayTeamId,
                team2Score = awayTeamScore
            };
            penaltyService.savePenalty(penalty);
        }
    }
}

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
   
    public partial class Frm_Goal : Form
    {
        private string matchId;
        private GroupMatch groupMatch;
        private int knockoutMatchId = 0;
        private Match match;
        public Frm_Goal()
        {
            InitializeComponent();
        }
        public Frm_Goal(string matchId)
        {
            this.matchId = matchId;
            InitializeComponent();
        }
        public Frm_Goal(string matchId,int knockoutMatchId)
            {
                this.matchId = matchId;
            this.knockoutMatchId = knockoutMatchId;
                InitializeComponent();
            }
        private GroupMatchService groupMatchService;
        private TeamService teamService;
        private PlayerService playerService;
        private GoalService goalService;
        private GroupTeamService groupTeam;
        private MatchResultsService matchResultsService;
        private MatchesService matchesService;
        private KnockoutMatchService knockoutMatchService;
        private void Frm_Goal_Load(object sender, EventArgs e)
        {
            this.txtMatch.Text = this.matchId;
            groupMatchService = new GroupMatchService();
            teamService = new TeamService();
            playerService = new PlayerService();
            goalService = new GoalService();
            groupTeam = new GroupTeamService();
            matchResultsService = new MatchResultsService();
            matchesService = new MatchesService();
            knockoutMatchService = new KnockoutMatchService();
            load();
        }
        private void load()
        {
            if(knockoutMatchId == 0)
            {

                groupMatch = groupMatchService.findByMatchId(this.matchId);
                loadComboTeam(groupMatch.homeTeamId,groupMatch.awayTeamId);
            }
            else
            {
                match = matchesService.findByMatchId(this.matchId);
                loadComboTeam(match.homeTeamId, match.awayTeamId);
            }
        }
        private Team home = null;
        private Team away = null;
        private void loadComboTeam(int homeTeamId,int awayTeamId)
        {
            home = teamService.findById(homeTeamId);
            away = teamService.findById(awayTeamId);

            loadTeamToCombo();
        }
        private void loadTeamToCombo()
        {
            comboBox1.ValueMember = "teamId";
            comboBox1.DisplayMember = "teamName";
            comboBox1.Text = "-- Choose team name";
            comboBox1.Items.Add(home);
            comboBox1.Items.Add(away);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                Team team = (Team)comboBox1.SelectedItem;
                comboBox2.DataSource = playerService.getByTeamId(team.teamId);
                comboBox2.ValueMember = "playerId";
                comboBox2.DisplayMember = "playerName";
                comboBox2.SelectedIndex = -1;
                comboBox2.Text = "-- Choose player";
            }
               
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex < 0)
            {
                MessageBox.Show("Vui long chon cau thu");
            }
            else
            {
                Goal goal = new Goal() { 
                    playerId = Int32.Parse(comboBox2.SelectedValue.ToString()),
                    matchId = this.matchId,
                    timeGoal = DateTime.Now
                    
                };
                Team team = (Team)comboBox1.SelectedItem;
                goalService.saveGoal(goal);
                Boolean check ;
                if(knockoutMatchId == 0)
                {
                    check = groupMatch.homeTeamId == team.teamId;
                }
                else
                {
                    check = match.homeTeamId == team.teamId;
                }
                if (check)
                {
                    matchResultsService.updateMatchResult(this.matchId, true, 1);
                }
                else
                {
                    matchResultsService.updateMatchResult(this.matchId, false, 1);
                }
                if(knockoutMatchId == 0)
                {
                    groupMatchService.updateByMatchId(this.matchId);
                    groupTeam.updateByMatchId(this.matchId);
                }
                else
                {
                    knockoutMatchService.updateMatch(knockoutMatchId);
                }
               
                
                this.Close();

            }
        }
    }
}

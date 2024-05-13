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
    public partial class Frm_TuKet : Frm_Base
    {
        private int roundId;
        private Round round;

        public Frm_TuKet(int roundId)
        {
            this.roundId = roundId;
            InitializeComponent();
        }
        public Frm_TuKet()
        {
            InitializeComponent();
        }
        KnockoutBranchService knockoutBranchesService;
        List<KnockoutBranches> branches;
        private KnockoutMatchService knockoutMatchService;
        private MatchesService matchesService;
        private RoundService roundService;
        private MatchResultsService matchResults;
        private void Frm_TuKet_Load(object sender, EventArgs e)
        {
            knockoutBranchesService = new KnockoutBranchService();
            knockoutMatchService = new KnockoutMatchService();
            matchesService = new MatchesService();
            matchResults = new MatchResultsService();
            initLayout();
            loadBranches();
        }
        private void initLayout()
        {
            layout = new FlowLayoutPanel();
            layout.Location = new Point(20, 100);
            layout.Size = new Size(2000, 1000);
        }
        private FlowLayoutPanel layout;
        private void removeLayout()
        {

            this.Controls.Remove(layout);
            initLayout();
        }
        private void loadBranches()
        {
           
            int location = 100;
            branches = knockoutBranchesService.findByRoundId(this.roundId);
            foreach(KnockoutBranches branch in branches)
            {
                location += location;
                Label labelBranch = new Label();
                labelBranch.Text = "Nhánh " + branch.branchName;
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.Location = new Point(20, location);
                flowLayoutPanel.Controls.Add(labelBranch);
                flowLayoutPanel.Size = new Size(1800, 120);
                List<KnockoutMatch> knockoutMatches = knockoutMatchService.findByBranchId(branch.branchId);
                foreach(KnockoutMatch knockoutMatch in knockoutMatches)
                {
                    DataGridView dgv = new DataGridView();
                    dgv.DataSource = matchesService.findByKnockoutMatchId(knockoutMatch.knockoutMatchId);
                    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgv.Width = 700;
                    dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                    flowLayoutPanel.Controls.Add(dgv);
                   
                }
                this.layout.Controls.Add(flowLayoutPanel);
            }
            this.Controls.Add(layout);
        }
        private DataGridView dgvFocus;
        private int rowIndex;
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFocus = (DataGridView)sender;
            rowIndex = e.RowIndex;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string status = dgvFocus.Rows[rowIndex].Cells["status"].Value.ToString();
           
            if (status.Equals("Đang diễn ra"))
            {
                string matchId = dgvFocus.Rows[rowIndex].Cells[0].Value.ToString();
                int knockoutMatchId = Int32.Parse(dgvFocus.Rows[rowIndex].Cells[1].Value.ToString());

                Frm_Goal frm_Goal = new Frm_Goal(matchId, knockoutMatchId);
                frm_Goal.ShowDialog();
                removeLayout();
                loadBranches();
            }
            else if (status.Equals("Kết thúc"))
            {
                MessageBox.Show("Trận đấu đã kết thúc");
            }
            else
            {
                MessageBox.Show("Trận đấu chưa diễn ra");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                string status = dgvFocus.Rows[rowIndex].Cells["status"].Value.ToString();
                string homeTeamScore = dgvFocus.Rows[rowIndex].Cells["HomeTeamScore"].Value.ToString();
                string awayTeamScore = dgvFocus.Rows[rowIndex].Cells["AwayTeamScore"].Value.ToString();
                if (status.Equals("Đang diễn ra"))
                {
                    string matchId = dgvFocus.Rows[rowIndex].Cells["MatchId"].Value.ToString();
                    string matId = dgvFocus.Rows[rowIndex].Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(homeTeamScore) && string.IsNullOrEmpty(awayTeamScore))
                    {
                        MatchResults matchResult = new MatchResults()
                        {
                            matchId = matId,
                            homeTeamScore = 0,
                            awayTeamScore = 0
                        };
                        matchResults.saveMatchResult(matchResult);
                        knockoutMatchService.updateMatch(Int32.Parse(matchId));

                    }
                   matchesService.finishMatch(matId);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (rowIndex >= 0)
            {
                string status = dgvFocus.Rows[rowIndex].Cells["status"].Value.ToString();
              
                if (status.Equals("Đang diễn ra"))
                {
                    string matchId = dgvFocus.Rows[rowIndex].Cells["MatchId"].Value.ToString();
                    string matId = dgvFocus.Rows[rowIndex].Cells[0].Value.ToString();
                    MatchResults matchResult = new MatchResults()
                    {
                        matchId = matId,
                        homeTeamScore = 0,
                        awayTeamScore = 0
                    };
                    matchResults.saveMatchResult(matchResult);
                    knockoutMatchService.updateMatch(Int32.Parse(matchId));
                    Frm_Penalty frm_Penalty = new Frm_Penalty(matId);
                    frm_Penalty.ShowDialog();
                    matchesService.finishMatch(matId);
                }

            }
        }
    }
}

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
    public partial class Frm_VongLoai : Frm_Base
    {
        private int roundId;
        private List<Group> groups;
        
        public Frm_VongLoai()
        {
            InitializeComponent();
        }

        public Frm_VongLoai(int roundId)
        {
            this.roundId = roundId;
            InitializeComponent();
        }
        
        GroupTeamService groupTeam;
        MatchResultsService matchResults;
        GoalService goalService;
        GroupService groupService;
        string err = string.Empty;
        DataGridView dgvFocus = null;
        GroupMatchService groupMatchService;

        int rowIndex = 0;
        private void Frm_VongLoai_Load(object sender, EventArgs e)
        {

            groupService = new GroupService();
            groupTeam = new GroupTeamService();
            matchResults = new MatchResultsService();
            goalService = new GoalService();
            flowLayoutPanel = new FlowLayoutPanel();
            groupMatchService = new GroupMatchService();
            flowLayoutPanel.Location = new Point(10, 100);
            flowLayoutPanel.Size = new Size(1000, 800);
            groups = groupService.findByRoundId(roundId);
            ShowGroupTeam();
        }
        FlowLayoutPanel flowLayoutPanel;
        private void removeLayout()
        {
            int total = flowLayoutPanel.Controls.Count;
            for(int i = total - 1; i >= 0; i--)
            {
                this.flowLayoutPanel.Controls.RemoveAt(i);
            }
        }
        private void ShowGroupTeam()
        {
            
            int location = 100;
            
           
          
            foreach(Group group in groups)
            {
                    location *= 2;
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.Location = new Point(10, location);
                    dataGridView.DataSource = groupTeam.getByGroupId(group.groupId);
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView.Width = 400;
                    flowLayoutPanel.Controls.Add(dataGridView);
                

               
            }
            this.Controls.Add(flowLayoutPanel);
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            removeLayout();
            loadMatch();
        }
        private void loadMatch()
        {
           
            int location = 100;
            foreach (Group group in groups)
            {
                location *= 2;
                DataGridView dataGridView = new DataGridView();
                dataGridView.Location = new Point(50, location);
                dataGridView.DataSource = matchResults.getByGroupId(group.groupId);
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView.Width = 600;
                dataGridView.CellDoubleClick += new DataGridViewCellEventHandler(dgv_CellDoubleClick);
                dataGridView.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);
                flowLayoutPanel.Controls.Add(dataGridView);

            }
            this.Controls.Add(flowLayoutPanel);

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFocus = (DataGridView)sender;
            rowIndex = e.RowIndex;
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if(this.Controls.Count == 6)
            {
                this.Controls.RemoveAt(5);
            }
            if (
                e.RowIndex >= 0)
            {
                string matchId = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();


                DataGridView dataGridView = new DataGridView();
                dataGridView.Location = new Point(1000, 200);
                dataGridView.DataSource = goalService.getByMatchId(matchId);
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView.Width = 400;
                this.Controls.Add(dataGridView);

            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            removeLayout();
            ShowGroupTeam();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (rowIndex >= 0)
            {
                string status = dgvFocus.Rows[rowIndex].Cells["status"].Value.ToString();
                string homeTeamScore = dgvFocus.Rows[rowIndex].Cells["HomeTeamScore"].Value.ToString();
                string awayTeamScore = dgvFocus.Rows[rowIndex].Cells["AwayTeamScore"].Value.ToString();
                if (status.Equals("Đang diễn ra"))
                {
                    string matchId = dgvFocus.Rows[rowIndex].Cells[0].Value.ToString();
                    if (string.IsNullOrEmpty(homeTeamScore) && string.IsNullOrEmpty(awayTeamScore))
                    {
                        MatchResults matchResult = new MatchResults() {
                            matchId = matchId,
                            homeTeamScore = 0,
                            awayTeamScore = 0
                        };
                        matchResults.saveMatchResult(matchResult);
                        groupMatchService.updateByMatchId(matchId);
                        groupTeam.updateByMatchId(matchId);
                       
                    }
                    groupMatchService.finishMatch(matchId);
                    removeLayout();
                    loadMatch();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string status = dgvFocus.Rows[rowIndex].Cells["status"].Value.ToString();
            if(status.Equals("Đang diễn ra"))
            {
                string matchId = dgvFocus.Rows[rowIndex].Cells[0].Value.ToString();
                Frm_Goal frm_Goal = new Frm_Goal(matchId);
                frm_Goal.ShowDialog();
                removeLayout();
                loadMatch();
            }
            else if(status.Equals("Kết thúc"))
            {
                MessageBox.Show("Trận đấu đã kết thúc");
            }
            else
            {
                MessageBox.Show("Trận đấu chưa diễn ra");
            }
          
        }
    }
}

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
    public partial class Frm_SaveRound : Form
    {
        public Frm_SaveRound()
        {
            InitializeComponent();
        }
        public Frm_SaveRound(string nameRound,int tournamentId)
        {
            this.nameRound = nameRound;
            this.tournamentId = tournamentId;
            InitializeComponent();
        }
        public Frm_SaveRound(string nameRound, int tournamentId,int roundId)
        {
            this.nameRound = nameRound;
            this.tournamentId = tournamentId;
            this.roundId = roundId;
            InitializeComponent();
        }
        private int roundId;
        private string nameRound;
        private int tournamentId;
        private RoundService roundService;
        private GroupService groupService;
        private GroupMatchService groupMatchService;
        private TeamService teamService;
        private List<Team> teams;
        private GroupTeamService groupTeamService;
        private KnockoutBranchService knockoutBranchService;
        private KnockoutMatchService knockoutMatchService;
        private MatchesService matchesService;
       
        private void label4_Click(object sender, EventArgs e)
        {

        }
        int[] hoursArray = {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
            12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24
        };
        private void Frm_SaveVongLoai_Load(object sender, EventArgs e)
        {
            roundService = new RoundService();
            teamService = new TeamService();
            groupMatchService = new GroupMatchService();
            groupTeamService = new GroupTeamService();
            groupService = new GroupService();
            knockoutBranchService = new KnockoutBranchService();
            knockoutMatchService = new KnockoutMatchService();
            matchesService = new MatchesService();
            foreach(int i in hoursArray)
            {
                comboBox1.Items.Add(i);
                comboBox1.ValueMember = i+"";
                comboBox1.DisplayMember = i + ":00";
            }
        }
        DateTime startDate;
        private DateTime end;
        private TimeSpan difference;
        private DateTime dayPlay;
        private int days;
        private int time;
        string[] groupNames = { "A", "B", "C", "D" };
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn giờ đá");
                return;
            }
            startDate = dateTimePicker1.Value;
            end = dateTimePicker2.Value;
            difference = end.Date - startDate.Date;
            dayPlay = dateTimePicker3.Value;
            days = (int)difference.TotalDays;
            time = Int32.Parse("18");
            TimeSpan ts = new TimeSpan(time,00,00);
           
            dayPlay = dayPlay.Date +  ts;

            if (this.nameRound.Equals("Qualifying"))
            {
                TaoVongLoai();
            }
            else if (this.nameRound.Equals("Quarter-final"))
            {
                TaoVongTuKet();
            }
            else if (this.nameRound.Equals("Semi-final"))
            {
                TaoVongBanKet();
            }
            else
            {
                TaoVongChungKet();
            }

            this.Close();
            
        }
        private void TaoVongChungKet()
        {
            List<KnockoutBranches> knockoutBranches = knockoutBranchService.findByRoundId(this.roundId);
            int roundId = createRound();
            KnockoutBranches knockoutBranch = new KnockoutBranches()
            {
                branchId = 0,
                branchName = "Chung kết",
                roundId = roundId,
                startDate = startDate,
                endDate = end

            };
            int knockoutBranchId = knockoutBranchService.saveKnockoutBrances(knockoutBranch);
            int knockoutMatchId = createKnockoutMatches(knockoutBranchId);
            DateTime matchDate = dayPlay;
            foreach (KnockoutBranches branches in knockoutBranches)
            {
                
                List<KnockoutMatch> knockoutMatches = knockoutMatchService.findByBranchId(branches.branchId);
                Matches matchHome = new Matches()
                {
                    homeTeamId = knockoutMatches[0].teamWin,
                    awayTeamId = knockoutMatches[1].teamWin,
                    matchDate = matchDate,
                    knockoutMatchId = knockoutMatchId
                }; 
                matchesService.saveMatches(matchHome);
                
            }
        }
        private void TaoVongBanKet()
        {
            List<KnockoutBranches> knockoutBranches = knockoutBranchService.findByRoundId(this.roundId);
            int roundId = createRound();
            KnockoutBranches knockoutBranch = new KnockoutBranches() {
                branchId = 0,
                branchName = "Bán kết",
                roundId= roundId,
                startDate = startDate,
                endDate = end

            };
            int knockoutBranchId = knockoutBranchService.saveKnockoutBrances(knockoutBranch);
            
            DateTime matchDate = dayPlay;
            foreach (KnockoutBranches branches in knockoutBranches)
            {
                int knockoutMatchId = createKnockoutMatches(knockoutBranchId);
                List<KnockoutMatch> knockoutMatches = knockoutMatchService.findByBranchId(branches.branchId);
                
                createMatches(knockoutMatchId, knockoutMatches[0].teamWin, knockoutMatches[1].teamWin);
                createMatches(knockoutMatchId, knockoutMatches[1].teamWin, knockoutMatches[0].teamWin);
              
            }
        }
        private int createRound()
        {
            Round round = new Round()
            {
                roundName = this.nameRound,
                roundId = 0,
                startDate = startDate,
                endDate = end,
                touramentId = this.tournamentId

            };
            int roundId = roundService.saveRound(round);
            return roundId;
        }
        private void TaoVongTuKet() {

            int roundId = createRound();
            List<Group> groups = groupService.findByRoundId(this.roundId);
            MessageBox.Show(roundId+"");
            for(int i=0;i <= (groups.Count / 2); i+=2)
            {
                int length = i + 2;
                KnockoutBranches knockoutBranches = new KnockoutBranches() {
                    branchName = groupNames[i],
                    startDate = startDate,
                    endDate = end,
                    roundId = roundId,
                    branchId = 0
                
                };
                int knockoutBranchId = knockoutBranchService.saveKnockoutBrances(knockoutBranches);
                for (int j = i; j <= length - 1; j+=2)
                {
                    int knockoutMatchId = createKnockoutMatches(knockoutBranchId);
                    int knockoutMatchId2 = createKnockoutMatches(knockoutBranchId);
                    List<GroupTeam> groupTeams = groupTeamService.findByGroupId(groups[j].groupId);
                    List<GroupTeam> groupTeams2 = groupTeamService.findByGroupId(groups[j + 1].groupId);
                    createMatches(knockoutMatchId, groupTeams[0].teamId, groupTeams2[1].teamId);
                    createMatches(knockoutMatchId2, groupTeams2[0].teamId, groupTeams[1].teamId);
                }
            }
            
            
        
        }
        private int createKnockoutMatches(int knockoutBrachId)
        {
            KnockoutMatch knockoutMatch = new KnockoutMatch()
            {
                branchId = knockoutBrachId,
                knockoutMatchId  = 0,
                teamWin  =0 
            };
            return knockoutMatchService.saveKnockoutMatch(knockoutMatch);
        }
        private void createMatches(int knockoutMatchId,int team1,int team2) 
        {
            DateTime matchDate = dayPlay;
            Matches matches = new Matches()
            {
                homeTeamId = team1,
                awayTeamId = team2,
                matchDate = matchDate,
                knockoutMatchId = knockoutMatchId
            };
            Matches matchesAway = new Matches()
            {
                homeTeamId = team2,
                awayTeamId = team1,
                matchDate = matchDate.AddDays(7),
                knockoutMatchId = knockoutMatchId
            };
            matchesService.saveMatches(matches);
            matchesService.saveMatches(matchesAway);

        }
        private void TaoVongLoai()
        {
            if (days < 36)
            {
                MessageBox.Show("Ngay ket thuc toi thieu phai lon hon ngay bat dau 36 ngay");
            }
            teams = teamService.findTeamByTournamentId(this.tournamentId);
            int totalTeams = teams.Count;
            if(totalTeams < 16)
            {
                MessageBox.Show("Chưa đủ đội tham dự ");
                return;
            }
            int roundId = createRound();
            if (startDate >= end)
            {
                MessageBox.Show("Ngay ket thuc phai lon hon ngay bat dau");
            }
            int j = 0;
            for (int i = 0; i < groupNames.Length; i++)
            {
                Group group = new Group()
                {
                    startDate = startDate,
                    endDate = end,
                    roundId = roundId,
                    groupId = 0,
                    groupName = groupNames[i]
                };
                int groupId = groupService.saveGroup(group);
                DateTime matchDate = dayPlay;
                MessageBox.Show(matchDate.ToString());
                for (int k = j; k < teams.Count; k++)
                {
                    GroupTeam groupTeam = new GroupTeam()
                    {
                        groupId = groupId,
                        teamId = teams[k].teamId
                    };
                    groupTeamService.saveGroupTeam(groupTeam);
                    for (int n = k + 1; n < j + 4; n++)
                    {
                        GroupMatch groupMatch = new GroupMatch()
                        {
                            homeTeamId = teams[k].teamId,
                            awayTeamId = teams[n].teamId,
                            matchDate = matchDate,
                            groupId = groupId

                        };
                       
                        GroupMatch groupMatchAway = new GroupMatch()
                        {
                            homeTeamId = teams[n].teamId,
                            awayTeamId = teams[k].teamId,
                            matchDate = matchDate.AddDays(7),
                            groupId = groupId

                        };
                        groupMatchService.saveGroupMatch(groupMatch);
                        groupMatchService.saveGroupMatch(groupMatchAway);
                    }
                    if ((k + 1) % 4 == 0)
                    {
                        j = ++k;
                        break;
                    }

                }
            }
        }
    }
}

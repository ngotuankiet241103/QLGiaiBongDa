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
    public partial class Frm_AddTournament : Form
    {
        private int tournamentId = 0;
        public Frm_AddTournament()
        {
            InitializeComponent();
        }
        public Frm_AddTournament(int tournamentId)
        {
            this.tournamentId = tournamentId;
            InitializeComponent();
        }
        private TournamentService tournamentService;
        private void button1_Click(object sender, EventArgs e)
        {
            string tournamentName = textBox1.Text;
            string country = textBox2.Text;
            string description = textBox3.Text;
            if(string.IsNullOrEmpty(tournamentName) || string.IsNullOrEmpty(country) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Vui long khong de trong");
                return;
            }
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;
            if(endDate <= startDate)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn ngày bắt đầu");
                return;
            }
            Tournament tournament = new Tournament() { 
            
                tournamentId = this.tournamentId,
                startDate = startDate,
                endDate = endDate,
                country= country,
                tournamentName = tournamentName,
                description = description
            };
            tournamentService.saveTournament(tournament);
            this.Close();
        }

        private void Frm_AddTournament_Load(object sender, EventArgs e)
        {
            tournamentService = new TournamentService();
            if(tournamentId != 0)
            {
                loadTournament();
            }
        }
        private void loadTournament()
        {
            Tournament tournament = tournamentService.findById(this.tournamentId);
            this.textBox1.Text = tournament.tournamentName;
            this.dateTimePicker1.Value = tournament.startDate;
            this.dateTimePicker2.Value = tournament.endDate;
            this.textBox2.Text = tournament.country;
            this.textBox3.Text = tournament.description;
        }
    }
}

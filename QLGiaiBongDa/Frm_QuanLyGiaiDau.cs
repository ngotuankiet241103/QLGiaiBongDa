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
    public partial class Frm_QuanLyGiaiDau : Frm_Base
    {
        public Frm_QuanLyGiaiDau()
        {
            InitializeComponent();
        }
        TournamentService tournament;
        string err = string.Empty;
        DataTable table = null;

        private void Frm_QuanLyGiaiDau_Load(object sender, EventArgs e)
        {
            tournament = new TournamentService();
            showTournaments();
        }

        private void showTournaments()
        {
            table = tournament.getAllTournament(ref err);
            dataGridView1.DataSource = table.DefaultView;
        }

        private void show_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DateTime startDate = DateTime.Parse(selectedRow.Cells["startDate"].Value.ToString());
                DateTime now = DateTime.Now;
                if(now < startDate)
                {
                    MessageBox.Show("giải đấu chưa bắt đầu");
                    return;
                }
                // Get the value of the specified column in the selected row
                int value = Int32.Parse(selectedRow.Cells["tournamentCode"].Value.ToString());

                // If the value is not null, you can use it
                if (value > 0)
                {
                    Frm_ChiTietGiaiDau frm_ChiTietGiaiDau = new Frm_ChiTietGiaiDau(value);
                    frm_ChiTietGiaiDau.Show();
                }
                else
                {
                    // The cell is empty or the column does not exist
                }
            }
            else
            {
                // No row is currently selected
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            Frm_AddTournament frm_AddTournament = new Frm_AddTournament();
            frm_AddTournament.ShowDialog();
            showTournaments();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                DateTime startDate = DateTime.Parse(selectedRow.Cells["startDate"].Value.ToString());
                DateTime now = DateTime.Now;
                if (now < startDate)
                {
                    MessageBox.Show("giải đấu chưa bắt đầu");
                    return;
                }
                // Get the value of the specified column in the selected row
                int value = Int32.Parse(selectedRow.Cells["tournamentCode"].Value.ToString());

                // If the value is not null, you can use it
                if (value > 0)
                {
                    Frm_AddTournament frm_ChiTietGiaiDau = new Frm_AddTournament(value);
                    frm_ChiTietGiaiDau.ShowDialog();
                    showTournaments();
                }
                else
                {
                    // The cell is empty or the column does not exist
                }
            }
            else
            {
                // No row is currently selected
            }
        }
    }
}

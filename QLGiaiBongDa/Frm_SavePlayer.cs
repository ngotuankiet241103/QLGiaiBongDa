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
    public partial class Frm_SavePlayer : Form
    {
        public Frm_SavePlayer()
        {
            InitializeComponent();
        }
        private int playerId = 0;
        private PlayerService playerService;
        private TeamService teamService;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Frm_SavePlayer_Load(object sender, EventArgs e)
        {
            playerService = new PlayerService();
            teamService = new TeamService();
            if (playerId == 0)
            {
                button1.Text = "Thêm";
            }
            else
            {
                button1.Text = "Cập nhật";
            }
            loadCbo();
        }
        private void loadCbo()
        {
            comboBox1.DataSource = teamService.findAll();
            comboBox1.ValueMember = "team_id";
            comboBox1.DisplayMember = "team_name";
            if(playerId == 0)
            {
                comboBox1.SelectedIndex = 0;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string playerName = textBox1.Text;
            if(string.IsNullOrEmpty(playerName) || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ");
                return;
            }
            Player player = new Player() {
                playerId = this.playerId,
                playerName = playerName,
                teamId = Int32.Parse(comboBox1.SelectedValue.ToString())
            
            };
            playerService.savePlayer(player);
            this.Close();
            
        }
    }
}

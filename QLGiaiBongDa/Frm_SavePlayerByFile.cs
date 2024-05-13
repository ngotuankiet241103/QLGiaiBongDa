using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using QLGiaiBongDa.BusinessLayer;
using QLGiaiBongDa.DTO;

namespace QLGiaiBongDa
{
    public partial class Frm_SavePlayerByFile : Form
    {
        SqlConnection con = new SqlConnection("server =MSI\\SQLEXPRESS; database=QuanLyGiaiBongDa; Integrated Security = True");

        private int playerId = 0;
        private PlayerService playerService;
        private TeamService teamService;
        public Frm_SavePlayerByFile()
        {
            InitializeComponent();
        }

        private void loadCbo()
        {
            comboBox1.DataSource = teamService.findAll();
            comboBox1.ValueMember = "team_id";
            comboBox1.DisplayMember = "team_name";
            if (playerId == 0)
            {
                comboBox1.SelectedIndex = 0;
            }

        }

        private void Frm_SavePlayerByFile_Load(object sender, EventArgs e)
        {
            playerService = new PlayerService();
            teamService = new TeamService();
            fillGrid();
            loadCbo();
        }

        private void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog(); fdlg.Title = "Select File";
            fdlg.FileName = txtFileName.Text;
            fdlg.Filter = "Excel Sheet (*.xls) [*.xls All Files(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = fdlg.FileName;
            }
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text) || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ");
                return;
            }

            OleDbConnection theConnection = new OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0; data source='"+txtFileName.Text+"';Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1\"");

            theConnection.Open();
            OleDbDataAdapter theDataAdapter = new OleDbDataAdapter("Select * from [Sheet1$]", theConnection);
            DataSet theSD = new DataSet();
            DataTable dt = new DataTable();
            theDataAdapter.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        void fillGrid()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Player order by playerID", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text) || comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ");
                return;
            }
            con.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand("Insert into Player(playerName, teamID) values('" + dataGridView1.Rows[i].Cells[0].Value + "', '" + Int32.Parse(comboBox1.SelectedValue.ToString()) + "')", con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Players saved...");
            fillGrid();
        }
    }
}


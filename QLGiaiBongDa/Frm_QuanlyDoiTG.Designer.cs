
namespace QLGiaiBongDa
{
    partial class Frm_QuanlyDoiTG
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboTournaments = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teamId,
            this.teamName,
            this.country,
            this.totalPlayer});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(799, 336);
            this.dataGridView1.TabIndex = 0;
            // 
            // teamId
            // 
            this.teamId.DataPropertyName = "team_id";
            this.teamId.HeaderText = "Team Code";
            this.teamId.MinimumWidth = 6;
            this.teamId.Name = "teamId";
            this.teamId.ReadOnly = true;
            this.teamId.Width = 125;
            // 
            // teamName
            // 
            this.teamName.DataPropertyName = "team_name";
            this.teamName.HeaderText = "Team Name";
            this.teamName.MinimumWidth = 6;
            this.teamName.Name = "teamName";
            this.teamName.ReadOnly = true;
            this.teamName.Width = 125;
            // 
            // country
            // 
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "Country";
            this.country.MinimumWidth = 6;
            this.country.Name = "country";
            this.country.ReadOnly = true;
            this.country.Width = 125;
            // 
            // totalPlayer
            // 
            this.totalPlayer.DataPropertyName = "TotalPlayer";
            this.totalPlayer.HeaderText = "Total player";
            this.totalPlayer.MinimumWidth = 6;
            this.totalPlayer.Name = "totalPlayer";
            this.totalPlayer.ReadOnly = true;
            this.totalPlayer.Width = 125;
            // 
            // cboTournaments
            // 
            this.cboTournaments.FormattingEnabled = true;
            this.cboTournaments.Location = new System.Drawing.Point(378, 45);
            this.cboTournaments.Name = "cboTournaments";
            this.cboTournaments.Size = new System.Drawing.Size(253, 24);
            this.cboTournaments.TabIndex = 1;
            this.cboTournaments.SelectedIndexChanged += new System.EventHandler(this.cboTournaments_SelectedIndexChanged);
            this.cboTournaments.TextChanged += new System.EventHandler(this.cboTournaments_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thêm đội";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Frm_QuanlyDoiTG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboTournaments);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_QuanlyDoiTG";
            this.Text = "Frm_QuanlyDoiTG";
            this.Load += new System.EventHandler(this.Frm_QuanlyDoiTG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboTournaments;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPlayer;
    }
}
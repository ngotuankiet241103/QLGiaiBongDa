
namespace QLGiaiBongDa
{
    partial class Frm_SaveTournamentTeam
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
            this.button1 = new System.Windows.Forms.Button();
            this.isChoose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.teamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isChoose,
            this.teamId,
            this.teamName,
            this.country});
            this.dataGridView1.Location = new System.Drawing.Point(1, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(799, 408);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // isChoose
            // 
            this.isChoose.DataPropertyName = "isChoose";
            this.isChoose.FalseValue = "false";
            this.isChoose.HeaderText = "isChoose";
            this.isChoose.MinimumWidth = 6;
            this.isChoose.Name = "isChoose";
            this.isChoose.TrueValue = "true";
            this.isChoose.Width = 125;
            // 
            // teamId
            // 
            this.teamId.DataPropertyName = "team_id";
            this.teamId.HeaderText = "Team code";
            this.teamId.MinimumWidth = 6;
            this.teamId.Name = "teamId";
            this.teamId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.teamId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.teamId.Width = 125;
            // 
            // teamName
            // 
            this.teamName.DataPropertyName = "team_name";
            this.teamName.HeaderText = "Team name";
            this.teamName.MinimumWidth = 6;
            this.teamName.Name = "teamName";
            this.teamName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.teamName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.teamName.Width = 125;
            // 
            // country
            // 
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "Country";
            this.country.MinimumWidth = 6;
            this.country.Name = "country";
            this.country.Width = 125;
            // 
            // Frm_SaveTournamentTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Frm_SaveTournamentTeam";
            this.Text = "Frm_SaveTournamentTeam";
            this.Load += new System.EventHandler(this.Frm_SaveTournamentTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isChoose;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn teamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
    }
}
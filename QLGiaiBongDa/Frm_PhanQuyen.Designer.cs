namespace QLGiaiBongDa
{
    partial class Frm_PhanQuyen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.cboGroupUser = new System.Windows.Forms.ComboBox();
            this.dgvFunctionListByUser = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroupID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFuncName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colXem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colThem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSua = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colXoa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctionListByUser)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.cboGroupUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn GroupUser";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(567, 21);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(227, 24);
            this.btnCapNhat.TabIndex = 1;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // cboGroupUser
            // 
            this.cboGroupUser.FormattingEnabled = true;
            this.cboGroupUser.Location = new System.Drawing.Point(6, 21);
            this.cboGroupUser.Name = "cboGroupUser";
            this.cboGroupUser.Size = new System.Drawing.Size(555, 24);
            this.cboGroupUser.TabIndex = 0;
            this.cboGroupUser.SelectedIndexChanged += new System.EventHandler(this.cboGroupUser_SelectedIndexChanged);
            // 
            // dgvFunctionListByUser
            // 
            this.dgvFunctionListByUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunctionListByUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colGroupID,
            this.colFuncID,
            this.colFuncName,
            this.colAlias,
            this.colXem,
            this.colThem,
            this.colSua,
            this.colXoa,
            this.colTong});
            this.dgvFunctionListByUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFunctionListByUser.Location = new System.Drawing.Point(0, 55);
            this.dgvFunctionListByUser.Name = "dgvFunctionListByUser";
            this.dgvFunctionListByUser.Size = new System.Drawing.Size(1026, 298);
            this.dgvFunctionListByUser.TabIndex = 2;
            this.dgvFunctionListByUser.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunctionListByUser_CellContentClick);
            this.dgvFunctionListByUser.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFunctionListByUser_CellEndEdit);
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            // 
            // colGroupID
            // 
            this.colGroupID.DataPropertyName = "GroupID";
            this.colGroupID.HeaderText = "GroupID";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.Visible = false;
            // 
            // colFuncID
            // 
            this.colFuncID.DataPropertyName = "FuncID";
            this.colFuncID.HeaderText = "FuncID";
            this.colFuncID.Name = "colFuncID";
            this.colFuncID.Visible = false;
            // 
            // colFuncName
            // 
            this.colFuncName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFuncName.DataPropertyName = "FuncName";
            this.colFuncName.HeaderText = "Tên chức năng";
            this.colFuncName.Name = "colFuncName";
            // 
            // colAlias
            // 
            this.colAlias.DataPropertyName = "Alias";
            this.colAlias.HeaderText = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.Visible = false;
            // 
            // colXem
            // 
            this.colXem.DataPropertyName = "Xem";
            this.colXem.FalseValue = "0";
            this.colXem.HeaderText = "Xem";
            this.colXem.Name = "colXem";
            this.colXem.TrueValue = "1";
            // 
            // colThem
            // 
            this.colThem.DataPropertyName = "Them";
            this.colThem.FalseValue = "0";
            this.colThem.HeaderText = "Thêm";
            this.colThem.Name = "colThem";
            this.colThem.TrueValue = "1";
            // 
            // colSua
            // 
            this.colSua.DataPropertyName = "Sua";
            this.colSua.FalseValue = "0";
            this.colSua.HeaderText = "Sửa";
            this.colSua.Name = "colSua";
            this.colSua.TrueValue = "1";
            // 
            // colXoa
            // 
            this.colXoa.DataPropertyName = "Xoa";
            this.colXoa.FalseValue = "0";
            this.colXoa.HeaderText = "Xóa";
            this.colXoa.Name = "colXoa";
            this.colXoa.TrueValue = "1";
            // 
            // colTong
            // 
            this.colTong.DataPropertyName = "Tong";
            this.colTong.HeaderText = "Tổng";
            this.colTong.Name = "colTong";
            // 
            // Frm_PhanQuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 353);
            this.Controls.Add(this.dgvFunctionListByUser);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_PhanQuyen";
            this.Text = "Frm_PhanQuyen";
            this.Load += new System.EventHandler(this.Frm_PhanQuyen_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunctionListByUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.ComboBox cboGroupUser;
        private System.Windows.Forms.DataGridView dgvFunctionListByUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGroupID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFuncName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colXem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colThem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSua;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTong;
    }
}
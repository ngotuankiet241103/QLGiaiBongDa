
namespace QLGiaiBongDa
{
    partial class Frm_ChiTietGiaiDau
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vòngLoạiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vòngTứKếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vòngBánKếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vóngChungKếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vòngLoạiToolStripMenuItem,
            this.vòngTứKếtToolStripMenuItem,
            this.vòngBánKếtToolStripMenuItem,
            this.vóngChungKếtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vòngLoạiToolStripMenuItem
            // 
            this.vòngLoạiToolStripMenuItem.Name = "vòngLoạiToolStripMenuItem";
            this.vòngLoạiToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.vòngLoạiToolStripMenuItem.Text = "Vòng loại";
            this.vòngLoạiToolStripMenuItem.Click += new System.EventHandler(this.vòngLoạiToolStripMenuItem_Click);
            // 
            // vòngTứKếtToolStripMenuItem
            // 
            this.vòngTứKếtToolStripMenuItem.Name = "vòngTứKếtToolStripMenuItem";
            this.vòngTứKếtToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.vòngTứKếtToolStripMenuItem.Text = "Vòng tứ kết ";
            this.vòngTứKếtToolStripMenuItem.Click += new System.EventHandler(this.vòngTứKếtToolStripMenuItem_Click);
            // 
            // vòngBánKếtToolStripMenuItem
            // 
            this.vòngBánKếtToolStripMenuItem.Name = "vòngBánKếtToolStripMenuItem";
            this.vòngBánKếtToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.vòngBánKếtToolStripMenuItem.Text = "Vòng bán kết";
            this.vòngBánKếtToolStripMenuItem.Click += new System.EventHandler(this.vòngBánKếtToolStripMenuItem_Click);
            // 
            // vóngChungKếtToolStripMenuItem
            // 
            this.vóngChungKếtToolStripMenuItem.Name = "vóngChungKếtToolStripMenuItem";
            this.vóngChungKếtToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.vóngChungKếtToolStripMenuItem.Text = "Vóng chung kết";
            this.vóngChungKếtToolStripMenuItem.Click += new System.EventHandler(this.vóngChungKếtToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = -1;
            this.tabControl1.Size = new System.Drawing.Size(800, 422);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Text = "tabControl1";
            // 
            // Frm_ChiTietGiaiDau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Frm_ChiTietGiaiDau";
            this.Text = "Frm_ChiTietGiaiDau";
            this.Load += new System.EventHandler(this.Frm_ChiTietGiaiDau_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vòngLoạiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vòngTứKếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vòngBánKếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vóngChungKếtToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevComponents.DotNetBar.TabControl tabControl1;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
namespace QLGiaiBongDa
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }
        bool bKTraMotab = false;
        string sTieuDe;
        public Frm_Main frm_Main;

        public delegate void _deDongTab();
        public _deDongTab deDongTab;
        private bool CheckOpenTab(string name)
        {
            for (int i = 0; i < tabControl1.Tabs.Count; i++)
            {
                if (tabControl1.Tabs[i].Text == name)
                {
                    tabControl1.SelectedTabIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void vDongTab()
        {
            foreach (TabItem item in tabControl1.Tabs)
            {
                if (item.IsSelected)
                {
                    tabControl1.Tabs.Remove(item);
                    return;
                }
            }
        }

        private void OpenForm(bool statusOpen, string sTieuDe, Frm_Base frm)
        {
            bKTraMotab = statusOpen;
            this.sTieuDe = sTieuDe;
            if (!CheckOpenTab(sTieuDe))
            {
                TabItem t = tabControl1.CreateTab(sTieuDe);
                t.Name = frm.Name;

                frm.deDongTab = new Frm_Base._deDongTab(vDongTab);
                this.frm_Main = this;

                frm.TopLevel = false;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                t.AttachedControl.Controls.Add(frm);
                frm.Show();

                tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
            }
        }
        private void OpenForm(bool statusOpen, string sTieuDe, Frm_Base frm, QUYEN quyen)
        {
            if (Cls_Main.CheckQuyen(frm, quyen))
            {
                bKTraMotab = statusOpen;
                this.sTieuDe = sTieuDe;
                if (!CheckOpenTab(sTieuDe))
                {
                    TabItem t = tabControl1.CreateTab(sTieuDe);
                    t.Name = frm.Name;

                    frm.deDongTab = new Frm_Base._deDongTab(vDongTab);
                    this.frm_Main = this;

                    frm.TopLevel = false;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    t.AttachedControl.Controls.Add(frm);
                    frm.Show();

                    tabControl1.SelectedTabIndex = tabControl1.Tabs.Count - 1;
                }
            }
            else
            {
                MessageBox.Show("khong co quyen");
            }
        }

        private void giảiĐấuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Quản lý giải đấu", new Frm_QuanLyGiaiDau());
        }

        private void độiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Quản lý đội tham gia", new Frm_QuanlyDoiTG());
        }

        private void độiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Quản lý đội", new Frm_QuanLyDoi());
        }

        private void cầuThủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Quản lý cầu thủ", new Frm_QuanLyCauThu());
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            login();
        }
        private void login()
        {
            Frm_Login frm_Login = new Frm_Login();
            frm_Login.ShowDialog();
            //Hien thi thong tin dang nhập
            if (Cls_Main.tenNguoiDung.Equals(""))
            {
                Application.Exit();
            }
            label1.Text = string.Format("Hệ thống đăng nhập bởi: {0}", Cls_Main.tenNguoiDung);
        }
        private void phânQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_PhanQuyen frm = new Frm_PhanQuyen();
            if (!Cls_Main.CheckQuyen(frm, QUYEN.XEM))
            {
                MessageBox.Show("Access denied");
                return;
            }
            OpenForm(true, "Phân quyền người dùng", frm);
        }

        private void ngườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_QuanLyNguoiDung frm = new Frm_QuanLyNguoiDung();
            //if (!Cls_Main.CheckQuyen(this, QUYEN.XEM))
            //{
            //    MessageBox.Show("Access denied");
            //    return;
            //}
            OpenForm(true, "Quản lý người dùng",frm );
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(true, "Quản lý người dùng", new Frm_ChangePassword());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cls_Main.logout();
            label1.Text = string.Empty;
            login();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

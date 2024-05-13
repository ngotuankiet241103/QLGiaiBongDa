using DevComponents.DotNetBar;
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
    
    public partial class Frm_ChiTietGiaiDau : Form
    {
        private int tournamentId;
        private List<Round> rounds;
        private RoundService service;

        bool bKTraMotab = false;
        string sTieuDe;
        public Frm_ChiTietGiaiDau frm_Main;

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
        public Frm_ChiTietGiaiDau()
        {
            InitializeComponent();
        }
        public Frm_ChiTietGiaiDau(int id)
        {
            this.tournamentId = id;
            InitializeComponent();
        }

        private void Frm_ChiTietGiaiDau_Load(object sender, EventArgs e)
        {
            service = new RoundService();
            rounds = service.findAllByTournamentId(tournamentId);
        }

        private void vòngLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Round round = rounds.Find(item => item.roundName.Equals("Qualifying"));
            if(round != null)
            {
                OpenForm(true, "Vòng loại giải đấu", new Frm_VongLoai(round.roundId));
            }
            else
            {
                Frm_SaveRound frm_SaveRound = new Frm_SaveRound("Qualifying",this.tournamentId);
                frm_SaveRound.ShowDialog();
            }
        }

        private void vòngTứKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Round round = rounds.Find(item => item.roundName.Equals("Quarter-final"));

            if (round != null)
            {
                OpenForm(true, "Vòng tứ kết", new Frm_TuKet(round.roundId));
            }
            else
            {
                
                Round roundQualifying = rounds.Find(item => item.roundName.Equals("Qualifying"));
                DateTime time = DateTime.Now;
                if(roundQualifying.endDate > time)
                {
                    MessageBox.Show("Vòng loại chưa kêt thúc");
                    return;
                }
                Frm_SaveRound frm_SaveRound = new Frm_SaveRound("Quarter-final", this.tournamentId,roundQualifying.roundId);
                frm_SaveRound.ShowDialog();
            }
        }

        private void vòngBánKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Round round = rounds.Find(item => item.roundName.Equals("Semi-final"));
            if (round != null)
            {
                OpenForm(true, "Vòng bán kết", new Frm_TuKet(round.roundId));
            }
            else
            {
                Round roundQualifying = rounds.Find(item => item.roundName.Equals("Quarter-final"));
                DateTime time = DateTime.Now;
                if (roundQualifying.endDate > time)
                {
                    MessageBox.Show("Vòng tứ kết chưa kêt thúc");
                    return;
                }
                Frm_SaveRound frm_SaveRound = new Frm_SaveRound("Semi-final", this.tournamentId, roundQualifying.roundId);
                frm_SaveRound.ShowDialog();
            }
        }

        private void vóngChungKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Round round = rounds.Find(item => item.roundName.Equals("Final"));
            if (round != null)
            {
                OpenForm(true, "Vòng chung kết", new Frm_TuKet(round.roundId));
            }
            else
            {
                Round roundQualifying = rounds.Find(item => item.roundName.Equals("Semi-final"));
                DateTime time = DateTime.Now;
                if (roundQualifying.endDate > time)
                {
                    MessageBox.Show("Vòng bán kết chưa kêt thúc");
                    return;
                }
                Frm_SaveRound frm_SaveRound = new Frm_SaveRound("Final", this.tournamentId, roundQualifying.roundId);
                frm_SaveRound.ShowDialog();
                this.Close();
            }
            
        }
    }
}

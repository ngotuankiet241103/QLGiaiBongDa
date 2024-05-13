using QuanLyBanHang.DataLayer;
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
    public partial class Frm_PhanQuyen : Frm_Base
    {
        public Frm_PhanQuyen()
        {
            InitializeComponent();
        }

        BusinessLayer.System db;
        DataTable dtGroupUser;
        DataTable dtFunctionByUser;
        string err = string.Empty;
        bool comboboxStatus = false;

        private void Frm_PhanQuyen_Load(object sender, EventArgs e)
        {
            db = new BusinessLayer.System();
            ShowCboGroupUserData();
        }

        private void ShowCboGroupUserData()
        {
            dtGroupUser = new DataTable();
            dtGroupUser = db.GetGroupUser(ref err);

            cboGroupUser.DataSource = dtGroupUser;
            cboGroupUser.DisplayMember = "GroupName";
            cboGroupUser.ValueMember = "GroupID";

            cboGroupUser.SelectedIndex = -1;
            cboGroupUser.Text = "Chọn nhóm User ";
            comboboxStatus = true;
        }

        private void cboGroupUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGroupUser.SelectedIndex >= 0 && comboboxStatus == true)
            {
                ShowFunctionListByUser(cboGroupUser.SelectedValue.ToString());
            }
        }

        private void ShowFunctionListByUser(string groupID)
        {
            dtFunctionByUser = new DataTable();
            dtFunctionByUser = db.GetFunctionListByUser(ref err, groupID);

            dgvFunctionListByUser.DataSource = dtFunctionByUser.DefaultView;
        }

        private void dgvFunctionListByUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvFunctionListByUser_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFunctionListByUser.CurrentCell.ColumnIndex >= 5 && dgvFunctionListByUser.CurrentCell.ColumnIndex <= 8)
            {
                int diem = 0;
                for (int i = 5; i <= 8; i++)
                {
                    if (dgvFunctionListByUser.CurrentRow.Cells[i].Value.ToString().Equals("1"))
                    {
                        switch (i)
                        {
                            case 5:
                                diem += 1;
                                break;
                            case 6:
                                diem += 2;
                                break;
                            case 7:
                                diem += 4;
                                break;
                            case 8:
                                diem += 8;
                                break;
                        }
                    }
                }
                dgvFunctionListByUser.CurrentRow.Cells["colTong"].Value = string.Format("{0}", diem);
            }
        }
        string funcId, groupId;
        int toltal = 0;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Cls_Main.CheckQuyen(this, QUYEN.SUA))
            {
                for (int i = 0; i < dgvFunctionListByUser.Rows.Count - 1; i++)
                {
                    funcId = dgvFunctionListByUser.Rows[i].Cells["colFuncID"].Value.ToString();
                    groupId = dgvFunctionListByUser.Rows[i].Cells["colGroupID"].Value.ToString();
                    toltal = Convert.ToInt32(dgvFunctionListByUser.Rows[i].Cells["colTong"].Value.ToString());
                 
                    db.UpdateDecentralize(ref err, funcId, groupId, toltal);
                }
                ShowFunctionListByUser(cboGroupUser.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Access Denied");
                ShowFunctionListByUser(cboGroupUser.SelectedValue.ToString());
            }

        }

    }
}

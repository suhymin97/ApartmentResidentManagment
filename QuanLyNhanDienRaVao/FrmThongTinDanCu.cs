﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmThongTinDanCu : Form
    {
        Data dt = new Data();
        public FrmThongTinDanCu()
        {
            InitializeComponent();
            dt.loadCuDan(dgvCuDan);
            resetData();
        }
        public bool validate()
        {
            if (dtngayCap.Text.Equals(Convert.ToDateTime("1/1/1753").ToString()) || dtngaySinh.Text.Equals(Convert.ToDateTime("1/1/1753").ToString()))
                return false;
            // ho ten
            if (txtName.Text == "" || cbgt.Text == "" || dtngaySinh.Text == "" || txtcmnd.Text == ""
                || dtngayCap.Text == "" || txtnoicap.Text == "" || txtsdt.Text == "" || txtthuongchu.Text == "")
            {
                snackBarName.Show(this, "Không được để trống các trường có dấu *",
             Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 2000, "", Bunifu.UI.WinForms.BunifuSnackbar.Positions.MiddleCenter);
                return false;
            }
            return true;
        }



        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            String ma = txtmadancu.Text;
            dt.deleteCuDan(ma);
            dt.loadCuDan(dgvCuDan);

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //if (validate() == true)
            //{
            //    String phongDK = txtphongdk.Text;
            //    String name = txtName.Text;
            //    String sex = cbgt.Text;
            //    DateTime date = Convert.ToDateTime(dtngaySinh.Text);
            //    String CMND = txtcmnd.Text;
            //    DateTime ngayCap = Convert.ToDateTime(dtngayCap.Text);
            //    String noiCap = txtnoicap.Text;
            //    String sdt = txtsdt.Text;
            //    String ngonNgu = cbxngonngu.Text;
            //    String thuongTru = txtthuongchu.Text;
            //    String ngheNghiep = txtnghenghiep.Text;
            //    String noiLamViec = txtnoilamviec.Text;
            //    String dantoc = txtdantoc.Text;
            //    String noiSinh = txtnoisinh.Text;
            //    String queQuan = txtquequan.Text;
            //    String email = txtemail.Text;
            //    String quoctich = txtquoctich.Text;
            //    var result = dt.themCuDan(txtmadancu.Text,phongDK, name, sex, date, CMND, ngayCap, noiCap, sdt, ngonNgu, thuongTru, ngheNghiep, noiLamViec, dantoc, noiSinh, queQuan, email, ngonNgu);
            //    if (result == true)
            //        MessageBox.Show("Thành công", "Caption", MessageBoxButtons.OK);
            resetData();
            //dt.loadCuDan(dgvCuDan);

            //}

        }
        private void resetData()
        {
            string test = dt.getMaCuDan();
            txtmadancu.Text = (int.Parse(test) + 1).ToString();
            txtphongdk.Text = "";
            txtName.Text = "";
            cbgt.Text = "Nam";
            txtcmnd.Text = "";
            txtnoicap.Text = "";
            txtsdt.Text = "";
            txtemail.Text = "";
            txtquoctich.Text = "";
            cbxngonngu.Text = "Tiếng Việt";
            txtnghenghiep.Text = "";
            txtnoilamviec.Text = "";
            txtdantoc.Text = "";
            txtnoisinh.Text = "";
            txtquequan.Text = "";
            txtthuongchu.Text = "";


        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            bool check = dt.checkDanCu(txtmadancu.Text);
            if (validate() == true)
            {
                String phongDK = txtphongdk.Text;
                String name = txtName.Text;
                String sex = cbgt.Text;
                DateTime date = Convert.ToDateTime(dtngaySinh.Text);
                String CMND = txtcmnd.Text;
                DateTime ngayCap = Convert.ToDateTime(dtngayCap.Text);
                String noiCap = txtnoicap.Text;
                String sdt = txtsdt.Text;
                String ngonNgu = cbxngonngu.Text;
                String thuongTru = txtthuongchu.Text;
                String ngheNghiep = txtnghenghiep.Text;
                String noiLamViec = txtnoilamviec.Text;
                String dantoc = txtdantoc.Text;
                String noiSinh = txtnoisinh.Text;
                String queQuan = txtquequan.Text;
                String email = txtemail.Text;
                String quocTich = txtquoctich.Text;
                if (!check)
                {
                    if(dt.checkMaxPerson(txtphongdk.Text))
                    {
                        dt.themCuDan(txtmadancu.Text, phongDK, name, sex, date, CMND, ngayCap, noiCap, sdt, ngonNgu, thuongTru, ngheNghiep, noiLamViec, dantoc, noiSinh, queQuan, email, quocTich);
                    }   
                    else
                    {
                        return;
                    }    

                }    
                    
                else
                if (dt.checkMaxPerson(txtphongdk.Text))
                {
                    dt.updateCuDan(txtmadancu.Text, phongDK, name, sex, date, CMND, ngayCap, noiCap, sdt, ngonNgu, thuongTru, ngheNghiep, noiLamViec, dantoc, noiSinh, queQuan, email, quocTich);
                }
                else
                {
                    MessageBox.Show("Số phòng đã quá số người cho phép", "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    return;
                }
                    
                dt.loadCuDan(dgvCuDan);
                resetData();

            }
        }

        private void dgvCuDan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmadancu.Text = dgvCuDan.CurrentRow.Cells[0].Value.ToString();
            txttrangthai.Text = dgvCuDan.CurrentRow.Cells[18].Value != null ? "Đang cư trú" : "Không đăng ký cư trú";
            txtphongdk.Text = dgvCuDan.CurrentRow.Cells[18].Value == null ? "" : dgvCuDan.CurrentRow.Cells[18].Value.ToString();
            txtName.Text = dgvCuDan.CurrentRow.Cells[2].Value == null ? "" : dgvCuDan.CurrentRow.Cells[2].Value.ToString();
            cbgt.Text = dgvCuDan.CurrentRow.Cells[4].Value == null ? "" : dgvCuDan.CurrentRow.Cells[4].Value.ToString();
            cbgt.Text = dgvCuDan.CurrentRow.Cells[4].Value == null ? "" : dgvCuDan.CurrentRow.Cells[4].Value.ToString();
            if (dgvCuDan.CurrentRow.Cells[3].Value != null)
                dtngaySinh.Value = Convert.ToDateTime(dgvCuDan.CurrentRow.Cells[3].Value);
            else
                dtngaySinh.Value = Convert.ToDateTime("1/1/1753");
            txtcmnd.Text = dgvCuDan.CurrentRow.Cells[6].Value == null ? "" : dgvCuDan.CurrentRow.Cells[6].Value.ToString();
            if (dgvCuDan.CurrentRow.Cells[11].Value != null)
                dtngayCap.Value = Convert.ToDateTime(dgvCuDan.CurrentRow.Cells[11].Value);
            else
                dtngayCap.Value = Convert.ToDateTime("1/1/1753");

            txtnoicap.Text = dgvCuDan.CurrentRow.Cells[12].Value == null ? "" : dgvCuDan.CurrentRow.Cells[12].Value.ToString();
            txtsdt.Text = dgvCuDan.CurrentRow.Cells[7].Value == null ? "" : dgvCuDan.CurrentRow.Cells[7].Value.ToString();
            txtemail.Text = dgvCuDan.CurrentRow.Cells[15].Value == null ? "" : dgvCuDan.CurrentRow.Cells[15].Value.ToString();
            txtquoctich.Text = dgvCuDan.CurrentRow.Cells[9].Value == null ? "" : dgvCuDan.CurrentRow.Cells[9].Value.ToString();
            txtnghenghiep.Text = dgvCuDan.CurrentRow.Cells[14].Value == null ? "" : dgvCuDan.CurrentRow.Cells[14].Value.ToString();
            txtnoilamviec.Text = dgvCuDan.CurrentRow.Cells[19].Value == null ? "" : dgvCuDan.CurrentRow.Cells[19].Value.ToString();
            txtdantoc.Text = dgvCuDan.CurrentRow.Cells[8].Value == null ? "" : dgvCuDan.CurrentRow.Cells[8].Value.ToString();
            txtnoisinh.Text = dgvCuDan.CurrentRow.Cells[5].Value == null ? "" : dgvCuDan.CurrentRow.Cells[5].Value.ToString();
            txtquequan.Text = dgvCuDan.CurrentRow.Cells[6].Value == null ? "" : dgvCuDan.CurrentRow.Cells[6].Value.ToString();
            txtthuongchu.Text = dgvCuDan.CurrentRow.Cells[10].Value == null ? "" : dgvCuDan.CurrentRow.Cells[10].Value.ToString();
            cbxngonngu.Text = dgvCuDan.CurrentRow.Cells[13].Value == null ? "" : dgvCuDan.CurrentRow.Cells[13].Value.ToString();
        }

        private void bunifuTextBox16_TextChanged(object sender, EventArgs e)
        {
            dt.findCuDan(txtsearch.Text, dgvCuDan);
        }

        private void FrmThongTinDanCu_Load(object sender, EventArgs e)
        {

        }

        private void dtngayCap_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
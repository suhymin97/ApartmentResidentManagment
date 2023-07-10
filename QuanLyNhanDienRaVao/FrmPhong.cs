using System;
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
    public partial class FrmPhong : Form
    {
        Data dt = new Data();
        public FrmPhong()
        {
            InitializeComponent();
        }

        private void FrmPhong_Load(object sender, EventArgs e)
        {
            dt.loadPhong(dgvdata);
        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {
            dt.findPhong(dgvdata,txtsearch.Text);
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaphong.Text = dgvdata.CurrentRow.Cells[0].Value!=null? dgvdata.CurrentRow.Cells[0].Value.ToString() : "";
            txtgia.Text = dgvdata.CurrentRow.Cells[1].Value !=null ? dgvdata.CurrentRow.Cells[1].Value.ToString() : "";
            txtsonguoi.Text = dgvdata.CurrentRow.Cells[2].Value != null ? dgvdata.CurrentRow.Cells[2].Value.ToString() : "" ; 
            txttinhtrang.Text = dgvdata.CurrentRow.Cells[3].Value != null ? dgvdata.CurrentRow.Cells[3].Value.ToString() : "" ; 
            txtsophong.Text = dgvdata.CurrentRow.Cells[4].Value != null ? dgvdata.CurrentRow.Cells[4].Value.ToString() : "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dt.themPhong(txtmaphong.Text, txtgia.Text, txtsonguoi.Text, txttinhtrang.Text, txtsophong.Text,true);
            dt.loadPhong(dgvdata);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            dt.deletePhong(txtmaphong.Text);
            dt.loadPhong(dgvdata);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            dt.themPhong(txtmaphong.Text, txtgia.Text, txtsonguoi.Text, txttinhtrang.Text, txtsophong.Text,false);
            dt.loadPhong(dgvdata);
        }
    }
}

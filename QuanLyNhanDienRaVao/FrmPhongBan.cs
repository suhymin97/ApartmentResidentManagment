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
    public partial class FrmPhongBan : Form
    {
        Data dt = new Data();
        public FrmPhongBan()
        {
            InitializeComponent();
        }

        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            dt.loadPhong(dgvdata);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            dt.findPhong(dgvdata, txtsearch.Text);
        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dgvdata.CurrentRow.Cells[0].Value != null ? dgvdata.CurrentRow.Cells[0].Value.ToString() : "";
            txtgia.Text = dgvdata.CurrentRow.Cells[1].Value != null ? dgvdata.CurrentRow.Cells[1].Value.ToString() : "";
            txtsonguoi.Text = dgvdata.CurrentRow.Cells[2].Value != null ? dgvdata.CurrentRow.Cells[2].Value.ToString() : "";
            cbtinhtrang.Text = dgvdata.CurrentRow.Cells[3].Value != null ? dgvdata.CurrentRow.Cells[3].Value.ToString() : "";
            txtsophong.Text = dgvdata.CurrentRow.Cells[4].Value != null ? dgvdata.CurrentRow.Cells[4].Value.ToString() : "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            dt.themPhong(txtma.Text, txtgia.Text, txtsonguoi.Text, cbtinhtrang.Text, txtsophong.Text, true);
            dt.loadPhong(dgvdata);
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            dt.deletePhong(txtma.Text);
            dt.loadPhong(dgvdata);
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            dt.themPhong(txtma.Text, txtgia.Text, txtsonguoi.Text, cbtinhtrang.Text, txtsophong.Text, false);
            dt.loadPhong(dgvdata);
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}

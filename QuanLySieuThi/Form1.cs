using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySieuThi.FORMs;
using QuanLySieuThi.UCs;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySieuThi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UCPic uv = new UCPic();
            panel1.Controls.Clear();
            panel1.Controls.Add(uv);
            uv.Dock = DockStyle.Fill;
        }

        private void quảnLýPhiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapHangMoi nh = new NhapHangMoi();
            panel1.Controls.Clear();
            panel1.Controls.Add(nh);
            nh.Dock = DockStyle.Fill;
        }

        private void quảnLýHàngHóaNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HangHoaNhap nh = new HangHoaNhap();
            panel1.Controls.Clear();
            panel1.Controls.Add(nh);
            nh.Dock = DockStyle.Fill;
        }

        private void quảnLýBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDonBan bh = new HoaDonBan();
            panel1.Controls.Clear();
            panel1.Controls.Add(bh);
            bh.Dock = DockStyle.Fill;
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien nv = new QuanLyNhanVien();
            panel1.Controls.Clear();
            panel1.Controls.Add(nv);
            nv.Dock = DockStyle.Fill;
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang kh = new QuanLyKhachHang();
            panel1.Controls.Clear();
            panel1.Controls.Add(kh);
            kh.Dock = DockStyle.Fill;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}

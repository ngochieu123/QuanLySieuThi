using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySieuThi.UCs
{
    public partial class QuanLyKhachHang : UserControl
    {
        public QuanLyKhachHang()
        {
            InitializeComponent();
        }
        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "select *from KhachHang";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgvKh.DataSource = dt;
        }
        public void LoadData()
        {
            Matxt.DataBindings.Clear();
            Matxt.DataBindings.Add("Text", dtgvKh.DataSource, "MaKH");

            Tentxt.DataBindings.Clear();
            Tentxt.DataBindings.Add("Text", dtgvKh.DataSource, "HoTen");

            DCtxt.DataBindings.Clear();
            DCtxt.DataBindings.Add("Text", dtgvKh.DataSource, "DiaChi");

            NStxt.DataBindings.Clear();
            NStxt.DataBindings.Add("Text", dtgvKh.DataSource, "NamSinh");

            SDTtxt.DataBindings.Clear();
            SDTtxt.DataBindings.Add("Text", dtgvKh.DataSource, "SDT");


        }
        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string them = "insert into KhachHang values ('" + Matxt.Text.Trim() + "', N'" + Tentxt.Text.Trim() + "', N'" + DCtxt.Text.Trim() + "',N'" + SDTtxt.Text.Trim() + "', '" + NStxt.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dtgvKh.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string sua = "update KhachHang set MaKH = '" + Matxt.Text.Trim() + "',HoTen = N'" + Tentxt.Text.Trim() + "',NamSinh = '" + NStxt.Text.Trim() + "',DiaChi = N'" + DCtxt.Text.Trim() + "',sdt = '" + SDTtxt.Text.Trim() + "' where  MaKH = '" + Matxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dtgvKh.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string xoa;
                xoa = "delete KhachHang where MaKH = '" + Matxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dtgvKh.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

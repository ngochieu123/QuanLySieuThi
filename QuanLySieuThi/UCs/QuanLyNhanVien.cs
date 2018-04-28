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
using QuanLySieuThi.FORMs;
using QuanLySieuThi.UCs;

namespace QuanLySieuThi.UCs
{
    public partial class QuanLyNhanVien : UserControl
    {
        public QuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "select *from NhanVien";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgvNV.DataSource = dt;
        }
        private void LoadData()
        {
            Matxt.DataBindings.Clear();
            Matxt.DataBindings.Add("Text", dtgvNV.DataSource, "MaNV");

            Tentxt.DataBindings.Clear();
            Tentxt.DataBindings.Add("Text", dtgvNV.DataSource, "HoTen");

            DCtxt.DataBindings.Clear();
            DCtxt.DataBindings.Add("Text", dtgvNV.DataSource, "DiaChi");

            NStxt.DataBindings.Clear();
            NStxt.DataBindings.Add("Text", dtgvNV.DataSource, "NamSinh");

            SDTtxt.DataBindings.Clear();
            SDTtxt.DataBindings.Add("Text", dtgvNV.DataSource, "SDT");


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string them = "insert into NhanVien values ('" + Matxt.Text.Trim() + "', N'" + Tentxt.Text.Trim() + "', N'" + DCtxt.Text.Trim() + "', '" + NStxt.Text.Trim() + "',N'" + SDTtxt.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dtgvNV.DataSource = dt;
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
                string sua = "update NhanVien set MaNV = '" + Matxt.Text.Trim() + "',HoTen = N'" + Tentxt.Text.Trim() + "',NamSinh = '" + NStxt.Text.Trim() + "',DiaChi = N'" + DCtxt.Text.Trim() + "',SDT = '" + SDTtxt.Text.Trim() + "' where  MaNV = '" + Matxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dtgvNV.DataSource = dt;
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
                xoa = "delete NhanVien where MaNV = '" + Matxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dtgvNV.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }
    }
}

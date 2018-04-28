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
    public partial class HangHoaNhap : UserControl
    {
        public HangHoaNhap()
        {
            InitializeComponent();
        }

        private void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "SELECT PhieuNhap_HangHoa.SoPhieu as SoPhieu,PhieuNhap_HangHoa.MaHang as MaHang,HangHoa.TenHang as TenHang,PhieuNhap_HangHoa.SoLuongNhap as SoLuongNhap,PhieuNhap_HangHoa.DonGiaNhap as DonGiaNhap from PhieuNhap_HangHoa inner join HangHoa on PhieuNhap_HangHoa.MaHang=HangHoa.MaHang";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgvhh.DataSource = dt;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select MaHang from HangHoa";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "MaHang";
            comboBox2.DisplayMember = "MaHang";
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select SoPhieu from PhieuNhap_HangHoa";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "SoPhieu";
            comboBox1.DisplayMember = "SoPhieu";
        }

        private void LoadData()
        {
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("Text", dtgvhh.DataSource, "SoPhieu");

            Tentxt.DataBindings.Clear();
            Tentxt.DataBindings.Add("Text", dtgvhh.DataSource, "SoluongNhap");

            Dtxt.DataBindings.Clear();
            Dtxt.DataBindings.Add("Text", dtgvhh.DataSource, "DonGiaNhap");

            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dtgvhh.DataSource, "MaHang");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string xoa;
                xoa = "delete PhieuNhap where SoPhieu = '" + comboBox1.Text.Trim() + "' and MaHang='" + comboBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dtgvhh.DataSource = dt;
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
                string sua = "update PhieuNhap_HangHoa set SoPhieu = '" + comboBox1.Text.Trim() + "',SoLuongNhap = N'" + Tentxt.Text.Trim() + "',DonGiaNhap = '" + Dtxt.Text.Trim() + "',MaHang = N'" + comboBox2.Text.Trim() + "' where  MaHang = '" + comboBox2.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dtgvhh.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string them = "insert into PhieuNhap_HangHoa values ('" + comboBox1.Text.Trim() + "',N'" + comboBox2.Text.Trim() + "', '" + Tentxt.Text.Trim() + "', '" + Dtxt.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dtgvhh.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HangHoaNhap_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }
    }
}

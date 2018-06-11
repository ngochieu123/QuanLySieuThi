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
    public partial class HoaDonBan : UserControl
    {
        public HoaDonBan()
        {
            InitializeComponent();
        }
        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select HoaDonTT.MaHD as MaHD,NhanVien.HoTen as TenNV,HoaDonTT.MaKH as MaKH,HoaDonTT.NgayLap as NgayLap,HoaDonTT.DonGiaBan as DonGiaBan,HoaDonTT.SoLuongBan as SoLuongBan,NhanVien.MaNV as MaNV from HoaDonTT inner join NhanVien on HoaDonTT.NhanVienBan=NhanVien.MaNV ";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgvBan.DataSource = dt;
        }
        public void loadComboThuNgan()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select MaNV from NhanVien";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "MaNV";
            comboBox1.DisplayMember = "MaNV";

        }
        public void loadComboKH()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select MaKH from KhachHang";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "MaKH";
            comboBox2.DisplayMember = "MaKH";

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string them = "insert into PhieuNhap values ('" + textBox1.Text.Trim() + "', '" + comboBox2.Text.Trim() + "', '" + Tentxt.Text.Trim() + "',N'" + Dtxt.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox1.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dtgvBan.DataSource = dt;
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
                string sua = "update PhieuNhap set MaHD = '" + textBox1.Text.Trim() + "',MaKH = " + comboBox2.Text.Trim() + "',NgayLap = '" + Tentxt.Text.Trim() + "',DonGiaBan = N'" + Dtxt.Text.Trim() + "',SoLuongBan = N'" + textBox2.Text.Trim() + "',NhanVienBan = N'" + comboBox1.Text.Trim() + "' where  MaHD = '" + textBox1.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dtgvBan.DataSource = dt;
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
                xoa = "delete PhieuNhap where MaHD = '" + textBox1.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dtgvBan.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadData()
        {
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("Text", dtgvBan.DataSource, "MaNV");

            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dtgvBan.DataSource, "MaKH");

            Tentxt.DataBindings.Clear();
            Tentxt.DataBindings.Add("Text", dtgvBan.DataSource, "NgayLap");

            Dtxt.DataBindings.Clear();
            Dtxt.DataBindings.Add("Text", dtgvBan.DataSource, "DonGiaBan");

            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", dtgvBan.DataSource, "SoLuongBan");

            textBox1.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dtgvBan.DataSource, "MaHD");


        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            loadComboKH();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            loadComboThuNgan();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }
    }
}

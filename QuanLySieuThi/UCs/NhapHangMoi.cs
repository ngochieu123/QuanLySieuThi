using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace QuanLySieuThi.UCs
{
    public partial class NhapHangMoi : UserControl
    {
        public NhapHangMoi()
        {
            InitializeComponent();
        }
        public void KetNoi()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "SELECT NhaCungCap.MaNCC as MaNCC,NhaCungCap.TenNCC as TenNCC,NhanVien.MaNV as MaNV,NhanVien.HoTen as TenNV,PhieuNhap.NgayNhap as NgayNhap,PhieuNhap.SoPhieu as SoPhieu from PhieuNhap inner join NhaCungCap on PhieuNhap.MaNCC = NhaCungCap.MaNCC inner join NhanVien on PhieuNhap.MaNV=NhanVien.MaNV inner join PhieuNhap_HangHoa on PhieuNhap.SoPhieu=PhieuNhap_HangHoa.SoPhieu";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtgvNhap.DataSource = dt;
        }
        public void loadComboNCC()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select MaNCC, TenNCC from NhaCungCap";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "MaNCC";
            comboBox1.DisplayMember = "MaNCC";

        }
        public void loadComboMNV()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
            conn.Open();
            string sql = "Select MaNV from NhanVien";
            SqlDataAdapter daPhong = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            daPhong.Fill(dt);

            comboBox2.DataSource = dt;
            comboBox2.ValueMember = "MaNV";
            comboBox2.DisplayMember = "MaNV";

        }
        public void LoadData()
        {
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("Text", dtgvNhap.DataSource, "MaNCC");

            Tentxt.DataBindings.Clear();
            Tentxt.DataBindings.Add("Text", dtgvNhap.DataSource, "SoPhieu");

            Dtxt.DataBindings.Clear();
            Dtxt.DataBindings.Add("Text", dtgvNhap.DataSource, "NgayNhap");

            comboBox2.DataBindings.Clear();
            comboBox2.DataBindings.Add("Text", dtgvNhap.DataSource, "MaNV");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=DOHIEU-PC\SQLEXPRESS;Initial Catalog=Supermarket;Integrated Security=True");
                conn.Open();
                string them = "insert into PhieuNhap values ('" + comboBox1.Text.Trim() + "', '" + Tentxt.Text.Trim() + "', '" + Dtxt.Text.Trim() + "',N'" + comboBox2.Text.Trim() + "')";
                SqlCommand comm = new SqlCommand(them, conn);
                SqlDataAdapter daThem = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daThem.Fill(dt);
                dtgvNhap.DataSource = dt;
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
                string sua = "update PhieuNhap set MaNCC = '" + comboBox1.Text.Trim() + "',SoPhieu = N'" + Tentxt.Text.Trim() + "',NgayNhap = '" + Dtxt.Text.Trim() + "',MaNV = N'" + comboBox2.Text.Trim() + "' where  SoPhieu = '" + Tentxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(sua, conn);
                SqlDataAdapter daSua = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daSua.Fill(dt);
                dtgvNhap.DataSource = dt;
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
                xoa = "delete PhieuNhap where SoPhieu = '" + Tentxt.Text.Trim() + "'";
                SqlCommand comm = new SqlCommand(xoa, conn);
                SqlDataAdapter daXoa = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                daXoa.Fill(dt);
                dtgvNhap.DataSource = dt;
                KetNoi();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            loadComboNCC();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            loadComboMNV();
        }

        private void NhapHangMoi_Load(object sender, EventArgs e)
        {
            KetNoi();
            LoadData();
        }
    }
}

create database QLST1
use QLST1


go
create table NhaCungCap(
	MaNCC char(10) PRIMARY KEY,
	TenNCC nvarchar(50),
	DiaChi nvarchar(50),
	sdt char(15)
)
go
create table NhanVien(
	MaNV char(10) PRIMARY KEY,
	HoTen nvarchar(50),
	DiaChi nvarchar(50),
	NgaySinh datetime,
	SDT char(15)
)
go
create table PhieuNhap(
	SoPhieu char(10) PRIMARY KEY,
	MaNCC char(10),
	NgayNhap datetime,
	MaNV char(10),
	CONSTRAINT MaNCC FOREIGN KEY(MaNCC) REFERENCES NhaCungCap(MaNCC),
	CONSTRAINT MaNV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
)
go
create table HangHoa(
	MaHang char(10) PRIMARY KEY,
	TenHang nvarchar(50),
	HinhThucDongGoi nvarchar(50),
	SoLuongTon int,
	LoaiHang NVARCHAR(50)
)
go
create table PhieuNhap_HangHoa(
    MaPN_HH CHAR(10) PRIMARY KEY,
	SoPhieu char(10),
	MaHang char(10),
	SoLuongNhap int,
	DonGiaNhap decimal,
	CONSTRAINT SoPhieu FOREIGN KEY(SoPhieu) REFERENCES PhieuNhap(SoPhieu),
	CONSTRAINT MaHang FOREIGN KEY(MaHang) REFERENCES HangHoa(MaHang)
)
go
create table KhachHang(
	MaKH char(10) PRIMARY KEY,
	HoTen nvarchar(50),
	DiaChi nvarchar(50),
	sdt char(15),
	NgaySinh datetime
)
go
create table HoaDonTT(
	MaHD char(10) PRIMARY KEY,
	MaKH char(10),
	NgayLap datetime,
	DonGiaBan decimal,
	SoLuongBan int,
	NhanVienBan char(10),
	CONSTRAINT MaKH FOREIGN KEY(MaKH) REFERENCES KhachHang(MaKH),
	CONSTRAINT NhanVienBan FOREIGN KEY(NhanVienBan) REFERENCES NhanVien(MaNV)
)
go
create table HD_HH(
	MaHD_HH CHAR(10) PRIMARY KEY,
	MaHD char(10),
	MaHang char(10),
	CONSTRAINT MaHD FOREIGN KEY(MaHD) REFERENCES HoaDonTT(MaHD),
	CONSTRAINT MaHangHoa FOREIGN KEY(MaHang) REFERENCES HangHoa(MaHang)
)
go
insert into NhaCungCap
values
('C01',N'unilever',N'Hà Nội','0167358942'),
('C02',N'Hồng Hà',N'Hà Nội','0964852731'),
('C03',N'Nestle',N'Đà Nẵng','01652036762'),
('C04',N'NXB Giáo Dục',N'Hà Nội','0166854952'),
('C05',N'Kinh Đô',N'Bắc Ninh','0944325621'),
('C06',N'Hữu Nghị',N'Hưng Yên','0975284621'),
('C07',N'CTCP nước giải khát Hà Nội',N'Hà Nội','0182564328'),
('C08',N'Song Long',N'Thái Nguyên','0167964942'),
('C09',N'CTCP Sách Việt',N'TP Hồ Chí Minh','0175894665');
go
insert into NhanVien
Values
('N0001',N'Trịnh Văn Cảnh',N'Cầu Giấy-Hà Nội',1972,'0914356248'),
('N0002',N'Nguyễn Ngọc Minh',N'Đống Đa-Hà Nội',1989,'0929654387'),
('N0003',N'Vũ Xuân Thịnh',N'Thanh Xuân-Hà Nội',1962,'0944584628'),
('N0004',N'Nguyễn Văn An',N'Cầu Giấy-Hà Nội',1968,'0167584952'),
('N0005',N'Vũ Thị Phương Thảo',N'Bắc Từ Liêm-Hà Nội',1994,'0165874985'),
('N0006',N'Nguyễn Minh Nga',N'Tây Hồ-Hà Nội',1992,'0964251359'),
('N0007',N'Trần Văn Huy',N'Hai Bà Trưng-Hà Nội',1986,'0165849728'),
('N0008',N'Nguyễn Xuân Toàn',N'Cầu Giấy-Hà Nội',1965,'01675478219'),
('N0009',N'Đỗ Văn Hùng',N'Thanh Xuân-Hà Nội',1985,'0924589671'),
('N0010',N'Trần Ngọc Hải',N'Tây Hồ-Hà Nội',1993,'0984625714'),
('N0011',N'Trần Thị Trang',N'Cầu Giấy-Hà Nội',1986/12/12,'0154628729');
go
insert into PhieuNhap
values
('SP01','C03','12/15/2012','N0007'),
('SP02','C01','01/06/2013','N0009'),
('SP03','C02','02/17/2013','N0007'),
('SP04','C04','12/21/2012','N0008'),
('SP05','C05','06/15/2014','N0009'),
('SP06','C06','12/07/2014','N0008'),
('SP07','C07','03/19/2015','N0007'),
('SP08','C08','06/08/2016','N0009'),
('SP09','C09','03/15/2018','N0008');
go
insert into HangHoa
values
('H001',N'Kem đánh răng PS','hộp',568,N'Tiêu Dùng'),
('H002',N'Ghế nhựa học sinh','chiếc',233,N'Tiêu Dùng'),
('H003',N'Vở học sinh 120 trang','quyển',761,N'Văn phòng phẩm'),
('H004',N'Nescafe','hộp',412,N'Thực phẩm'),
('H005',N'Bia Hà Nội','thùng',455,N'Đồ uống'),
('H006',N'Sách giáo khoa Toán 6','quyển',210,N'Sách'),
('H007',N'Bánh mỳ sữa','chiếc',102,N'Thực phẩm'),
('H008',N'Bánh mỳ chocolate','chiếc',213,N'Thực phẩm'),
('H009',N'Đắc nhân tâm','quyển',463,N'Sách'),
('H010',N'Bàn học 1.2mx0.5m','chiếc',384,N'Tiêu Dùng'),
('H011',N'Bàn chải PS','chiếc',365,N'Tiêu Dùng'),
('H012',N'Bột giặt OMO','túi',705,N'Tiêu Dùng'),
('H013',N'Milo 10 gói','túi',153,N'Thực phẩm');
GO
insert into PhieuNhap_HangHoa
values
('MPNHH01','SP01','H004',1200,'73900000'),
('MPNHH02','SP01','H013',200,'6500000'),
('MPNHH03','SP02','H006',1000,'10000000'),
('MPNHH04','SP03','H008',800,'3200000'),
('MPNHH05','SP04','H007',650,'1950000'),
('MPNHH06','SP05','H010',600,'540000000'),
('MPNHH07','SP05','H002',600,'540000000'),
('MPNHH08','SP06','H001',1000,'25600000'),
('MPNHH09','SP06','H011',400,'8000000'),
('MPNHH10','SP06','H012',1000,'230000000'),
('MPNHH11','SP07','H005',200,'40000000'),
('MPNHH12','SP08','H009',400,'8000000'),
('MPNHH13','SP09','H003',1000,'6000000');
go
insert into KhachHang
values
('K0001',N'Trịnh Văn Hoàng',N'Cầu Giấy-Hà Nội','0914356256',1972),
('K0002',N'Nguyễn Ngọc Hiếu',N'Đống Đa-Hà Nội','0927654375',1989),
('K0003',N'Vũ Xuân Tường',N'Thanh Xuân-Hà Nội','0945684629',1962),
('K0004',N'Nguyễn Văn Hảo',N'Cầu Giấy-Hà Nội','0166584948',1968),
('K0005',N'Vũ Thị Thu Phương',N'Bắc Từ Liêm-Hà Nội','0165874932',1994),
('K0006',N'Nguyễn Minh Ngọc',N'Tây Hồ-Hà Nội','0915251341',1992),
('K0007',N'Trần Văn Minh',N'Hai Bà Trưng-Hà Nội','0165849728',1986),
('K0008',N'Nguyễn Xuân Kế',N'Cầu Giấy-Hà Nội','01675478322',1965),
('K0009',N'Đỗ Văn Khánh',N'Thanh Xuân-Hà Nội','0934589782',1985),
('K0010',N'Trần Ngọc Hữu',N'Tây Hồ-Hà Nội','0984625825',1993),
('K0011',N'Trần Thị Linh',N'Cầu Giấy-Hà Nội','0164628832',1986);
go
insert into HoaDonTT
values
('HD0001','K0001','12/22/2012','25000',1,'N0011'),
('HD0002','K0002','01/31/2013','64000',2,'N0003'),
('HD0003','K0003','02/21/2013','1000000',1,'N0010'),
('HD0004','K0004','12/30/2012','20000',1,'N0001'),
('HD0005','K0005','06/01/2014','100000',1,'N0008'),
('HD0006','K0006','12/10/2014','92000',2,'N0002'),
('HD0007','K0007','03/20/2015','12000',1,'N0006'),
('HD0008','K0008','06/30/2016','42000',7,'N0004'),
('HD0009','K0009','03/14/2018','54000',1,'N0009'),
('HD0010','K0010','06/16/2016','31000',1,'N0005'),
('HD0011','K0011','03/06/2018','45000',1,'N0007');
go
insert into HD_HH
values
('MHDHH01','HD0001','H011'),
('MHDHH02','HD0002','H001'),
('MHDHH03','HD0003','H010'),
('MHDHH04','HD0004','H009'),
('MHDHH05','HD0005','H002'),
('MHDHH06','HD0006','H004'),
('MHDHH07','HD0007','H006'),
('MHDHH08','HD0008','H003'),
('MHDHH09','HD0009','H008'),
('MHDHH10','HD0010','H005'),
('MHDHH11','HD0011','H007');
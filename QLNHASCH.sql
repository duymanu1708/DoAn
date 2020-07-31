USE master
GO
--Tao CSDL
CREATE DATABASE QLNHASACH
Go

USE QLNHASACH
Go

/****** Object:  Table NSX    ******/
CREATE TABLE NSX(
	MaNSX varchar(10) NOT NULL,
	TenNSX nvarchar(100) NULL,
	DiaChiNSX nvarchar(100) NULL,
 CONSTRAINT PK_NSX PRIMARY KEY (MaNSX)
)
GO

/****** Object:  Table LOAI  ******/
CREATE TABLE LOAISP(
	MaLoai int  NOT NULL,
	TenLoai nvarchar(50) NULL,
	CONSTRAINT PK_NhomSP PRIMARY KEY (MaLoai )
)
GO
/****** Object:  Table KHACHHANG   ******/
CREATE TABLE KHACHHANG(
	MaKH varchar(10) NOT NULL,
	TenKH nvarchar(30) NULL,
	GioiTinh bit NOT NULL,
	SoDT varchar(12) NOT NULL,
	DiaChi nvarchar(50)  NULL,
 CONSTRAINT PK_KhachHang PRIMARY KEY(MaKH)
)
GO
/******Table SANPHAM   ******/
CREATE TABLE SANPHAM(
	MaSP varchar(10) NOT NULL,
	TenSP nvarchar(50) NULL,
	SoLuong int NULL,
	DonVi nvarchar(20) NULL,
	DonGia float NULL,
	MaNSX varchar(10) NULL,
	GiaGoc float NULL,
	MaLoai int NULL,
	CONSTRAINT PK_SanPham PRIMARY KEY (MaSP )
)
GO
/****** Object:  Table DONHANG   ******/
CREATE TABLE DONHANG(
	MaHD varchar(10) NOT NULL,
	MaKH varchar(10) NULL,
	NgayLap datetime NULL,
 CONSTRAINT PK_DonHang PRIMARY KEY (MaHD)
)
GO
/****** Object:  Table CTHD ******/
CREATE TABLE CTHD(
	MaCTHD int NOT NULL,
	MaHD varchar(10) NOT NULL,
	MaSP varchar(10) NULL,
	SoLuong int NULL,
	Tong float NULL,
 CONSTRAINT PK_CTHD PRIMARY KEY  (MaCTHD)
) 
GO

ALTER TABLE SANPHAM ADD  CONSTRAINT FK_SanPham_Loai FOREIGN KEY(MaLoai)REFERENCES LOAISP (MaLoai)
GO

ALTER TABLE SANPHAM ADD  CONSTRAINT FK_SanPham_NSX FOREIGN KEY(MaNSX) REFERENCES NSX (MaNSX)
GO

ALTER TABLE DONHANG  ADD  CONSTRAINT FK_DonHang_KhachHang FOREIGN KEY(MaKH) REFERENCES KHACHHANG (MaKH)
GO

ALTER TABLE CTHD  ADD  CONSTRAINT FK_CTHD_DonHang FOREIGN KEY(MaHD) REFERENCES DONHANG (MaHD)
GO

ALTER TABLE CTHD   ADD  CONSTRAINT FK_CTHD_SanPham FOREIGN KEY(MaSP) REFERENCES SANPHAM (MaSP)
GO


--Insert table NSX
insert into NSX values('NSX0001', N'Kata',N'Quận 5, TP. Hồ Chí Minh')
insert into NSX values('NSX0002', N'Thiên Long',N'Quận Bình Thạnh, TP. Hồ Chí Minh')
insert into NSX values('NSX0003', N'Eagle',N'Thủ Dầu Một, Bình Dương')
insert into NSX values('NSX0004', N'Genetis',N'Đóng Đa, Hà Nội')
insert into NSX values('NSX0005', N'Double A',N'Quận 7, TP. Hồ Chí Minh')
insert into NSX values('NSX0006', N'Queen',N'Bến Cát, Bình Dương')
insert into NSX values('NSX0007', N'Gstar',N'Tp. Biên Hòa, Đồng Nai')
insert into NSX values('NSX0008', N'Phi Mã',N'Quận 10, TP. Hồ Chí Minh')
insert into NSX values('NSX0009', N'Pentel',N'Quận 5, TP. Hồ Chí Minh')

--Insert table LOAISP
insert into LOAISP values(1,N'Dụng cụ học tập')
insert into LOAISP values(2,N'Giấy')
insert into LOAISP values(3,N'Sách')
insert into LOAISP values(4,N'Trang Trí')

--Insert table SANPHAM
insert into SANPHAM values('SP0001', N'Bút chì bấm Gstar',19,N'Cây',15000,'NSX0007',10000, 1)
insert into SANPHAM values('SP0002', N'Bút chì pentel',30,N'Cây',20000,'NSX0009',16000, 1)
insert into SANPHAM values('SP0003', N'Viết bi thiên long',10,N'Cây',5000,'NSX0002',4000, 1)
insert into SANPHAM values('SP0004', N'Bảng phi mã',30,N'Cái',14000,'NSX0008',10000, 1)
insert into SANPHAM values('SP0005', N'Bình mực queen',50,N'Bình',5000,'NSX0006',3500, 1)
insert into SANPHAM values('SP0006', N'Đồng hồ',10,N'Cái',100000,'NSX0003',80000, 4)
insert into SANPHAM values('SP0007', N'Giấy A4 Double A',30,N'Mẫu',65000,'NSX0005',50000, 2)
insert into SANPHAM values('SP0008', N'Khung ảnh đơn',15,N'Cái',40000,'NSX0003',30000, 4)
insert into SANPHAM values('SP0009', N'Khung ảnh đôi',10,N'Cái',60000,'NSX0003',50000, 4)
insert into SANPHAM values('SP0010', N'Hộp bút vẽ',15,N'Hộp',45000,'NSX0006',30000, 1)
insert into SANPHAM values('SP0011', N'Note book',10,N'Cuốn',40000,'NSX0004',34000, 2)
insert into SANPHAM values('SP0012', N'Tickers',30,N'Mẫu',5000,'NSX0001',3000, 2)

--Insert table KHACHHANG
insert into KHACHHANG values('KH0001', N'Nguyễn Mạnh Hưng',1,'0913133756',N'Phú lợi, Thủ Dầu Một, Bình Dương')
insert into KHACHHANG values('KH0002', N'Lê Thị Trúc Anh',0,'0908350777',N'Tân Định. Bến Cát, Bình Dương')
insert into KHACHHANG values('KH0003', N'Phạm Thế Phong',1,'01265123744',N'Phú hòa, Thủ Dầu Một, Bình Dương')





--Insert table DONHANG
insert into DONHANG values('HD0001','KH0001','5/9/2016')
insert into DONHANG values('HD0002','KH0002','10/5/2017')
insert into DONHANG values('HD0003','KH0002','8/4/2017')
insert into DONHANG values('HD0004','KH0003','2/1/2017')

--Insert table CTHD
insert into CTHD values(1,'HD0001','SP0001', 2 , 30000)
insert into CTHD values(2,'HD0001','SP0011', 1 , 40000)
insert into CTHD values(3,'HD0001','SP0005', 1 , 5000)
insert into CTHD values(4,'HD0002','SP0006', 1 , 100000)
insert into CTHD values(5,'HD0002','SP0008', 2 , 80000)
insert into CTHD values(6,'HD0003','SP0003', 3, 15000)
-- SoLuong, DonGia và DonGiaGoc >=0 trong bảng SANPHAM 
alter table SANPHAM add constraint  CHK_SoLuong Check (SoLuong>=0)
alter table SANPHAM add constraint  CHK_DonGia Check (DonGia>=0)
alter table SANPHAM add constraint  CHK_DonGiaGoc Check (GiaGoc>=0)

-- DonGia >= DonGiaGoc của 1 sẩn phẩm trong bảng SANPHAM
alter table SANPHAM add constraint  CHK_DonGia_GiaGoc Check (DonGia>=GiaGoc)
Go
-- Tigger 2: SoLuong của một sản phẩm khi thêm mới CTHD <= SoLuong tồn của sản phẩm đó trong bản SANPHAM. 
-- Cập nhật lại SoLuong sản phẩm trong bảng SANPHAM
Create trigger trg_InsertCTHD_SoLuong
on CTHD for insert
as
	declare @SLBan int, @SLTon int, @MaSP nvarchar(10)
	select @SLBan=SoLuong, @MaSP = MaSP from inserted
	select @SLTon = SoLuong from SANPHAM
	if(@SLTon>=@SLBan)
		update SANPHAM
		Set SoLuong = @SLTon - @SLBan
		where MaSP = @MaSP
	else
		begin 
		    raiserror (N'Vượt quá số lượng tồn!!!',0,1)
			rollback transaction
		end
	 
Go

-- Xây dựng hàm phát sinh mã đơn hàng có dạng "HD0001" theo thứ tự tăng dần
Create function fn_CreateMaHD()
	returns nvarchar(10)
begin
		
		declare @MaHDOld varchar(10), @MaHDNew nvarchar(10)
		select Top 1 @MaHDOld=MaHD from DONHANG order by MaHD Desc
		Return 'HD' + format(right(@MaHDOld,4)+1,'000#')
end
Go

select dbo.fn_CreateMaHD()


-- Xây dựng store phát sinh mã đơn hàng có dạng "HD0001" theo thứ tự tăng dần
Go
Create procedure proc_CreateMaHD
	@MaHDNew nvarchar(10) output
as
		
		declare @MaHDOld varchar(10)
		select Top 1 @MaHDOld=MaHD from DONHANG order by MaHD Desc
		set @MaHDNew = 'HD' + format(right(@MaHDOld,4)+1,'000#')
Go

Declare @MaHD nvarchar(10) 
Exec dbo.proc_CreateMaHD @MaHD output
print @MaHD
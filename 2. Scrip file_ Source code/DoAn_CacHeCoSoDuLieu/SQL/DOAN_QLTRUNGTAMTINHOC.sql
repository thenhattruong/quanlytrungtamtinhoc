CREATE DATABASE DOAN_QLTRUNGTAMTINHOC ON PRIMARY
(
	name =DOAN_QLTRUNGTAMTINHOC, Filename= 'D:\DoAn_CacHeCoSoDuLieu\DOAN_QLTRUNGTAMTINHOC.mdf', Size=20MB, Maxsize=50MB, Filegrowth=15%
)
LOG ON
(
	NAME = DOAN_QLTRUNGTAMTINHOCLog, Filename= 'D:\DoAn_CacHeCoSoDuLieu\DOAN_QLTRUNGTAMTINHOCLog.ldf', Size=10MB, Maxsize=20MB, Filegrowth=20%
);
GO
USE DOAN_QLTRUNGTAMTINHOC
GO

-- TẠO CÁC THỰC THỂ
	-- Bảng TAIKHOAN
CREATE TABLE TAIKHOAN
(
	MADANGNHAP CHAR(4) PRIMARY KEY,
	MATKHAU NVARCHAR(10) NOT NULL
);
	-- tạo ràng buộc 
		-- madangnhap là duy nhất
	ALTER TABLE TAIKHOAN
	ADD CONSTRAINT UQ_TAIKHOAN_MADANGNHAP UNIQUE (MADANGNHAP);
GO
	--Bảng HOCVIEN
CREATE TABLE HOCVIEN
(
	MAHV CHAR(4) PRIMARY KEY,
	MALOP CHAR(4),
	HOTEN NVARCHAR(50),
	NGAYSINH DATE,
	DIACHI NVARCHAR(50),
	NGHENGHIEP NVARCHAR(50),
	TINHTRANG NVARCHAR(50),
	SOBIENLAI CHAR(4),
	HOCPHI NVARCHAR(10), 
	GIOITINH NVARCHAR(10) CHECK (GIOITINH IN (N'Nam', N'Nữ'))
);
	-- tạo ràng buộc
		-- ngày sinh không được bằng với ngày của hệ thống
	alter  table HOCVIEN
	add constraint CHK_TABLE_HOCVIEN_NGAYSINH CHECK (NGAYSINH <= GETDATE())
GO
	-- Bảng GIAOVIEN
CREATE TABLE GIAOVIEN	
(
	MAGV CHAR(4) PRIMARY KEY,
	HOTEN NVARCHAR(50),
	NGAYSINH DATE,
	DIACHI NVARCHAR(50),
	DIENTHOAI NVARCHAR(10),
	TRINHDO NVARCHAR(50),
	GIOITINH NVARCHAR(10) CHECK (GIOITINH IN (N'Nam', N'Nữ'))
);
	-- tạo ràng buộc 
		-- ngày sinh không được bằng với ngày của hệ thống
	alter table GIAOVIEN
    add constraint CHK_TABLE_GIAOVIEN_NGAYSINH CHECK (NGAYSINH <= GETDATE()) 
GO
	-- Bảng PHONGHOC
CREATE TABLE PHONGHOC
(
	MAPHONG CHAR(4) PRIMARY KEY,
	TENPHONG NVARCHAR(50),
	TINHTRANG NVARCHAR(50)
)
	-- tạo ràng buộc
	ALTER TABLE PHONGHOC
	ADD CONSTRAINT UQ_MAPHONG UNIQUE (MAPHONG);
GO

	--Bảng LOPHOC
	CREATE TABLE LOPHOC
(
	MALOP CHAR(4) PRIMARY KEY,
	SISO INT,
	MAPHONG CHAR(4),
	MAGV CHAR(4),
	MAKH CHAR(4),
	CAHOC NVARCHAR(20),
	NGAYBATDAU DATE,
	NGAYKETTHUC DATE
)
	-- tạo các ràng buộc và khóa ngoại
	ALTER TABLE LOPHOC
	ADD CONSTRAINT CHK_LOPHOC_NGAY CHECK (NGAYBATDAU <= NGAYKETTHUC);
	ALTER TABLE LOPHOC
	ADD CONSTRAINT UQ_MALOP UNIQUE (MALOP);
GO

	--BẢNG KHÓA HỌC 
CREATE TABLE KHOAHOC
(
	MAKH CHAR(4) PRIMARY KEY,
	TENKH NVARCHAR(50),
	GHICHU NVARCHAR(100)
)
	-- tạo các ràng buộc
	alter table KHOAHOC
	add CONSTRAINT UQ_KHOAHOC_TENKH UNIQUE (TENKH)
GO

	-- TẠO BẢNG ĐIỂM
CREATE TABLE DIEM
(
	MAHV CHAR(4) PRIMARY KEY,
	MAKH CHAR(4),
	MALOP CHAR(4),
	DIEMQT FLOAT,
	DIEMGK FLOAT,
	DIEMCK FLOAT,
	TONGDIEM FLOAT,
	XEPLOAI NVARCHAR(20),
	GHICHU NVARCHAR(20),
	TINHTRANG BIT,
)
	-- tạo ràng buộc
	ALTER TABLE DIEM
	add CONSTRAINT ck_DIEMQT CHECK (DIEMQT >= 0 AND DIEMQT <= 10)
	ALTER TABLE DIEM
	add CONSTRAINT ck_DIEMGK CHECK (DIEMGK >= 0 AND DIEMGK <= 10)
	ALTER TABLE DIEM
	add CONSTRAINT ck_DIEMCK CHECK (DIEMCK >= 0 AND DIEMCK <= 10)

	-- tạo khóa ngoại
	-- Tạo khóa ngoại từ bảng HOCVIEN đến bảng LOPHOC
ALTER TABLE HOCVIEN
ADD CONSTRAINT FK_HOCVIEN_LOPHOC FOREIGN KEY (MALOP) REFERENCES LOPHOC (MALOP);
-- Tạo khóa ngoại từ bảng LOPHOC đến bảng PHONGHOC
ALTER TABLE LOPHOC
ADD CONSTRAINT FK_LOPHOC_PHONGHOC FOREIGN KEY (MAPHONG) REFERENCES PHONGHOC (MAPHONG);
-- Tạo khóa ngoại từ bảng LOPHOC đến bảng GIAOVIEN
ALTER TABLE LOPHOC
ADD CONSTRAINT FK_LOPHOC_GIAOVIEN FOREIGN KEY (MAGV) REFERENCES GIAOVIEN (MAGV);
-- Tạo khóa ngoại từ bảng LOPHOC đến bảng KHOAHOC
ALTER TABLE LOPHOC
ADD CONSTRAINT FK_LOPHOC_KHOAHOC FOREIGN KEY (MAKH) REFERENCES KHOAHOC (MAKH);
-- Tạo khóa ngoại từ bảng DIEM đến bảng HOCVIEN
ALTER TABLE DIEM
ADD CONSTRAINT FK_DIEM_HOCVIEN FOREIGN KEY (MAHV) REFERENCES HOCVIEN (MAHV);
-- Tạo khóa ngoại từ bảng DIEM đến bảng LOPHOC
ALTER TABLE DIEM
ADD CONSTRAINT FK_DIEM_LOPHOC FOREIGN KEY (MALOP) REFERENCES LOPHOC (MALOP);
ALTER TABLE DIEM
DROP CONSTRAINT FK_DIEM_LOPHOC;

--THÊM DỮ LIỆU
	-- bảng khóa học
	INSERT INTO KHOAHOC (MAKH, TENKH, GHICHU)
VALUES
    ('KH01', N'Lập trình C++ căn bản', N'Khóa học về lập trình C++ dành cho người mới bắt đầu'),
    ('KH02', N'Thiết kế đồ họa', N'Khóa học về thiết kế đồ họa và đồ họa máy tính'),
    ('KH03', N'Tin học văn phòng', N'Khóa học về tin học cơ bản và ứng dụng văn phòng'),
    ('KH04', N'Lập trình Python', N'Khóa học về lập trình Python từ cơ bản đến nâng cao'),
    ('KH05', N'Thiết kế web', N'Khóa học về thiết kế và phát triển trang web'),
    ('KH06', N'Lập trình Java', N'Khóa học về lập trình Java và ứng dụng')
	select *from KHOAHOC
go
-- THÊM DỮ LIỆU
	-- bảng phòng học
select *from PHONGHOC
	INSERT INTO PHONGHOC (MAPHONG, TENPHONG, TINHTRANG)
VALUES
    ('PH01', N'Phòng học 01', N'Trống'),
    ('PH02', N'Phòng học 02', N'Đang sử dụng'),
    ('PH03', N'Phòng học 03', N'Trống'),
    ('PH04', N'Phòng học 04', N'Đang sử dụng'),
    ('PH05', N'Phòng học 05', N'Trống'),
    ('PH06', N'Phòng học 06', N'Đang sử dụng'),
    ('PH07', N'Phòng học 07', N'Trống'),
    ('PH08', N'Phòng học 08', N'Đang sử dụng'),
    ('PH09', N'Phòng học 09', N'Trống'),
    ('PH10', N'Phòng học 10', N'Đang sử dụng'),
    ('PH11', N'Phòng học 11', N'Trống'),
    ('PH12', N'Phòng học 12', N'Đang sử dụng'),
    ('PH13', N'Phòng học 13', N'Trống'),
    ('PH14', N'Phòng học 14', N'Đang sử dụng'),
    ('PH15', N'Phòng học 15', N'Trống');
	
	-- bảng giáo viên
		select *from GIAOVIEN
	INSERT INTO GIAOVIEN (MAGV, HOTEN, NGAYSINH, DIACHI, DIENTHOAI, TRINHDO, GIOITINH)
VALUES
    ('GV01', N'Nguyễn Văn Thọ', '1990-01-15', N'Hà Nội', '0123456789', N'Thạc Sĩ', N'Nam'),
    ('GV02', N'Phạm Thị Bùi Trang', '1985-03-25', N'Hồ Chí Minh', '0987654321', N'Cử Nhân', N'Nữ'),
    ('GV03', N'Lê Đức Minh', '1992-07-10', N'Đà Nẵng', '0369874521', N'Tiến Sĩ', N'Nam'),
    ('GV04', N'Trần Thanh Dương Thùy', '1988-11-08', N'Hải Phòng', '0543216789', N'Cử Nhân', N'Nữ'),
    ('GV05', N'Nguyễn Hoàng Quốc Bảo', '1993-05-20', N'Bình Dương', '0789562314', N'Thạc sĩ', N'Nam'),
    ('GV06', N'Phan Thị Bảo Thy', '1982-09-12', N'Long An', '0765432189', N'Cử Nhân', N'Nữ'),
    ('GV07', N'Bùi Văn Giáp', '1991-04-02', N'Cần Thơ', '0321876543', N'Thạc sĩ', N'Nam'),
    ('GV08', N'Vũ Thị Hoa', '1987-08-30', N'An Giang', '0956314782', N'Cử Nhân', N'Nữ'),
    ('GV09', N'Huỳnh Minh Tiến', '1994-12-05', N'Vũng Tàu', '0236541897', N'Cử Nhân', N'Nam'),
    ('GV10', N'Lương Văn Linh', '1989-06-18', N'Tây Ninh', '0619875432', N'Thạc sĩ', N'Nam'),
    ('GV11', N'Đặng Thị Linh Chi', '1984-02-21', N'Quảng Ngãi', '0897432165', N'Cử Nhân', N'Nữ'),
    ('GV12', N'Trần Quốc Thái', '1995-10-03', N'Kiên Giang', '0123654789', N'Cử Nhân', N'Nam'),
    ('GV13', N'Lê Văn Nho', '1983-11-17', N'Bình Phước', '0987456321', N'Tiến Sĩ', N'Nam'),
    ('GV14', N'Nguyễn Thị Oanh', '1990-07-07', N'Lâm Đồng', '0369214785', N'Cử Nhân', N'Nữ'),
    ('GV15', N'Phạm Minh Phương', '1986-09-28', N'Đắk Lắk', '0785643129', N'Cử Nhân', N'Nam');

	-- bảng lớp học
	select *from LOPHOC
	INSERT INTO LOPHOC (MALOP, SISO, MAPHONG, MAGV, MAKH, CAHOC, NGAYBATDAU, NGAYKETTHUC)
VALUES
    ('ML01', 20, 'PH01', 'GV01', 'KH01', N'Sáng thứ 2', '2023-08-07', '2023-11-07'),
    ('ML02', 25, 'PH02', 'GV02', 'KH02', N'Chiều thứ 3', '2023-08-10', '2023-11-10'),
    ('ML03', 15, 'PH03', 'GV03', 'KH03', N'Sáng thứ 4', '2023-08-15', '2023-11-15'),
    ('ML04', 30, 'PH04', 'GV04', 'KH04', N'Chiều thứ 5', '2023-08-20', '2023-11-20'),
    ('ML05', 22, 'PH05', 'GV05', 'KH05', N'Sáng thứ 6', '2023-08-25', '2023-11-25'),
    ('ML06', 18, 'PH06', 'GV06', 'KH06', N'Chiều thứ 7', '2023-09-01', '2023-12-01'),
    ('ML07', 26, 'PH07', 'GV07', 'KH01', N'Sáng Chủ nhật', '2023-09-07', '2023-12-07'),
    ('ML08', 20, 'PH08', 'GV08', 'KH02', N'Chiều thứ 2', '2023-09-15', '2023-12-15'),
    ('ML09', 15, 'PH09', 'GV09', 'KH03', N'Sáng thứ 3', '2023-09-20', '2023-12-20'),
    ('ML10', 28, 'PH10', 'GV10', 'KH04', N'Chiều thứ 4', '2023-09-25', '2023-12-25'),
    ('ML11', 17, 'PH11', 'GV11', 'KH01', N'Sáng thứ 5', '2023-10-01', '2023-12-01'),
    ('ML12', 23, 'PH12', 'GV12', 'KH02', N'Chiều thứ 6', '2023-10-10', '2024-01-10'),
    ('ML13', 14, 'PH13', 'GV13', 'KH03', N'Sáng thứ 7', '2023-10-15', '2023-12-15'),
    ('ML14', 30, 'PH14', 'GV14', 'KH04', N'Chiều Chủ nhật', '2023-10-20', '2024-01-20'),
    ('ML15', 21, 'PH15', 'GV15', 'KH05', N'Sáng thứ 2', '2023-10-25', '2023-12-25');

	-- bảng hoc vien
	select *from HOCVIEN
	INSERT INTO HOCVIEN (MAHV, MALOP, HOTEN, NGAYSINH, DIACHI, NGHENGHIEP, TINHTRANG, SOBIENLAI, HOCPHI, GIOITINH)
VALUES
    ('HV01', 'ML01', N'Nguyễn Thị Nhân', '2000-03-10', N'Hà Nội', N'Học sinh', N'Còn học', 'BL01', 1800000, N'Nữ'),
    ('HV02', 'ML02', N'Trần Văn Nam', '1999-06-25', N'Hồ Chí Minh', N'Sinh viên', N'Còn học', 'BL02', 2500000, N'Nam'),
    ('HV03', 'ML03', N'Lê Thị Lan', '2001-01-15', N'Đà Nẵng', N'Văn phòng', N'Đã học xong', 'BL03', 3500000, N'Nữ'),
    ('HV04', 'ML04', N'Phạm Văn An', '2002-04-30', N'Nghệ An', N'Học sinh', N'Còn học', 'BL04', 2000000, N'Nam'),
    ('HV05', 'ML05', N'Nguyễn Thị Mai', '2000-07-08', N'Bình Dương', N'Sinh viên', N'Còn học', 'BL05', 2800000, N'Nữ'),
    ('HV06', 'ML06', N'Bùi Minh Hoàng', '1998-11-20', N'Long An', N'Văn phòng', N'Đã học xong', 'BL06', 4000000, N'Nam'),
    ('HV07', 'ML07', N'Lê Thị Hà', '2003-02-05', N'Cần Thơ', N'Học sinh', N'Còn học', 'BL07', 1700000, N'Nữ'),
    ('HV08', 'ML08', N'Nguyễn Đức Thắng', '1999-05-18', N'An Giang', N'Sinh viên', N'Còn học', 'BL08', 2600000, N'Nam'),
    ('HV09', 'ML09', N'Hồ Thị Ngọc', '2001-09-07', N'Vũng Tàu', N'Văn phòng', N'Đã học xong', 'BL09', 3800000, N'Nữ'),
    ('HV10', 'ML10', N'Đặng Văn Bình', '2002-11-30', N'Đồng Nai', N'Học sinh', N'Còn học', 'BL10', 1900000, N'Nam'),
    ('HV11', 'ML11', N'Trần Thị Thu', '2000-08-12', N'Quảng Ngãi', N'Sinh viên', N'Còn học', 'BL11', 2700000, N'Nữ'),
    ('HV12', 'ML12', N'Vũ Đức Tuấn', '1999-04-02', N'Phú Yên', N'Văn phòng', N'Đã học xong', 'BL12', 4200000, N'Nam'),
    ('HV13', 'ML13', N'Phan Thị Ngân', '2001-12-25', N'Bình Phước', N'Học sinh', N'Còn học', 'BL13', 1600000, N'Nữ'),
    ('HV14', 'ML14', N'Nguyễn Văn Hùng', '1998-09-18', N'Đắk Lắk', N'Sinh viên', N'Còn học', 'BL14', 2900000, N'Nam'),
    ('HV15', 'ML15', N'Lê Thị Trang', '2000-06-07', N'Gia Lai', N'Văn phòng', N'Đã học xong', 'BL15', 4300000, N'Nữ'),
    ('HV16', 'ML01', N'Hoàng Thị Tuyết', '2002-02-28', N'Thái Nguyên', N'Học sinh', N'Còn học', 'BL16', 2100000, N'Nữ'),
    ('HV17', 'ML02', N'Nguyễn Văn Hải', '1999-07-15', N'Nam Định', N'Sinh viên', N'Còn học', 'BL17', 2400000, N'Nam'),
    ('HV18', 'ML03', N'Trần Thị Hoa', '2001-04-05', N'Hải Phòng', N'Văn phòng', N'Đã học xong', 'BL18', 3700000, N'Nữ'),
    ('HV19', 'ML04', N'Võ Văn Đạt', '2003-10-20', N'Hưng Yên', N'Học sinh', N'Còn học', 'BL19', 2200000, N'Nam'),
    ('HV20', 'ML05', N'Nguyễn Thị Tâm', '2000-09-28', N'Bắc Ninh', N'Sinh viên', N'Còn học', 'BL20', 3100000, N'Nữ'),
    ('HV21', 'ML06', N'Phạm Đức Anh', '1998-12-07', N'Hà Nam', N'Văn phòng', N'Đã học xong', 'BL21', 4800000, N'Nam'),
    ('HV22', 'ML07', N'Huỳnh Minh Hải', '2003-01-10', N'Thái Bình', N'Học sinh', N'Còn học', 'BL22', 2300000, N'Nam'),
    ('HV23', 'ML08', N'Nguyễn Thị Ngọc', '1999-03-28', N'Hà Tĩnh', N'Sinh viên', N'Còn học', 'BL23', 3300000, N'Nữ'),
    ('HV24', 'ML09', N'Lê Văn Quang', '2001-08-15', N'Quảng Bình', N'Văn phòng', N'Đã học xong', 'BL24', 4600000, N'Nam'),
    ('HV25', 'ML10', N'Trương Thị Hoàng', '2002-10-10', N'Ninh Bình', N'Học sinh', N'Còn học', 'BL25', 2000000, N'Nữ'),
    ('HV26', 'ML11', N'Đỗ Văn Hùng', '2000-05-07', N'Yên Bái', N'Sinh viên', N'Còn học', 'BL26', 3000000, N'Nam'),
    ('HV27', 'ML12', N'Phan Thị Tú', '1998-11-30', N'Lào Cai', N'Văn phòng', N'Đã học xong', 'BL27', 4200000, N'Nữ'),
    ('HV28', 'ML13', N'Nguyễn Văn Thanh', '2001-07-18', N'Sơn La', N'Học sinh', N'Còn học', 'BL28', 2400000, N'Nam'),
    ('HV29', 'ML14', N'Hoàng Thị Hồng', '2000-02-05', N'Tuyên Quang', N'Sinh viên', N'Còn học', 'BL29', 3200000, N'Nữ'),
    ('HV30', 'ML15', N'Nguyễn Thế Anh', '1999-09-22', N'Điện Biên', N'Văn phòng', N'Đã học xong', 'BL30', 4500000, N'Nam');

	-- bảng điểm
	select *from DIEM
	INSERT INTO DIEM (MAHV, MAKH, MALOP, DIEMQT, DIEMGK, DIEMCK, TONGDIEM, XEPLOAI, GHICHU, TINHTRANG)
VALUES
    --('HV01', 'KH01', 'ML01', 8.5, 7.5, 9.0, (8.5 + 7.5 + 9.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV02', 'KH01', 'ML02', 7.0, 6.5, 8.0, (7.0 + 6.5 + 8.0) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV03', 'KH02', 'ML03', 9.5, 8.5, 9.0, (9.5 + 8.5 + 9.0) / 3, N'Giỏi', N'Xuất sắc', 1),
    ('HV04', 'KH02', 'ML01', 6.0, 7.0, 6.5, (6.0 + 7.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV05', 'KH03', 'ML02', 8.0, 8.5, 9.5, (8.0 + 8.5 + 9.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV06', 'KH03', 'ML03', 7.5, 6.0, 7.0, (7.5 + 6.0 + 7.0) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV07', 'KH04', 'ML01', 6.5, 7.5, 8.5, (6.5 + 7.5 + 8.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV08', 'KH04', 'ML02', 9.0, 9.5, 9.0, (9.0 + 9.5 + 9.0) / 3, N'Giỏi', N'Xuất sắc', 1),
    ('HV09', 'KH05', 'ML03', 6.5, 8.0, 7.5, (6.5 + 8.0 + 7.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV10', 'KH05', 'ML01', 8.5, 7.5, 8.0, (8.5 + 7.5 + 8.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV11', 'KH06', 'ML02', 7.0, 6.0, 6.5, (7.0 + 6.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV12', 'KH06', 'ML03', 9.0, 8.0, 7.5, (9.0 + 8.0 + 7.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV13', 'KH07', 'ML01', 5.5, 6.5, 6.0, (5.5 + 6.5 + 6.0) / 3, N'Yếu', N'Cần cải thiện', 0),
    ('HV14', 'KH07', 'ML02', 8.5, 9.0, 8.5, (8.5 + 9.0 + 8.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV15', 'KH08', 'ML03', 7.5, 7.5, 8.0, (7.5 + 7.5 + 8.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV16', 'KH08', 'ML01', 8.0, 8.5, 8.5, (8.0 + 8.5 + 8.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV17', 'KH09', 'ML02', 6.5, 6.0, 6.5, (6.5 + 6.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV18', 'KH09', 'ML03', 9.0, 9.5, 9.0, (9.0 + 9.5 + 9.0) / 3, N'Giỏi', N'Xuất sắc', 1),
    ('HV19', 'KH10', 'ML01', 6.5, 8.0, 7.5, (6.5 + 8.0 + 7.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV20', 'KH10', 'ML02', 8.5, 7.5, 8.0, (8.5 + 7.5 + 8.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV21', 'KH01', 'ML03', 7.0, 6.0, 6.5, (7.0 + 6.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV22', 'KH01', 'ML01', 9.0, 8.0, 7.5, (9.0 + 8.0 + 7.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV23', 'KH02', 'ML02', 5.5, 6.5, 6.0, (5.5 + 6.5 + 6.0) / 3, N'Yếu', N'Cần cải thiện', 0),
    ('HV24', 'KH02', 'ML03', 8.5, 9.0, 8.5, (8.5 + 9.0 + 8.5) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV25', 'KH03', 'ML01', 7.5, 7.5, 8.0, (7.5 + 7.5 + 8.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV26', 'KH03', 'ML02', 8.5, 7.5, 9.0, (8.5 + 7.5 + 9.0) / 3, N'Khá', N'Đạt chuẩn', 1),
    ('HV27', 'KH04', 'ML03', 7.0, 6.0, 6.5, (7.0 + 6.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV28', 'KH04', 'ML01', 9.5, 8.5, 9.0, (9.5 + 8.5 + 9.0) / 3, N'Giỏi', N'Xuất sắc', 1),
    ('HV29', 'KH05', 'ML02', 6.0, 7.0, 6.5, (6.0 + 7.0 + 6.5) / 3, N'Trung bình', N'Cần cải thiện', 0),
    ('HV30', 'KH05', 'ML03', 8.0, 8.5, 9.5, (8.0 + 8.5 + 9.5) / 3, N'Khá', N'Đạt chuẩn', 1);
go

	-- Viết hàm cho bảng PHONGHOC
		-- thêm phonghoc
CREATE PROCEDURE ThemPhongHoc
		@MaPhong CHAR(4),
		@TenPhong NVARCHAR(50),
		@TinhTrang NVARCHAR(50)
	AS
	BEGIN
		SET NOCOUNT ON;

		INSERT INTO PHONGHOC (MAPHONG, TENPHONG, TINHTRANG)
		VALUES (@MaPhong, @TenPhong, @TinhTrang);
    
		-- Trả về giá trị thành công (hoặc có thể điều chỉnh theo ý của bạn)
		RETURN 1;
	END;
	-- thực thi 
		select *from PHONGHOC
		DECLARE @Result INT;
		EXEC @Result = ThemPhongHoc 'PH16', N'Phòng A', N'Đang sử dụng';
		PRINT @Result;
Go
	-- Xóa PHONGHOC
CREATE PROCEDURE XoaPhongHoc
    @MaPhong CHAR(4)
AS
BEGIN
    DELETE FROM PHONGHOC WHERE MAPHONG = @MaPhong;
END;
	-- thực thi
		EXEC XoaPhongHoc @MaPhong = 'PH16';
GO
	-- Sửa phòng học
CREATE PROCEDURE SuaThongTinPhongHoc
	@MaPhong CHAR(4),
	@TenPhong NVARCHAR(50),
	@TinhTrang NVARCHAR(50)
AS
BEGIN
	UPDATE PHONGHOC
	SET TENPHONG = @TenPhong,
	TINHTRANG = @TinhTrang
	WHERE MAPHONG = @MaPhong;
END;
	-- thực thi
	select *from PHONGHOC
	EXEC SuaThongTinPhongHoc @MaPhong = 'PH16', @TenPhong = 'Đang sửa nè', @TinhTrang = 'phong moi toanh';
GO

	-- Viết hàm cho bảng LOPHOC
select *from LOPHOC 
	-- viết trigger kiểm tra cahoc có nằm trong khoảng thứ 2 đến chủ nhật không
CREATE OR ALTER TRIGGER KiemTraCaHoc
ON LOPHOC
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM inserted i

        WHERE i.CAHOC NOT IN (
            'Sáng thứ 2', 'Chiều thứ 2', 'Tối thứ 2',
            'Sáng thứ 3', 'Chiều thứ 3', 'Tối thứ 3',
            'Sáng thứ 4', 'Chiều thứ 4', 'Tối thứ 4',
            'Sáng thứ 5', 'Chiều thứ 5', 'Tối thứ 5',
            'Sáng thứ 6', 'Chiều thứ 6', 'Tối thứ 6',
            'Sáng thứ 7', 'Chiều thứ 7', 'Tối thứ 7',
			'Sáng chủ nhật', 'Chiều chủ nhật', 'Tối chủ nhật'
        )
    )
    BEGIN
        THROW 50000, 'Ca học không hợp lệ. Ca học phải nằm trong khoảng từ sáng thứ 2 đến tối chủ nhật.', 1;
    END;
END;
GO
	-- thêm lớp học
CREATE PROCEDURE ThemLopHoc
    @MALOP CHAR(4),
    @SISO INT,
    @MAPHONG CHAR(4),
    @MAGV CHAR(4),
    @MAKH CHAR(4),
    @CAHOC NVARCHAR(20),
    @NGAYBATDAU DATE,
    @NGAYKETTHUC DATE
AS
BEGIN
    BEGIN TRY
        INSERT INTO LOPHOC (MALOP, SISO, MAPHONG, MAGV, MAKH, CAHOC, NGAYBATDAU, NGAYKETTHUC)
        VALUES (@MALOP, @SISO, @MAPHONG, @MAGV, @MAKH, @CAHOC, @NGAYBATDAU, @NGAYKETTHUC);
    END TRY
    BEGIN CATCH
        THROW;
    END CATCH
END;
	-- thực thi
	EXEC ThemLopHoc
    @MALOP = 'ML20',
    @SISO = 30,
    @MAPHONG = 'PH01',
    @MAGV = 'GV01',
    @MAKH = 'KH01',
    @CAHOC = 'sáng thứ 2',
    @NGAYBATDAU = '2023-08-15',
    @NGAYKETTHUC = '2023-12-15';
GO
	-- xóa lớp học
CREATE OR ALTER PROCEDURE XoaLopHoc
    @MALOP CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Xóa dữ liệu liên quan đến lớp học, ví dụ: Bảng điểm, thời khóa biểu,...
        -- Xóa dữ liệu trong các bảng khác trước khi xóa lớp học để tránh việc xóa bị cản trở bởi ràng buộc khóa ngoại

        -- Xóa lớp học
        DELETE FROM LOPHOC
        WHERE MALOP = @MALOP;

        PRINT N'Xóa lớp học thành công';
    END TRY
    BEGIN CATCH
        PRINT N'Xóa lớp học thất bại. Lỗi: ' + ERROR_MESSAGE();
    END CATCH;
END;
	-- thực thi
	EXEC XoaLopHoc @MALOP = 'ML22';
GO
	-- sửa lớp học
CREATE PROCEDURE SuaLopHoc
    @MALOP CHAR(4),
    @SISO INT,
    @MAPHONG CHAR(4),
    @MAGV CHAR(4),
    @MAKH CHAR(4),
    @CAHOC NVARCHAR(20),
    @NGAYBATDAU DATE,
    @NGAYKETTHUC DATE
AS
BEGIN
    DECLARE @ErrorMessage NVARCHAR(200);
    DECLARE @SuccessMessage NVARCHAR(200);
    DECLARE @Result INT;

    BEGIN TRY
        UPDATE LOPHOC
        SET SISO = @SISO,
            MAPHONG = @MAPHONG,
            MAGV = @MAGV,
            MAKH = @MAKH,
            CAHOC = @CAHOC,
            NGAYBATDAU = @NGAYBATDAU,
            NGAYKETTHUC = @NGAYKETTHUC
        WHERE MALOP = @MALOP;

        SET @SuccessMessage = N'Cập nhật thông tin lớp học thành công.';
    END TRY
    BEGIN CATCH
        SET @Result = 0;
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH;

    SELECT @Result AS Result, 
           CASE WHEN @Result = 1 THEN @SuccessMessage ELSE @ErrorMessage END AS Message;
END;
	-- thực thi
DECLARE @Message NVARCHAR(200);
EXEC SuaLopHoc
    @MALOP = 'ML16',
    @SISO = 40,
    @MAPHONG = 'PH02',
    @MAGV = 'GV02',
    @MAKH = 'KH02',
    @CAHOC = N'Chiều thứ 3',
    @NGAYBATDAU = '2023-08-20',
    @NGAYKETTHUC = '2023-12-20'
GO
	-- thống kê danh sách lớp học
CREATE FUNCTION DanhSachHocVienTheoMaLop (@MaLop CHAR(4))
RETURNS TABLE
AS
RETURN (
    SELECT HV.MAHV, HV.HOTEN, HV.NGAYSINH, HV.DIACHI, HV.NGHENGHIEP, HV.TINHTRANG, HV.SOBIENLAI, HV.HOCPHI, HV.GIOITINH
    FROM HOCVIEN HV
    WHERE HV.MALOP = @MaLop
);

	-- thực thi
	SELECT * FROM DanhSachHocVienTheoMaLop('ML03');
go
	-- tìm kiếm thông tin học viên bằng mã lớp
CREATE FUNCTION TimHocVienTheoMaLop
(
    @MaLop CHAR(4)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HOCVIEN
    WHERE MALOP = @MaLop
);
	-- thực thi
	SELECT * FROM dbo.TimHocVienTheoMaLop('ML02');
go

	-- BẢNG HOCVIEN
-- Thủ tục lưu trữ: Thêm học viên mới
CREATE PROCEDURE ThemHocVien
    @MAHV CHAR(4),
    @MALOP CHAR(4),
    @HOTEN NVARCHAR(50),
    @NGAYSINH DATE,
    @DIACHI NVARCHAR(50),
    @NGHENGHIEP NVARCHAR(50),
    @TINHTRANG NVARCHAR(50),
    @SOBIENLAI CHAR(4),
    @HOCPHI NVARCHAR(10),
    @GIOITINH NVARCHAR(10)
AS
BEGIN
    INSERT INTO HOCVIEN (MAHV, MALOP, HOTEN, NGAYSINH, DIACHI, NGHENGHIEP, TINHTRANG, SOBIENLAI, HOCPHI, GIOITINH)
    VALUES (@MAHV, @MALOP, @HOTEN, @NGAYSINH, @DIACHI, @NGHENGHIEP, @TINHTRANG, @SOBIENLAI, @HOCPHI, @GIOITINH);
END;
	
-- Gọi thủ tục để thêm học viên mới
DECLARE @MAHV_ADD CHAR(4) = 'HV98';
DECLARE @MALOP_ADD CHAR(4) = 'ML01';
DECLARE @HOTEN_ADD NVARCHAR(50) = N'Nguyễn Văn A';
DECLARE @NGAYSINH_ADD DATE = '2000-01-01';
DECLARE @DIACHI_ADD NVARCHAR(50) = N'123 Đường ABC';
DECLARE @NGHENGHIEP_ADD NVARCHAR(50) = N'Sinh viên';
DECLARE @TINHTRANG_ADD NVARCHAR(50) = N'Đang học';
DECLARE @SOBIENLAI_ADD CHAR(4) = 'BL01';
DECLARE @HOCPHI_ADD NVARCHAR(10) = N'1000000';
DECLARE @GIOITINH_ADD NVARCHAR(10) = N'Nam';

EXEC ThemHocVien
    @MAHV_ADD,
    @MALOP_ADD,
    @HOTEN_ADD,
    @NGAYSINH_ADD,
    @DIACHI_ADD,
    @NGHENGHIEP_ADD,
    @TINHTRANG_ADD,
    @SOBIENLAI_ADD,
    @HOCPHI_ADD,
    @GIOITINH_ADD;
select *from HOCVIEN
go
-- Cập nhật thông tin học viên
CREATE PROCEDURE CapNhatHocVien
    @MAHV CHAR(4),
    @HOTEN NVARCHAR(50),
    @NGAYSINH DATE,
    @DIACHI NVARCHAR(50),
    @NGHENGHIEP NVARCHAR(50),
    @TINHTRANG NVARCHAR(50),
    @SOBIENLAI CHAR(4),
    @HOCPHI NVARCHAR(10),
    @GIOITINH NVARCHAR(10)
AS
BEGIN
    UPDATE HOCVIEN
    SET HOTEN = @HOTEN, NGAYSINH = @NGAYSINH, DIACHI = @DIACHI, NGHENGHIEP = @NGHENGHIEP,
        TINHTRANG = @TINHTRANG, SOBIENLAI = @SOBIENLAI, HOCPHI = @HOCPHI, GIOITINH = @GIOITINH
    WHERE MAHV = @MAHV;
END;
	-- Gọi thủ tục để cập nhật thông tin học viên
DECLARE @MAHV_UPDATE CHAR(4) = 'HV01';
DECLARE @HOTEN_UPDATE NVARCHAR(50) = N'Đặng Văn Phương';
DECLARE @NGAYSINH_UPDATE DATE = '2000-02-02';
DECLARE @DIACHI_UPDATE NVARCHAR(50) = N'Hồ Chí Minh';
DECLARE @NGHENGHIEP_UPDATE NVARCHAR(50) = N'Sinh Viên';
DECLARE @TINHTRANG_UPDATE NVARCHAR(50) = N'Còn học';
DECLARE @SOBIENLAI_UPDATE CHAR(4) = 'BL02';
DECLARE @HOCPHI_UPDATE NVARCHAR(10) = N'2500000';
DECLARE @GIOITINH_UPDATE NVARCHAR(10) = N'Nam';

EXEC CapNhatHocVien
    @MAHV_UPDATE,
    @HOTEN_UPDATE,
    @NGAYSINH_UPDATE,
    @DIACHI_UPDATE,
    @NGHENGHIEP_UPDATE,
    @TINHTRANG_UPDATE,
    @SOBIENLAI_UPDATE,
    @HOCPHI_UPDATE,
    @GIOITINH_UPDATE;
	select *from HOCVIEN
	
go
CREATE PROCEDURE XoaHocVienVaDiem
    @MAHV CHAR(4)
AS
BEGIN
    -- Xóa điểm liên quan với học viên
    DELETE FROM DIEM WHERE MAHV = @MAHV;

    -- Xóa học viên
    DELETE FROM HOCVIEN WHERE MAHV = @MAHV;
END;
--  Xóa học viên
CREATE PROCEDURE XoaHocVien
    @MAHV CHAR(4)
AS
BEGIN
    -- Xóa các dòng liên quan trong bảng DIEM trước
    DELETE FROM DIEM WHERE MAHV = @MAHV;

    -- Xóa học viên từ bảng HOCVIEN
    DELETE FROM HOCVIEN WHERE MAHV = @MAHV;
END;
select *from HOCVIEN
-- Gọi thủ tục để xóa học viên
DECLARE @MAHV_DELETE CHAR(4) = 'HV99';
EXEC XoaHocVien
    @MAHV_DELETE;

select *from DIEM
go
	-- Hàm tìm kiếm học viên theo mã học viên
CREATE FUNCTION TimHocVienTheoMaHV
(
    @MaHV CHAR(4)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HOCVIEN
    WHERE MAHV = @MaHV
);
	-- thực thi
SELECT * FROM dbo.TimHocVienTheoMaHV('HV01');
go
	-- tìm kiếm theo tên học viên
CREATE FUNCTION TimKiemHocVienTheoTen
    (@HOTEN NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT HV.MAHV, HV.MALOP, HV.HOTEN, HV.NGAYSINH, HV.DIACHI, HV.NGHENGHIEP, HV.TINHTRANG, HV.SOBIENLAI, HV.HOCPHI, HV.GIOITINH
    FROM HOCVIEN AS HV
    WHERE HV.HOTEN LIKE '%' + @HOTEN + '%'
);
	-- thực thi
SELECT * FROM dbo.TimKiemHocVienTheoTen(N'Đặng Văn Phương');
select *from HOCVIEN
--HOẶC
DECLARE @TENHV NVARCHAR(50);
SET @TENHV = N'Nguyễn Văn';
SELECT * FROM dbo.TimKiemHocVienTheoTen(@TENHV);
-- hàm tìm kiếm học viên theo mã lớp
CREATE FUNCTION TimHocVienTheoLopHV
(
    @MaLOP CHAR(4)
)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HOCVIEN
    WHERE MALOP = @MaLOP
);
-- hàm in biên lai học viên
drop FUNCTION InBienLaiHocVien
CREATE PROCEDURE InBienLaiHocVien
    @MAHV CHAR(4)
AS
BEGIN
    SELECT *
    FROM HOCVIEN
    WHERE MAHV = @MAHV;
END;
EXEC InBienLaiHocVien @MAHV = 'HV01';

	-- BẢNG GIÁO VIÊN
	---them giao vien
CREATE PROCEDURE ThemGiaoVien
    @MAGV CHAR(4),
    @HOTEN NVARCHAR(50),
    @NGAYSINH DATE,
    @DIACHI NVARCHAR(50),
    @DIENTHOAI NVARCHAR(10),
    @TRINHDO NVARCHAR(50),
    @GIOITINH NVARCHAR(10)
AS
BEGIN
    INSERT INTO GIAOVIEN (MAGV, HOTEN, NGAYSINH, DIACHI, DIENTHOAI, TRINHDO, GIOITINH)
    VALUES (@MAGV, @HOTEN, @NGAYSINH, @DIACHI, @DIENTHOAI, @TRINHDO, @GIOITINH);
END;
	--thực thi
EXEC ThemGiaoVien N'GV93', N'Nguyễn Văn A', '1980-01-01', N'Hà Nội', '123456789', N'Tiến sĩ', N'Nam';
select *from GIAOVIEN
go
--xóa giáo viên
CREATE PROCEDURE XoaGiaoVien
    @MAGV CHAR(4)
AS
BEGIN
    DELETE FROM GIAOVIEN
    WHERE MAGV = @MAGV;
END;
	--thực thi
EXEC XoaGiaoVien 'GV93';
select *from GIAOVIEN
go
--sua thông tin
CREATE PROCEDURE SuaThongTinGiaoVien
    @MAGV CHAR(4),
    @HOTEN NVARCHAR(50),
    @NGAYSINH DATE,
    @DIACHI NVARCHAR(50),
    @DIENTHOAI NVARCHAR(10),
    @TRINHDO NVARCHAR(50),
    @GIOITINH NVARCHAR(10)
AS
BEGIN
    UPDATE GIAOVIEN
    SET HOTEN = @HOTEN,
        NGAYSINH = @NGAYSINH,
        DIACHI = @DIACHI,
        DIENTHOAI = @DIENTHOAI,
        TRINHDO = @TRINHDO,
        GIOITINH = @GIOITINH
    WHERE MAGV = @MAGV;
END;
	-- thực thi
EXEC SuaThongTinGiaoVien 'GV93', N'Nguyễn Văn B', '1980-01-01', N'Hồ Chí Minh', '987654321', N'Phó giáo sư', 'Nam';
select *from GIAOVIEN
go

--hàm tìm kiếm thông tin giáo viên bằng mã giáo viên:
CREATE FUNCTION TimKiemGiaoVienTheoMa
    (@MAGV CHAR(4))
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM GIAOVIEN
    WHERE MAGV = @MAGV
);
	--thực thi
SELECT * FROM TimKiemGiaoVienTheoMa('GV15');
go
--hàm tìm kiếm thông tin giáo viên bằng tên giáo viên:
CREATE FUNCTION TimKiemGiaoVienTheoTen
    (@HOTEN NVARCHAR(50))
RETURNS TABLE
AS
RETURN
(
    SELECT GV.MAGV, GV.HOTEN, GV.NGAYSINH, GV.DIACHI, GV.DIENTHOAI, GV.TRINHDO, GV.GIOITINH
    FROM GIAOVIEN AS GV
    WHERE GV.HOTEN LIKE '%' + @HOTEN + '%'
);
-- Thực thi
SELECT * FROM dbo.TimKiemGiaoVienTheoTen(N'Nguyễn Văn');
select *from GIAOVIEN
go

﻿--BẢNG KHOÁ HỌC
select *from KHOAHOC
-- Thêm thông tin khóa học:
CREATE PROCEDURE ThemKhoaHoc
    @MAKH CHAR(4),
    @TENKH NVARCHAR(50),
    @GHICHU NVARCHAR(100)
AS
BEGIN
    INSERT INTO KHOAHOC (MAKH, TENKH, GHICHU)
    VALUES (@MAKH, @TENKH, @GHICHU)
END;

--THỰC THI
-- Thực hiện lệnh thêm thông tin khóa học
DECLARE @MAKH CHAR(4) = 'KH13'
DECLARE @TENKH NVARCHAR(50) = 'Khóa học B'
DECLARE @GHICHU NVARCHAR(100) = 'Khóa học về thiết kế đồ họa'

EXEC ThemKhoaHoc @MAKH, @TENKH, @GHICHU;
go

-- Xóa khóa học theo mã khóa học:
CREATE PROCEDURE XoaKhoaHoc
    @MAKH CHAR(4)
AS
BEGIN
    DELETE FROM KHOAHOC
    WHERE MAKH = @MAKH
END;
	-- Thực hiện lệnh xoá thông tin khóa học
DECLARE @MAKH CHAR(4) = 'KH12'
EXEC XoaKhoaHoc @MAKH;
go 

-- Sửa thông tin khóa học:
CREATE PROCEDURE SuaThongTinKhoaHoc
    @MAKH CHAR(4),
    @TENKH NVARCHAR(50),
    @GHICHU NVARCHAR(100)
AS
BEGIN
    UPDATE KHOAHOC
    SET TENKH = @TENKH, GHICHU = @GHICHU
    WHERE MAKH = @MAKH
END;
	EXEC SuaThongTinKhoaHoc @MAKH, @TENKH, @GHICHU;

-- Thực hiện lệnh sửa thông tin khóa học
DECLARE @MAKH CHAR(4) = 'KH12'
DECLARE @TENKH NVARCHAR(50) = N'Khóa học A - Cập nhật'
DECLARE @GHICHU NVARCHAR(100) = N'Cập nhật thông tin khóa học'
EXEC SuaThongTinKhoaHoc @MAKH, @TENKH, @GHICHU;

-- BẢNG ĐIỂM
select *from DIEM
--Thêm, xóa, sửa thông tin điểm của 1 học viên:
	-- xếp loại điểm
	CREATE FUNCTION PhanLoaiDiem(@TONGDIEM FLOAT)
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @XEPLOAI NVARCHAR(20)

    IF @TONGDIEM >= 8.5
        SET @XEPLOAI = 'Xuất sắc';
    ELSE IF @TONGDIEM >= 7
        SET @XEPLOAI = 'Giỏi';
    ELSE IF @TONGDIEM >= 5.5
        SET @XEPLOAI = 'Khá';
    ELSE IF @TONGDIEM >= 4
        SET @XEPLOAI = 'Trung bình';
    ELSE
        SET @XEPLOAI = 'Yếu';

    RETURN @XEPLOAI;
END;
go

-- Thêm thông tin điểm của một học viên:
CREATE PROCEDURE ThemDiemHocVien
    @MAHV CHAR(4),
    @MAKH CHAR(4),
	@MALOP CHAR(4),
    @DIEMQT FLOAT,
    @DIEMGK FLOAT,
    @DIEMCK FLOAT,
    @TINHTRANG BIT
AS
BEGIN
    DECLARE @TONGDIEM FLOAT;
    DECLARE @XEPLOAI NVARCHAR(20);
    DECLARE @GHICHU NVARCHAR(20);

    SET @TONGDIEM = ROUND((@DIEMQT + @DIEMGK + @DIEMCK) / 3, 1);

    -- Logic để xác định xếp loại dựa trên tổng điểm
	IF @TONGDIEM <= 3.5
		SET @XEPLOAI = N'Yếu';
	ELSE IF @TONGDIEM <= 5
		SET @XEPLOAI = N'Trung bình';
	ELSE IF @TONGDIEM <= 8.5
		SET @XEPLOAI = N'Khá';
	ELSE IF @TONGDIEM <= 10 
		SET @XEPLOAI = N'Giỏi';

    -- Logic để xác định ghi chú dựa trên xếp loại
    IF @XEPLOAI = N'Yếu'
        SET @GHICHU = N'Cần cải thiện';
    ELSE IF @XEPLOAI = N'Trung bình'
        SET @GHICHU = N'Cần cải thiện';
    ELSE IF @XEPLOAI = N'Khá'
        SET @GHICHU = N'Đạt chuẩn';
    ELSE
        SET @GHICHU = N'Xuất sắc';

    -- Thêm điểm vào bảng DIEM
    INSERT INTO DIEM (MAHV, MAKH, MALOP, DIEMQT, DIEMGK, DIEMCK, TONGDIEM, XEPLOAI, GHICHU, TINHTRANG)
    VALUES (@MAHV, @MAKH, @MALOP, @DIEMQT, @DIEMGK, @DIEMCK, @TONGDIEM, @XEPLOAI, @GHICHU, @TINHTRANG);
END;

EXEC ThemDiemHocVien
    @MAHV = 'HV98',
    @MAKH = 'KH01',
	@MALOP = 'ML01',
    @DIEMQT = 7.5,
    @DIEMGK = 8.0,
    @DIEMCK = 9.0,
    @TINHTRANG = 1;
go
-- xóa điểm học viên
-- Xóa thông tin điểm của một học viên:
select *from HOCVIEN
select *from DIEM
select *from LOPHOC
CREATE PROCEDURE XoaDiemHocVien
    @MAHV CHAR(4)
AS
BEGIN
    DELETE FROM DIEM
    WHERE MAHV = @MAHV
END;
	-- thực thi
	-- Thực hiện lệnh xóa thông tin điểm của một học viên
EXEC XoaDiemHocVien 'HV02';
go
-- sửa điểm học viên
CREATE PROCEDURE SuaDiemHocVien
    @MAHV CHAR(4),
    @MAKH CHAR(4),
    @MALOP CHAR(4),
    @DIEMQT FLOAT,
    @DIEMGK FLOAT,
    @DIEMCK FLOAT,
    @TINHTRANG BIT
AS
BEGIN
    DECLARE @TONGDIEM FLOAT;
    DECLARE @XEPLOAI NVARCHAR(20);
    DECLARE @GHICHU NVARCHAR(20);

    SET @TONGDIEM = ROUND((@DIEMQT + @DIEMGK + @DIEMCK) / 3, 1);

    -- Logic để xác định xếp loại dựa trên tổng điểm
    IF @TONGDIEM <= 3.5 and @TONGDIEM < 5
        SET @XEPLOAI = N'Yếu';
    ELSE IF @TONGDIEM >= 5.0 and @TONGDIEM < 6.5 
        SET @XEPLOAI = N'Trung bình';
    ELSE IF @TONGDIEM >= 6.5 and @TONGDIEM < 8.0
        SET @XEPLOAI = N'Khá';
    ELSE IF @TONGDIEM >= 8 and @TONGDIEM <= 10
        SET @XEPLOAI = N'Giỏi';

    -- Logic để xác định ghi chú dựa trên xếp loại
    IF @XEPLOAI = N'Yếu'
        SET @GHICHU = N'Cần cải thiện';
    ELSE IF @XEPLOAI = N'Trung bình'
        SET @GHICHU = N'Cần cải thiện';
    ELSE IF @XEPLOAI = N'Khá'
        SET @GHICHU = N'Đạt chuẩn';
    ELSE
        SET @GHICHU = N'Xuất sắc';

    -- Sửa điểm trong bảng DIEM
    UPDATE DIEM
    SET DIEMQT = @DIEMQT,
        DIEMGK = @DIEMGK,
        DIEMCK = @DIEMCK,
        TONGDIEM = @TONGDIEM,
        XEPLOAI = @XEPLOAI,
        GHICHU = @GHICHU,
        TINHTRANG = @TINHTRANG
    WHERE MAHV = @MAHV AND MAKH = @MAKH AND MALOP = @MALOP;
END;
	-- thực thi
EXEC SuaDiemHocVien
    @MAHV = 'HV99',
    @MAKH = 'KH01',
	@MALOP = 'ML01',
    @DIEMQT = 8.5,
    @DIEMGK = 9.0,
    @DIEMCK = 8.0,
    @TINHTRANG = 1;
go
-- Hàm tìm kiếm học viên đạt chứng chỉ:
CREATE FUNCTION TimKiemHocVienDatChungChi()
RETURNS TABLE
AS
RETURN
    SELECT * FROM DIEM
    WHERE XEPLOAI IN (N'Trung bình', N'Khá', N'Giỏi');
SELECT * FROM TimKiemHocVienDatChungChi();
go

-- Hàm tìm kiếm học viên đã nhận chứng chỉ:
CREATE FUNCTION TimKiemHocVienDaNhanChungChi()
RETURNS TABLE
AS
RETURN
    SELECT * FROM DIEM
    WHERE TINHTRANG = 1;
	-- Thực hiện lệnh tìm kiếm học viên đạt chứng chỉ
	SELECT * FROM TimKiemHocVienDaNhanChungChi();
go

---Hàm tìm kiếm học viên chua nhận chứng chỉ:
CREATE FUNCTION TimKiemHocVienChuaNhanChungChi()
RETURNS TABLE
AS
RETURN
    SELECT * FROM DIEM
    WHERE TINHTRANG = 0;
	-- Thực hiện lệnh tìm kiếm học viên đạt chứng chỉ
	SELECT * FROM TimKiemHocVienChuaNhanChungChi();
go
	
 -- Thống kê danh sách thi lại 
 CREATE PROCEDURE ThongKeDanhSachThiLai
AS
BEGIN
    SELECT MAHV, MAKH, MALOP, DIEMQT, DIEMGK, DIEMCK, TONGDIEM, XEPLOAI, GHICHU, TINHTRANG
    FROM DIEM
    WHERE XEPLOAI = N'Yếu';
END;
EXEC ThongKeDanhSachThiLai;
--tìm kiếm học viên thi lại theo mã lớp 
CREATE FUNCTION TimKiemHocVienThiLaiTheoLop
    (@MALOP CHAR(4))
RETURNS TABLE
AS
RETURN
    SELECT MAHV, MAKH, MALOP, DIEMQT, DIEMGK, DIEMCK, TONGDIEM, XEPLOAI, GHICHU, TINHTRANG
    FROM DIEM
    WHERE XEPLOAI = N'Yếu' AND MALOP = @MALOP;
	-- thực thi
	SELECT * FROM TimKiemHocVienThiLaiTheoLop('ML01');

-- tìm kiếm điểm học viên theo mã học viên
CREATE FUNCTION TimDiemHocVienTheoMaHocVien
(
    @MAHV CHAR(4)
)
RETURNS TABLE
AS
RETURN
    SELECT * FROM DIEM
    WHERE MAHV = @MAHV;

SELECT * FROM TimDiemHocVienTheoMaHocVien('HV30');
-- tìm kiếm điểm theo mã lớp
CREATE FUNCTION TimDiemHocVienTheoLop
(
    @MALOP CHAR(4)
)
RETURNS TABLE
AS
RETURN
    SELECT * FROM DIEM
    WHERE MALOP = @MALOP;
GO
-- thực thi
SELECT * FROM TimDiemHocVienTheoLop('ML01');

-- TẠO TÀI KHOẢN đăng nhập
CREATE LOGIN admin1 WITH PASSWORD = '456';
CREATE LOGIN admin2 WITH PASSWORD = '456';
CREATE LOGIN admin3 WITH PASSWORD = '456';

CREATE LOGIN GV01 WITH PASSWORD = '123';
CREATE LOGIN GV02 WITH PASSWORD = '123';
CREATE LOGIN GV03 WITH PASSWORD = '123';
CREATE LOGIN GV04 WITH PASSWORD = '123';
CREATE LOGIN GV05 WITH PASSWORD = '123';
CREATE LOGIN GV06 WITH PASSWORD = '123';


	-- Tạo người dùng cho admin
CREATE USER admin1User FOR LOGIN admin1;
CREATE USER admin2User FOR LOGIN admin2;
CREATE USER admin3User FOR LOGIN admin3;
	-- cấp quyền
GRANT SELECT, INSERT, UPDATE, DELETE  ON GIAOVIEN TO admin1User;
GRANT SELECT, INSERT, UPDATE, DELETE ON LOPHOC TO admin1User;
GRANT SELECT, INSERT, UPDATE, DELETE ON DIEM TO admin1User;
GRANT SELECT, INSERT, UPDATE, DELETE ON HOCVIEN TO admin1User;
GRANT SELECT, INSERT, UPDATE, DELETE ON KHOAHOC TO admin1User;
GRANT SELECT, INSERT, UPDATE, DELETE ON PHONGHOC TO admin1User;

	-- Tạo người dùng cho giáo viên 
CREATE USER GV01User FOR LOGIN GV01;
		-- cấp quyền
GRANT SELECT ON GIAOVIEN TO GV01User;
GRANT SELECT ON LOPHOC TO GV01User;
GRANT SELECT, INSERT, UPDATE, DELETE ON DIEM TO GV01User;
GRANT SELECT, INSERT, UPDATE, DELETE ON HOCVIEN TO GV01User;










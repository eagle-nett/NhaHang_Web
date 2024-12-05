--USE MASTER
--DROP DATABASE NHAHANG_DOANWEB
CREATE DATABASE NHAHANG_DOANWEB
USE NHAHANG_DOANWEB

CREATE TABLE LOAINHANVIEN
( 
	MALOAINV INT NOT NULL PRIMARY KEY IDENTITY,
	TENLOAINV NVARCHAR(30), 
)

CREATE TABLE NHANVIEN
(
	MANV INT NOT NULL PRIMARY KEY IDENTITY,
	USERNAME VARCHAR(50),
	PASSWORD VARCHAR(50),
	TENNV NVARCHAR(30),
	NGAYSINH DATE,
	DIACHI NVARCHAR(50),
	SDT INT, 
	MALOAINV INT,
	CHUCVU NVARCHAR(50),
	CONSTRAINT FK_NV_LNV FOREIGN KEY (MALOAINV) REFERENCES LOAINHANVIEN(MALOAINV)
)
INSERT INTO NHANVIEN
VALUES
('admin','123456',N'Minh Thư',NULL,NULL,NULL,NULL, NULL)

SELECT * FROM NHANVIEN

CREATE TABLE KHACHHANG
(
	MAKH INT NOT NULL PRIMARY KEY IDENTITY,
	TENKH NVARCHAR(50),
	NGAYSINH DATE,
	DIACHI NVARCHAR(50),
	SDT VARCHAR(20),
	TAIKHOAN VARCHAR(20),
	MATKHAU VARCHAR(20)
)
INSERT INTO KHACHHANG
VALUES 
(N'Minh Thư', '2003-12-09', N'Bình Phước', '0965645127', 'minhthu', 'Thu@0912'),
(N'Thương Nguyên', '2003-01-01', N'Dak Lak', '0866668888', 'nguyen', 'Nguyen@123'),
(N'Hữu Lộc', '2003-02-03', N'TP. Hồ Chí Minh', '0912345678', 'huuloc', 'HuuLoc@123'),
(N'Khắc Huy', '2003-01-12', N'Long An', '0777768688', 'khachuy', 'huy@0123')
SELECT * FROM KHACHHANG





CREATE TABLE BANAN
(
	MABA INT NOT NULL PRIMARY KEY IDENTITY,
	TENBA NVARCHAR(50),
	TRANGTHAI NVARCHAR(50)
)
CREATE TABLE DATBAN
(
	MADATBAN INT NOT NULL PRIMARY KEY IDENTITY,
	MAKH INT,
	MABA INT,
	NGAYDAT DATE,
	GIODAT INT,
	SLKHACH INT,
	CONSTRAINT FK_DATBAN_KHACHHANG FOREIGN KEY (MAKH) REFERENCES KHACHHANG(MAKH),
	CONSTRAINT FK_DATBAN_BANAN FOREIGN KEY (MABA) REFERENCES BANAN(MABA)
)
CREATE TABLE LOAIMONAN
(
	MALOAI INT IDENTITY (1, 1) NOT NULL,
	TENLOAI NVARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED (MALOAI ASC)
)

INSERT INTO LOAIMONAN
VALUES
(N'Điểm tâm sáng'),
(N'Món chính'),
(N'Món rau'),
(N'Món ăn kèm'),
(N'Món canh'),
(N'Món cuốn'),
(N'Món nước');
SELECT * FROM LOAIMONAN

CREATE TABLE MONAN
(
	MAMONAN INT NOT NULL PRIMARY KEY IDENTITY,
	TENMONAN NVARCHAR(50) NULL,
	GIA INT NULL,
	MOTA NVARCHAR(MAX) NULL,
	HINHANH NVARCHAR(100) NULL, 
	MALOAI INT NOT NULL,
	CONSTRAINT FK_MANAN_LOAIMONAN FOREIGN KEY(MALOAI) REFERENCES LOAIMONAN(MALOAI)
)

INSERT INTO MONAN
VALUES 
--Món ăn kèm
(N'Cà pháo mắm tôm', 20000, N'Món ăn kèm thơm ngon ngàn năm của người Việt Nam', 'CA-PHAO.jpg', 4),
(N'Cơm niêu', 30000, N'Gạo Tám, cơm niêu là một đặc sản', 'COM-NIEU.jpg', 4),
(N'Dưa chua', 15000, N'Có vị chua chua ngọt ngọt, thơm lừng, dễ ăn.', 'DUA-CHUA.jpg', 4),
(N'Trứng luộc', 7000, N'Món ăn giản dị, bổ dưỡng.', 'TRUNG-LUOC.jpg', 4),
--Món canh
(N'Canh bầu nấu tôm', 35000, N'Canh ngon với bầu tươi và tôm thơm ngon.', 'CANH-BAU-NAU-TOM.jpg', 5),
(N'Canh cải xanh thịt bằm tôm', 45000, N'Canh cải xanh thơm ngon, gia vị độc đáo.', 'CANH-CAI-XANH-THIT-BAM-TOM-TUOI.jpg', 5),
(N'Canh chua bông lau cá lóc', 50000, N'Canh chua ngon với bông lau và cá lóc tươi ngon.', 'CANH-CHUA-CA-BONG-LAU-CA-LOC.jpg', 5),
(N'Canh chua hải sản', 65000, N'Canh chua hấp dẫn với hải sản tươi ngon.', 'CANH-CHUA-HAI-SAN.jpg', 5),
(N'Canh rau đay mồng tơi', 25000, N'Canh độc đáo với rau đay và mồng tơi thơm ngon.', 'CANH-CUA-RAU-DAY-MONG-TOI.jpg', 5),
(N'Canh gà lá giang', 50000, N'Canh thơm ngon với gà và lá giang tươi.', 'CANH-GA-LA-GIANG.jpg', 5),
(N'Canh khổ qua thác lác', 30000, N'Canh đặc trưng với khổ qua và thác lác.', 'CANH-KHO-QUA-THAC-LAC-TOM-TUOI.jpg', 5),
(N'Canh khoai mỡ thịt bằm tôm', 35000, N'Canh ngon với khoai mỡ, thịt và tôm.', 'CANH-KHOAI-MO-THIT-BAM-TOM-TUOI.jpg', 5),
(N'Canh măng chua cá', 45000, N'Canh măng chua hấp dẫn kết hợp với cá thơm ngon.', 'CANH-MANG-CHUA-NAU-CA.jpg', 5),
(N'Canh nghêu', 55000, N'Canh nghêu ngon và thơm ngon.', 'CANH-NGHEU-THI-LA.jpg', 5),
(N'Canh rau má thịt bằm', 35000, N'Canh rau má thơm ngon với thịt bằm.', 'CANH-RAU-MA-THIT-BAM-TOM-TUOI.jpg', 5),
(N'Canh nghêu rong biển', 75000, N'Canh nghêu hấp dẫn kết hợp với rong biển tươi ngon.', 'CANH-RONG-BIEN-NAU-NGHEU-THIT-BAM.jpg', 5),
(N'Canh sườn non bí xanh', 65000, N'Canh sườn non hấp dẫn với bí xanh tươi mát.', 'CANH-SUON-NON-BI-XANH.jpg', 5),
(N'Canh sườn non cải chua', 55000, N'Canh sườn non đậm đà với cải chua thơm ngon.', 'CANH-SUON-NON-CAI-CHUA.jpg', 5),
(N'Canh sườn non khoai mỡ', 40000, N'Canh sườn non tươi ngon kết hợp với khoai mỡ.', 'CANH-SUON-NON-KHOAI-MON.jpg', 5),
(N'Canh sườn non nấu sầu', 45000, N'Canh sườn non thơm ngon kết hợp với sấu chua ngọt.', 'CANH-SUON-NON-NAU-SAU.jpg', 5),
(N'Canh tần ô thịt bằm', 45000, N'Canh tần ô ngon với thịt bằm và gia vị tinh tế.', 'CANH-TAN-O-THIT-BAM-TOM-TUOI.jpg', 5),
(N'Canh trứng cà chua', 25000, N'Canh trứng độc đáo, tươi ngon với cà chua thơm.', 'CANH-TRUNG-CA-CHUA.jpg', 5),

--Món Chính
(N'Cá bống kho tiêu', 35000, N'Món cá bống kho tiêu thơm ngon và thấm đượi vị tiêu hấp dẫn', 'CA-BONG-KHO-TIEU.jpg', 2),
(N'Cá hú kho tộ', 45000, N'Món cá hú kho tộ thơm ngon, đậm đà vị biển sâu.', 'CA-HU-CA-BONG-LAU-KHO-TO.jpg', 2),
(N'Cá kèo kho tộ', 40000, N'Cá kèo kho tộ với nước sốt đậm đà, thơm ngon đậy sự thích thú.', 'CA-KEO-KHO-TO.jpg', 2),
(N'Cá thác lác chiên mắm sốt cà', 35000, N'Món cá thơm ngon, lớp vỏ giòn với mắm sốt đậm đà.', 'CA-THAC-LAC-CHIEN-MAM-SOT-CA.jpg', 2),
(N'Cá thu sốt cà chua', 30000, N'Cá thu tươi ngon, ngấm đậm vị sốt cà chua thơm ngon.', 'CA-THU-SOT-CA-CHUA.jpg', 2),
(N'Cánh gà chiên giòn', 45000, N'Cánh gà giòn ngon, lớp vỏ ngoài cắt cạnh hấp dẫn.', 'CANH-GA-CHIEN-GION.jpg', 2),
(N'Chân giò giả cầy nấu măng', 50000, N'Món ngon với giò heo giả cầy và măng tươi ngon.', 'CHAN-GIO-GIA-CAY-NAU-MANG.jpg', 2),
(N'Cơm chiên cá mặn', 45000, N'Món cơm hấp dẫn với cá tươi ngon và gia vị đậm hương.', 'COM-CHIEN-CA-MAN.jpg', 2),
(N'Cơm chiên chay', 45000, N'Cơm chiên hương vị độc đáo, hoàn toàn chay.', 'COM-CHIEN-CHAY.jpg', 2),
(N'Cơm chiên hải sản', 50000, N'Cơm chiên tươi ngon với hải sản tươi sáng.', 'COM-CHIEN-HAI-SAN.jpg', 2),
(N'Cơm chiên tỏi trứng', 30000, N'Món cơm chiên thơm béo vị tỏi và trứng gà.', 'COM-CHIEN-TOI-TRUNG.jpg', 2),
(N'Ếch chiên nước mắm', 45000, N'Ếch giòn và thơm lừng với nước mắm.', 'ECH-CHIEN-NUOC-MAM.jpg', 2),
(N'Gà kho', 35000, N'Gà kho ghiền thơm béo và ngon miệng.', 'ga-kho.jpg', 2),
(N'Mực chiên giòn', 60000, N'Mực giòn, hấp dẫn với lớp vỏ giòn.', 'MUC-CHIEN-GION.jpg', 2),
(N'Mực hấp gừng', 55000, N'Mực tươi với hương vị gừng độc đáo.', 'MUC-HAP-GUNG.jpg', 2),
(N'Ốc om chuối đậu', 50000, N' Ốc ngon với sự thơm của chuối đậu.', 'OC-om-CHUOI-DAU.jpg', 2),
(N'Sườn chiên', 45000, N'Sườn non chiên vàng, thơm vị muối sả.', 'SUON-NON-CHIEN-MUOI-SA.jpg', 2),
(N'Sườn rim mặn', 35000, N'Sườn non rim mặn hấp dẫn.', 'SUON-NON-RIM-MAN.jpg', 2),
(N'Sườn xào chua ngọt', 40000, N'Sườn non xào với hương vị chua ngọt độc đáo.', 'SUON-NON-XAO-CHUA-NGOT.jpg', 2),
(N'Thịt ba chỉ cháy cạnh', 35000, N'Thịt ba chỉ thơm ngon, vị cay cạnh đặc trưng.', 'THIT-BA-CHI-CHAY-CANH.jpg', 2),
(N'Thịt ba chỉ luộc', 30000, N'Thịt ba chỉ luộc mềm, thơm ngon với gia vị tinh tế.', 'THIT-BA-CHI-LUOC.jpg', 2),
(N'Thịt kho tàu', 35000, N'Thịt nạc mềm ngon, kho tộ với dừa thơm béo.', 'THIT-KHO-TAU-DUA.jpg', 2),
(N'Thịt rim tiêu', 30000, N'Thịt rim tiêu độc đáo, thơm ngon và kho tộ.', 'THIT-RIM-TIEU-KHO-TO.jpg', 2),
(N'Tôm hấp', 40000, N'Tôm tươi ngon, hấp dẫn.', 'TOM-HAP.jpg', 2),
(N'Tôm kho tộ', 45000, N'Tôm tươi ngon hấp dẫn, kho tộ với gia vị đậm đà.', 'TOM-KHO-TO.jpg', 2),
(N'Tôm rang thịt', 55000, N'Tôm và thịt ba chỉ chiên giòn, hòa quyện vị ngon.', 'TOM-RANG-THIT-BA-CHI.jpg', 2),
(N'Trứng sốt cà chua', 30000, N'Trứng ngon kết hợp với sốt cà thơm béo độc đáo.', 'TRUNG-SOT-CA.jpg', 2),

--Món Cuốn
(N'Bánh phở cuốn', 55000, N'Món ngon mềm mịn, đậy hương vị phở truyền thống.', 'banh-pho-cuon.jpg', 6),
(N'Bún đậu mắm tôm lớn', 100000, N'Sự kết hợp hấp dẫn giữa bún mềm và mắm tôm thơm lừng.', 'bun-dau-mam-tom-lon.jpg', 6),
(N'Bún đậu mắm tôm nhỏ', 75000, N'Một phiên bản nhẹ nhàng, đậy hương vị miền Bắc.', 'bun-dau-thitluoc-nemchua.jpg', 6),
(N'Gỏi cuốn tôm thịt', 45000, N'Sự hòa quyện của tôm và thịt tạo nên món ăn tươi ngon.', 'goi-cuon-tom-thit.jpg', 6),
(N'Cuốn hành', 55000, N'Món nhẹ, giòn ngon, đặc biệt khi chấm nước mắm.', 'mon-cuon-thuy-nguyen.jpg', 6),
(N'Nem cuốn', 80000, N'Lớp bánh giòn kết hợp vị tươi ngon của thực phẩm tươi sống, dẻo ngon và hấp dẫn.', 'nem-cuon.jpg', 6),
(N'Phở cuốn ngũ sắc', 95000, N'Tươi mát, bọc hương thơm với năm màu sắc khác nhau.', 'pho-cuon-ngu-sac.jpg', 6),
(N'Phở chấm', 65000, N'Hương vị phở truyền thống, cuốn lạ mắt.', 'pho-cuon.jpg', 6),

--Món nước
(N'7UP', 15000, N'Đỉnh cao của sự tươi mát.', '7UP.jpg', 7),
(N'Bia Tiger', 25000, N'Mạnh mẽ và phóng khoáng.', 'BIA-2.jpg', 7),
(N'Bia SaiGon', 25000, N'Hương vị Nam Bộ đích thực.', 'BIA-3.jpg', 7),
(N'Bia HeniKen', 25000, N'Thế giới trong một lon.', 'BIA.jpg', 7),
(N'Bò húc', 15000, N'Món ngon thơm ngon đậm đà.', 'BO-HUC.jpg', 7),
(N'Caffee đá', 20000, N'Hương thơm và đá lạnh tươi mát.', 'CAFE-DA.png', 7),
(N'Caffee sữa', 25000, N'Đậm đà và độc đáo.', 'CAFE-SUA.png', 7),
(N'Cam vắt', 25000, N'Tươi mát và ngọt ngon.', 'CAM-VAT.jpg', 7),
(N'CocaCola/Pepsi', 15000, N'Thức tỉnh vị giác.', 'COCAPEPSI.jpg', 7),
(N'Đá me', 32000, N'Ngọt ngào và chua cay.', 'da-me.jpg', 7),
(N'Khăn lạnh', 3000, N'Sạch, mát mẻ.', 'KHAN-LANH.jpg', 7),
(N'Sữa đậu nành', 20000, N'Sức khỏe trong mỗi giọt.', 'nuoc-dau-nanh.jpg', 7),
(N'Nước sấu', 25000, N'Sự thanh khiết đơn giản.', 'nuoc-sau.jpg', 7),
(N'Nước suối', 15000, N'Giải khát tự nhiên.', 'NUOC-SUOI.jpg', 7),
(N'Siting', 15000, N'Đặc sản truyền thống.', 'si-ting.jpeg', 7),
(N'Trà chanh', 25000, N'Hương vị tươi mát.', 'tra-chanh.jpg', 7),
(N'Trà đá', 5000, N'Hương vị truyền thống', 'TRA-DA.jpg', 7),
(N'Trà tắc mật ong sả quế', 25000, N'Hòa quyện độc đáo.', 'tra-tac-mat-ong-sa-que.jpg', 7),
(N'Trà tắc thảo mộc', 30000, N'Sức khỏe tự nhiên.', 'tra-tac-thao-moc.jpg', 7),
(N'Trà tắc xí muội', 15000, N'Hương vị tự do và tươi mát.', 'tra-tac-xi-muoi.jpg', 7),

--Món Rau
(N'Bắp cải luộc', 20000, N'Tươi ngon, giữ nguyên hương vị tự nhiên.', 'BAP-CAI-LUOC.jpg', 3),
(N'Bầu non luộc', 25000, N'Tươi mát, ngon miệng, bắt mắt.', 'BAU-NON-LUOC.jpg', 3),
(N'Bông bí xào tỏi', 35000, N'Hấp dẫn, béo ngon với hương tỏi thơm lừng.', 'BONG-BI-XAO-TOIBO.jpg', 3),
(N'Bông cải xào tỏi', 30000, N'Mềm ngon, cay cay, hấp dẫn vị giác.', 'BONG-CAI-XAO-TOIBO.jpg', 3),
(N'Đậu bắp luộc',20000, N'Tươi ngon, giữ nguyên sự ngọt tự nhiên.', 'DAU-BAP-LUOC.jpg', 3),
(N'Lòng xào mướp', 35000, N'Nhẹ nhàng, ngon miệng, hấp dẫn mùi mướp tươi.', 'GA-HAP-LA-CHANH-LONG-XAO-MUOP.jpg', 3),
(N'Khổ qua xào trứng', 25000, N'Kết hợp độ ngọt của khổ qua và thơm béo của trứng.', 'KHO-QUA-XAO-TRUNG.jpg', 3),
(N'Măng xào tỏi', 40000, N'Giòn ngon, hương vị măng kết hợp với thơm tỏi thơm lừng.', 'MANG-XAO-TOIBO.jpg', 3),
(N'Rau lang luộc', 25000, N'Tươi ngon, giữ nguyên sự tươi mát tự nhiên.', 'RAU-LANG-LUOC.jpg', 3),
(N'Rau luộc thập cẩm kho quẹt', 45000, N'Sự kết hợp độc đáo, hương vị đậm đà.', 'RAU-LUOC-THAP-CAM-KHO-QUET.jpg', 3),
(N'Rau muống luộc', 20000, N'Mềm mịn, hương vị tươi ngon không thể cưỡng lại.', 'RAU-MUONG-LUOC.jpg', 3),
(N'Rau muống xào tỏi', 25000, N'Mùi tỏi thơm lừng kết hợp với vị xanh tươi.', 'RAU-MUONG-XAO-TOIBO.jpg', 3),
(N'Đọt su xào tỏi', 35000, N'Hương vị độc đáo, ngon mắt và bổ dưỡng.', 'SU-SU-XAO-TOIBO.jpg', 3),
(N'Bông thiên lý xào tỏi', 35000, N'Giòn ngon, hấp dẫn vị giác với mùi tỏi thơm.', 'THIEN-LY-XAO-TOIBO.jpg', 3),

--Điểm tâm sáng
(N'Bánh mì chảo', 50000, N'Giòn tan, hương thơm nướng.', 'banh-mi-chao.jpg', 1),
(N'Bò kho', 55000, N'Nồng nàn, đậm đà vị thịt và gia vị.', 'BOKHO.jpg', 1),
(N'Bún bò đặc biệt', 65000, N'Món ngon hấp dẫn, đa dạng nguyên liệu.', 'BUN-BO-DAC-BIET.jpg', 1),
(N'Bún bò thường', 45000, N'Truyền thống, hương vị quen thuộc.', 'BUN-BO.jpg', 1),
(N'Bún thịt nướng', 35000, N'Thơm béo, vị thịt nướng hấp dẫn.', 'bun-thit-nuong.jpg', 1),
(N'Bún trong', 45000, N'Dịu nhẹ, tươi ngon.', 'bun-trong.jpg', 1),
(N'Hủ tiếu nam vang', 55000, N'Hương vị độc đáo, đậm đà.', 'hu-tieu-nam-vang.jpg', 1),
(N'Hủ tiếu trộn', 35000, N'Lạ miệng, hấp dẫn sự kết hợp nguyên liệu.', 'hu-tieu-tron.jpeg', 1),
(N'Mì xào bò', 40000, N'Giòn ngon, hương vị bò và gia vị tuyệt vời.', 'MI-XAO-BO.jpg', 1),
(N'Mì xào hải sản', 35000, N'Hương vị biển ngon ngất ngây, hấp dẫn và đa dạng.', 'MI-XAO-HAI-SAN.jpg', 1),
(N'Miến xào', 35000, N'Miếng xào thơm béo, đậm đà gia vị.', 'mien-xao.jpg', 1),
(N'Nui giò heo', 25000, N'Sự kết hợp ngon miệng giữa nui và giò heo.', 'nui-gio-heo.jpg', 1),
(N'Phở gà', 35000, N'Hương vị đặc trưng, thơm ngon và sáng tạo.', 'pho-ga.jpg', 1),
(N'Rau củ trộn', 25000, N'Sự tươi mát của rau kết hợp với gia vị tạo điểm nhấn.', 'salad-rau-cu.jpg', 1),
(N'Súp gà', 40000, N'Hương thơm và ấm áp của súp gà truyền thống.', 'sup-ga.jpg', 1);

CREATE TABLE DONHANG
(
	MADH INT NOT NULL PRIMARY KEY IDENTITY,
	MAKH INT,
	NGAYDATHANG DATE,
	NGAYGIAOHANG DATE,
	TINHTRANGTHANHTOAN NVARCHAR(50),
	TINHTRANGGIAOHANG INT,
	CONSTRAINT FK_DH_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
)
INSERT INTO DONHANG (MAKH, NGAYDATHANG, NGAYGIAOHANG, TINHTRANGTHANHTOAN, TINHTRANGGIAOHANG)
VALUES
(1, '2023-12-09', '2023-12-15', N'Đã thanh toán', 0),
(2, '2023-12-10', '2023-12-13', N'Đã thanh toán', 0),
(3, '2023-12-09', '2023-12-15', N'Đã thanh toán', 1)


CREATE TABLE CHITIETDONHANG
(
	MADH INT NOT NULL,
	MAMONAN INT NOT NULL,
	SOLUONG INT,
	DONGIA FLOAT,
	CONSTRAINT FK_CTDH_DH FOREIGN KEY(MADH) REFERENCES DONHANG(MADH),
	CONSTRAINT FK_CTDH_MA FOREIGN KEY(MAMONAN) REFERENCES MONAN(MAMONAN),
	CONSTRAINT PK_CHITIETDONHANG PRIMARY KEY (MADH, MAMONAN)
)

INSERT INTO CHITIETDONHANG
VALUES
(1, 1, 3, 60000),
(1, 2, 5, 150000),
(2, 4, 10, 70000),
(2, 10, 1, 50000),
(3, 11, 10, 300000)


CREATE TABLE HOADON
(
	MAHD INT NOT NULL PRIMARY KEY IDENTITY,
	MADH INT,
	MANV INT,
	NGAYTHANHTOAN DATE,
	TONGTIEN INT,
	CONSTRAINT FK_HD_DH FOREIGN KEY(MADH) REFERENCES DONHANG(MADH),
	CONSTRAINT FK_HD_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
)

CREATE TABLE PHANHOI
(
	MAPH INT NOT NULL PRIMARY KEY IDENTITY,
	MAKH INT,
	NOIDUNG NVARCHAR(100),
	NGAYPHANHOI DATE,
	CONSTRAINT FK_PH_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
)
CREATE TABLE DANHGIA
(
	MADG INT NOT NULL PRIMARY KEY IDENTITY,
	MAKH INT,
	NOIDUNG NVARCHAR(100),
	DIEM INT,
	NGAYDANHGIA DATE,
	CONSTRAINT FK_DG_KH FOREIGN KEY(MAKH) REFERENCES KHACHHANG(MAKH)
)

CREATE TABLE CHUCNANG
(
	IDCHUCNANG INT NOT NULL PRIMARY KEY IDENTITY,
	TENCHUCNANG NVARCHAR(100),
	MACHUCNANG NVARCHAR(100)
)


CREATE TABLE PHANQUYEN
(
	MANV INT NOT NULL,
	IDCHUCNANG INT NOT NULL,
	GHICHU NVARCHAR(100)
	CONSTRAINT PK_PQ PRIMARY KEY (MANV, IDCHUCNANG),
	CONSTRAINT FK_PQ_NV FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV),
	CONSTRAINT FK_PQ_CN FOREIGN KEY(IDCHUCNANG) REFERENCES CHUCNANG(IDCHUCNANG)
)

CREATE TABLE NguoiDung
(
	UserId INT NOT NULL PRIMARY KEY IDENTITY, 
	UserName NVARCHAR(40),
	Password CHAR(50),
	EmailAddress CHAR(50),
	Role NVARCHAR(40)
)

INSERT INTO NguoiDung
VALUES
('MinhThu','091203',NULL,NULL)





INSERT INTO BANAN VALUES 
(N'Bàn 01', N'Trống'),
(N'Bàn 02', N'Đang sử dụng'),
(N'Bàn 03', N'Trống'),
(N'Bàn 04', N'Đã được đặt'),
(N'Bàn 05', N'Trống'),
(N'Bàn 06', N'Trống'),
(N'Bàn 07', N'Đang sử dụng'),
(N'Bàn 08', N'Trống'),
(N'Bàn 09', N'Trống'),
(N'Bàn 10', N'Đã được đặt');

INSERT INTO CHUCNANG
VALUES 
(N'NHÂN VIÊN: DANH SÁCH', 'NhanVien_DanhSach'),
(N'NHÂN VIÊN: THÊM MỚI', 'NhanVien_ThemMoi'),
(N'NHÂN VIÊN: CẬP NHẬT', 'NhanVien_CapNhat'),
(N'NHÂN VIÊN: XÓA', 'NhanVien_Xoa')

INSERT INTO PHANQUYEN
VALUES
('1','1',NULL),
('1','2',NULL),
('1','3',NULL)




CREATE PROCEDURE SapXepMenu
    @GiaMin INT = NULL,
    @GiaMax INT = NULL,
    @SapXep NVARCHAR(10)
AS
BEGIN
    SELECT *
    FROM MONAN
    WHERE 
        (@GiaMin IS NULL OR GIA >= @GiaMin) AND
        (@GiaMax IS NULL OR GIA <= @GiaMax)
    ORDER BY
        CASE WHEN @SapXep = 'ASC_MON' THEN TENMONAN END ASC,
        CASE WHEN @SapXep = 'DESC_MON' THEN TENMONAN END DESC,
        CASE WHEN @SapXep = 'ASC_GIA' THEN GIA END ASC,
        CASE WHEN @SapXep = 'DESC_GIA' THEN GIA END DESC;
END

--EXEC SapXepMenu 20000, 100000, 'DESC_MON' 
--EXEC SapXepMenu NULL, NULL, NULL 



CREATE PROCEDURE SP_XemChiTietDonHang
@MADH INT
AS
BEGIN
	SELECT CTDH.MADH, TENKH, SDT, NGAYDATHANG, NGAYGIAOHANG, TINHTRANGTHANHTOAN, TINHTRANGGIAOHANG FROM CHITIETDONHANG CTDH
	JOIN MONAN MA ON CTDH.MAMONAN = MA.MAMONAN
	JOIN DONHANG DH ON DH.MADH = CTDH.MADH
	JOIN KHACHHANG KH ON KH.MAKH = DH.MAKH
WHERE CTDH.MADH = @MADH
END
GO

--EXEC SP_XemChiTietDonHang 1

CREATE PROCEDURE SP_XemChiTietMonAn
@MADH INT
AS
BEGIN
	SELECT TENMONAN, SOLUONG, DONGIA  FROM CHITIETDONHANG CTDH  
	JOIN MONAN MA ON CTDH.MAMONAN = MA.MAMONAN 
	WHERE MADH = @maDH
END
GO

--EXEC SP_XemChiTietMonAn 1
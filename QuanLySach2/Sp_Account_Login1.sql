USE QuanLyNhaSach
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE Sp_Account_Login4
	@MaNV varchar(5),
	@MatKhauNV varchar(24)
AS
BEGIN
	declare @count int
	declare @res bit
	select @count = count(*) from NhanVien where MaNV = @MaNV and MatKhauNV = @MatKhauNV
	if @count > 0
		set @res = 1
	else
		set @res = 0
	select @res
END

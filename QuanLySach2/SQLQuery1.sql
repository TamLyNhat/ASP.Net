DROP Sp_Account_Login PROCEDURE

USE [QuanLyNhaSach]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE Sp_Account_Login1
	@UserName varchar(20),
	@Password varchar(50)
AS
BEGIN
	declare @count int
	declare @res bit
	select @count = count(*) from NhanVien where MaNV = @UserName and MatKhauNV = @Password
	if @count > 0
		set @res = 1
	else
		set @res = 0
	select @res
END

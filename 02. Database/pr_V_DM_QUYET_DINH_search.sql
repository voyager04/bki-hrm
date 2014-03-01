USE [BKI_HRM]
GO
/****** Object:  StoredProcedure [dbo].[pr_V_DM_QUYET_DINH_search]    Script Date: 02/28/2014 23:47:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[pr_V_DM_QUYET_DINH_search]
@STR_SEARCH NVARCHAR(50)
AS
	SELECT * FROM V_DM_QUYET_DINH AS qd
	WHERE 
		(qd.MA_QUYET_DINH LIKE '%'+@STR_SEARCH+'%' or
		qd.TEN LIKE '%'+@STR_SEARCH+'%' OR
		qd.NOI_DUNG LIKE '%'+@STR_SEARCH+'%' OR
		qd.LINK LIKE '%'+@STR_SEARCH +'%'OR
		@STR_SEARCH='')

USE [BKI_HRM]
GO
/****** Object:  StoredProcedure [dbo].[pr_V_DM_QUYET_DINH_Delete]    Script Date: 02/28/2014 03:16:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_V_DM_QUYET_DINH_Delete]
	@ID numeric(18, 0)
AS
DELETE FROM [dbo].[DM_QUYET_DINH]
WHERE
	[ID] = @ID

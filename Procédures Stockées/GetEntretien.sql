USE [Garage]
GO
/****** Object:  StoredProcedure [dbo].[GetEntretien]    Script Date: 30-04-16 13:08:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetEntretien]
@numMoteur int
as begin
	select * from TEntretien
	where numMoteur = @numMoteur
	order by date desc;
end
USE [Garage]
GO
/****** Object:  StoredProcedure [dbo].[GetConsommation]    Script Date: 30-04-16 21:27:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetConsommation]
@numMoteur int
as begin
	select * from TConsommation
	where numMoteur = @numMoteur
	order by numConsommation desc;
end
USE [Garage]
GO
/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 27-04-16 16:43:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetUser]
@login varchar(50), @passwd varchar(50)
as begin 
	select count(*), * from TUtilisateur
	where pseudo = @login and mdp = @passwd;
end
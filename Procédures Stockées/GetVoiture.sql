USE [Garage]
GO
/****** Object:  StoredProcedure [dbo].[GetVoiture]    Script Date: 29-04-16 10:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[GetVoiture]
@pseudo varchar(50)
as begin
	select V.numVoiture, marque, modele, type, couleur, annee, km, carburant, cylindre, puissance, M.numMoteur from TVoiture V
	inner join TUtilisateur U on V.numUtil=U.numUtil
	inner join TDetailMoteur D on D.numVoiture = V.numVoiture
	inner join TMoteur M on M.numMoteur = D.numMoteur
	where pseudo = @pseudo;
end
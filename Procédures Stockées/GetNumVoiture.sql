create procedure GetNumVoiture
@numUtil varchar(50), @marque varchar(50), @modele varchar(50), @type varchar(50), @annee int
as begin
	select numVoiture from TVoiture
	where numUtil = @numUtil and marque = @marque and modele = @modele and type = @type and @annee = annee;
end
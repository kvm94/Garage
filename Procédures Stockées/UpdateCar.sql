create procedure UpdateCar
@id int, @marque varchar(50), @modele varchar(50), @type varchar(50), @couleur varchar(50), @annee int
as begin
	UPDATE TVoiture
	SET marque = @marque, modele = @modele, type = @type, couleur = @couleur, annee = @annee
	WHERE numVoiture = @id;
end
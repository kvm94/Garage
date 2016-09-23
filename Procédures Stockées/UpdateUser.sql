create procedure UpdateUser
@pseudo varchar(50), @nom varchar(50), @prenom varchar(50), @email varchar(50), @mdp varchar(50)
as begin
	UPDATE TUtilisateur
	SET nom = @nom, prenom = @prenom, email = @email, mdp = @mdp
	WHERE pseudo = @pseudo;
end 
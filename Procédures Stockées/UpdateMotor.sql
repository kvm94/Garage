create procedure UpdateMotor
@id int, @carburant varchar(50), @puissance int, @cylindre int
as begin
	UPDATE TMoteur
	SET carburant = @carburant, puissance = @puissance, cylindre = @cylindre
	WHERE numMoteur = @id;
end
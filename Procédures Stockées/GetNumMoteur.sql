create procedure GetNumMoteur
@carburant varchar(50), @cylindre int, @puissance int
as begin
	select numMoteur from TMoteur
	where carburant = @carburant and cylindre = @cylindre and puissance = @puissance;
end
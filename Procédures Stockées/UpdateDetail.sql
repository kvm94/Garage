create procedure UpdateDetail
@numMoteur int, @numVoiture int, @km int
as begin
	UPDATE TDetailMoteur
	SET km = @km
	WHERE @numMoteur = numMoteur and @numVoiture = numVoiture;
end
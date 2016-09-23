create procedure DeleteDetail
@id int
as begin
 delete from TDetailMoteur
 where numVoiture = @id;
 end
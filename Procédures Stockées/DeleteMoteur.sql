create procedure DeleteMotor
@id int
as begin
 delete from TMoteur
 where numMoteur = @id;
 end
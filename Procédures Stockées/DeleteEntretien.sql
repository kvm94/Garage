create procedure DeleteEntretien
@id int
as begin
 delete from TEntretien
 where numEntretient = @id;
 end
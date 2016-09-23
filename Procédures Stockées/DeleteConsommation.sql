create procedure DeleteConsommation
@id int
as begin 
	delete from TConsommation
	where numConsommation = @id;
end
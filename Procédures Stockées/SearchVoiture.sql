create procedure SearchCar
@id int
as begin 
select * from TVoiture
where @id = numVoiture;
end
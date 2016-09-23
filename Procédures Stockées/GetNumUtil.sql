create procedure GetNumUser
@pseudo varchar(50)
as begin
	select numUtil from TUtilisateur
	where pseudo = @pseudo
end
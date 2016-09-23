create procedure SearchUser
@pseudo varchar(50)
as begin
	
	select pseudo from TUtilisateur
	where pseudo = @pseudo;

end
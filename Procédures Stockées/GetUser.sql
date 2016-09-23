create procedure GetUser
@login varchar(50), @passwd varchar(50)
as begin 
	select * from TUtilisateur
	where pseudo = @login and mdp = @passwd;
end
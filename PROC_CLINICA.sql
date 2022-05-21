use clinicaDSII

create proc LISTAR_USUARIOS 
as
	select 
	u.idusuario as Idusuario,
	u.nombre as Nombre,
	u.apellido as Apellido,
	u.dni as Dni,
	u.correo as Correo,
	u.estado as Estado, 
	c.nombre as Cargo
	from usuarios u inner join cargos c on c.idcargo = u.idcargo

EXEC LISTAR_USUARIOS
go

CREATE PROC LISTAR_CARGOS 
AS
	SELECT * FROM cargos
GO

CREATE PROC PROC_STATUS_USERS @estado VARCHAR(50), @idusuario INT
AS
	update usuarios set
		estado = @estado
	where idusuario = @idusuario
GO

select * from usuarios
go

CREATE PROC PROC_INSERTAR_USUARIO 
@nombre VARCHAR(50), @apellido VARCHAR(50), @dni VARCHAR(50), 
@correo VARCHAR(50), @contrasenia VARCHAR(50), @idcargo int
AS

INSERT INTO usuarios values(@nombre, @apellido, @dni, @correo, @contrasenia, 'A' ,@idcargo)
GO
CREATE PROC PROC_ACTUALIZAR_USUARIO 
@nombre VARCHAR(50), @apellido VARCHAR(50), @dni VARCHAR(50), 
@correo VARCHAR(50), @contrasenia VARCHAR(50), @idcargo int, @iduser int
AS
	update usuarios set
		nombre = @nombre, apellido = @apellido, dni = @dni,
		correo = @correo, contrasenia =@contrasenia, idcargo = @idcargo
	where idusuario = @iduser
GO


CREATE PROC OBTENER_USUARIO @iduser int
AS
	SELECT * FROM usuarios where idusuario = @iduser 
go

exec OBTENER_USUARIO 1
go

CREATE PROC ELIMINAR_USUARIO @iduser int
AS
	DELETE FROM usuarios where idusuario = @iduser 
GO
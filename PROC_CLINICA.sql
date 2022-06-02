use clinicaDSII
go

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
GO

EXEC LISTAR_USUARIOS
go

CREATE PROC LISTAR_CARGOS 
AS
	SELECT * FROM cargos
GO

exec LISTAR_CARGOS
go

CREATE PROC PROC_STATUS_USERS @estado VARCHAR(50), @idusuario INT
AS
	update usuarios set
		estado = @estado
	where idusuario = @idusuario
GO

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

-- Horario

CREATE PROC LISTAR_HORARIO 
AS
	SELECT
		idhorario,
		CONVERT(varchar,horainicio,24) as horaInicio , 
		CONVERT(varchar,horafinal,24) as horaFinal 
	FROM horarios
GO

EXEC LISTAR_HORARIO
GO

ALTER PROC OBTENER_HORARIO @idhora int
AS
	SELECT 
		idhorario,
		CONVERT(varchar,horainicio,24) as horaInicio , 
		CONVERT(varchar,horafinal,24) as horaFinal 
	FROM horarios WHERE idhorario=@idhora
GO

EXEC OBTENER_HORARIO 1
go

create proc FILTRO_HORARIO @horainicio VARCHAR(15), @horafinal VARCHAR(15)
as
	select count(*) as Exist from horarios where horainicio = @horainicio or horafinal = @horafinal
go

create proc PROC_INSERTAR_HORARIO @horainicio VARCHAR(15), @horafinal VARCHAR(15)
AS
	insert into horarios values(@horainicio, @horafinal)
GO

create proc PROC_UPDATE_HORARIO @horainicio VARCHAR(15), @horafinal VARCHAR(15), @idhorario int
AS
	UPDATE horarios SET 
	horafinal = @horafinal, horainicio=@horainicio
	where idhorario = @idhorario
GO

create proc PROC_DELETE_HORARIO @idhorario int
AS
	delete from horarios where idhorario = @idhorario
GO

alter proc PROC_OBTENER_MEDICO @dni varchar(15)
as
	declare @exist integer

	select 
		@exist = count(*)
	from especialidadMedico em
	inner join usuarios u on u.idusuario = em.idusuario
	inner join cargos c on c.idcargo = u.idcargo
	where c.nombre = 'doctor' and u.dni = @dni

	IF @exist > 0
		select 
			u.idusuario as idusuario,
			em.idespdoctor as idespmed,
			em.idespecialidad as idespecialidad,
			CONCAT(u.apellido,', ',u.nombre) as medico,
			u.dni as dni,
			u.correo as correo
		from especialidadMedico em
		inner join usuarios u on u.idusuario = em.idusuario
		inner join cargos c on c.idcargo = u.idcargo
		where c.nombre = 'doctor' and u.dni = @dni
	else
		select 
			u.idusuario as idusuario,
			0 as idespmed,
			CONCAT(u.apellido,', ',u.nombre) as medico,
			@exist as idespecialidad,
			u.dni as dni,
			u.correo as correo
		from  usuarios u 
		inner join cargos c on c.idcargo = u.idcargo
		where c.nombre = 'doctor' and u.dni = @dni
go

exec PROC_OBTENER_MEDICO '012345678' 
go

create proc PROC_LISTAR_ESPECIALIDAD 
as
	select * from especialidad
go

create proc PROC_GUARDAR_MED_ESP @idesp int, @idusuario int
as
	insert into especialidadMedico values(@idesp, @idusuario)
go

create proc PROC_ACTUALIZAR_MED_ESP @idesp int, @idusuario int, @idespmed int
as
	update especialidadMedico set
		idespecialidad = @idesp,
		idusuario = @idusuario
	where idespdoctor = @idespmed
go

alter proc PROC_LISTAR_ESPMED 
as
	select 
		concat(u.apellido,', ', u.nombre) as medico,
		u.dni as dni,
		e.nombre as especialidad,
		em.idespdoctor as idespmed
	from especialidadMedico em
	inner join especialidad e on e.idespecialidad = em.idespecialidad
	inner join usuarios u on u.idusuario = em.idusuario
	inner join cargos c on c.idcargo = u.idcargo
	where c.nombre = 'doctor'
go

alter proc PROC_BUSCAR_ESPMED @dni varchar(15)
AS
	select 
		concat(u.apellido,', ', u.nombre) as medico,
		u.dni as dni,
		e.nombre as especialidad,
		em.idespdoctor as idespmed
	from especialidadMedico em
	inner join especialidad e on e.idespecialidad = em.idespecialidad
	inner join usuarios u on u.idusuario = em.idusuario
	inner join cargos c on c.idcargo = u.idcargo
	WHERE u.dni like '%'+@dni+'%' and c.nombre = 'doctor'
GO

create proc PROC_ELIMINAR_MED_ESP @idespmed int
as
	delete from especialidadMedico where idespdoctor = @idespmed
go
select * from usuarios
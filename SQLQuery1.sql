create database clinicaDSII
go

use clinicaDSII
go

create table cargos (
idcargo int identity(1,1) primary key,
nombre varchar(50)
)
go

create table usuarios (
idusuario int identity primary key,
nombre varchar(50),
apellido varchar(50),
dni varchar(15),
correo varchar(50),
contrasenia varchar(50),
estado varchar(50),
idcargo int references cargos(idcargo)
)
go

create table especialidad(
idespecialidad int identity(1,1) primary key,
nombre varchar(50)
)
go

create table horarios(
idhorario int identity(1,1) primary key,
horainicio time,
horafinal time
)

create table especialidadMedico(
idespdoctor int identity(1,1) primary key,
idespecialidad int references especialidad(idespecialidad),
idusuario int references usuarios(idusuario)
)

create table pacientes (
idpacientes int identity(1,1) primary key,
nombre varchar(50),
apellido varchar(50),
dni varchar(15),
correo varchar(50),
fechanacimiento date,
estadocivil varchar(50)
)
go

/*
	consulta
		-idconsulta
		-idmedico
		-idespecialidad
		-idhorario
		-precio
*/
create table consultas(
idconsulta int identity(1,1) primary key,
idmedico int references usuarios(idusuario),
idespecialidad int references especialidad(idespecialidad),
idhorario int references horarios(idhorario),
precio decimal(8,2)
)
go

/*
	reserva
		-idreserva
		-idpaciente
		-idconsulta
		-fechareserva
		-fechacita
		-estado //pagado-pendiente
*/
create table reservas (
idreserva int identity(1,1) primary key,
idpaciente int references pacientes(idpacientes),
idconsulta int references consultas(idconsulta),
fechareserva date,
fechacita date,
estado varchar(150)
)
/*
	FichaMedica
		-idfichamedica
		-idreserva
		-edad
		-fecha // dia de registro
		-alergia // si-no
		-peso //kg
		-estatura //mtrs
*/
create table fichamedicas (
idfichamedica int identity(1,1) primary key,
idreserva int references reservas(idreserva),
fecharegistro date,
alergia varchar(15),
peso decimal(5,2),
estatura decimal(3,2)
)
/*
	HistorialMedico
		-idhistorial
		-idfichamedica
		-observacion
		-receta
		-fecha
*/
create table historialmedicos (
idhistorial int identity(1,1) primary key,
idfichamedica int references fichamedicas(idfichamedica),
observacion text,
receta text,
fecha datetime
)


create table citamedica (
idcitamedica int identity(1,1) primary key,
idpaciente int references pacientes(idpacientes),
idhorario int references horarios(idhorario),
idespdoctor int references especialidadDoctor(idespdoctor),
fechacita date,
estado varchar(50), -- PAGADO/PENDIENTE
peso decimal(5,2),
talla decimal(4,2),
alergiamedicamento varchar(20)--agregar una columna mas (observacion)
)
go

create table historialMedico(
idhistMe int identity(1,1) primary key,
idcitamedica int references citamedica(idcitamedica),
observacion varchar(450)
)

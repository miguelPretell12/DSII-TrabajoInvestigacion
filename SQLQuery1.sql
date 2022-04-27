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

create table especialidadDoctor(
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
fechanacimiento date
)
go

create table citamedica (
idcitamedica int identity(1,1) primary key,
idpaciente int references pacientes(idpacientes),
idhorario int references horarios(idhorario),
idespdoctor int references especialidadDoctor(idespdoctor),
fechacita date,
estado varchar(50), -- Reserva / en curso/ no asistio  / concluido
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

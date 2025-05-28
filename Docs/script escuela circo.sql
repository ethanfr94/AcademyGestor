create database if not exists escuela_circo;
use escuela_circo;

create table if not exists usuarios(
id int primary key auto_increment,
user varchar(50) not null,
pass text not null,
rol enum("admin","user")
);

create table if not exists tipos(
id int primary key auto_increment,
nombre varchar(50) not null,
precio decimal(5.2) not null
);

create table if not exists cursos(
id int primary key auto_increment,
codCurso varchar(5) not null,
nombre varchar(50) not null,
descripcion text,
horario text not null,
tipo int not null,
activo tinyint not null default 1,
constraint fk_cursos_tipos foreign key(tipo) references tipos(id)
);

create table if not exists empresa(
id int primary key auto_increment,
nombre varchar(50) not null,
razon_fiscal varchar(50) not null,
cif varchar(9) not null unique,
email varchar(100) not null unique,
telefono varchar(9) not null,
direccion varchar(100) not null,
localidad varchar(50) not null,
provincia varchar(50) not null,
cp varchar(5) not null
);

create table if not exists tutores(
id int primary key auto_increment,
nombre varchar(50) not null,
apellido1 varchar(50) not null,
apellido2 varchar(50) not null,
email varchar(100) not null unique,
dni varchar(9) not null unique,
direccion varchar(100) not null,
localidad varchar(50) not null,
telefono varchar(9) not null
);

create table if not exists alumnos(
id int primary key auto_increment,
nombre varchar(50) not null,
apellido1 varchar(50) not null,
apellido2 varchar(50) not null,
dni varchar(9) not null unique,
fecha_nac date not null,
direccion varchar(100) not null,
localidad varchar(50) not null,
email varchar(100) not null unique,
telefono varchar(9),
tutor int,
proteccion_datos tinyint not null default 0,
grupo_whatsapp tinyint not null default 0,
comunicaciones_comerciales tinyint not null default 0,
constraint fk_alumnos_tutores foreign key (tutor) references tutores(id)
);

create table if not exists profesores(
id int primary key auto_increment,
nombre varchar(50) not null,
apellido1 varchar(50) not null,
apellido2 varchar(50) not null,
email varchar(100) not null unique,
dni varchar(9) not null unique,
direccion varchar(100) not null,
localidad varchar(50) not null,
telefono varchar(9) not null,
activo tinyint not null default 1
);

create table if not exists profesor_curso(
id int primary key auto_increment,
profesor int not null,
curso int not null,
coordinador tinyint not null default 0,
constraint fk_profesor_curso foreign key (profesor) references cursos(id),
constraint fk_curso_profesor foreign key (curso) references profesores(id)
);

create table if not exists solicitudes(
id int primary key auto_increment,
fecha datetime not null default now(),
curso int not null,
nombre varchar(50) not null,
apellido1 varchar(50) not null,
apellido2 varchar(50) not null,
dni varchar(9) not null unique,
fecha_nac date not null,
direccion varchar(100) not null,
localidad varchar(50) not null,
email varchar(100) not null unique,
telefono varchar(9),
tutor int,
proteccion_datos tinyint not null default 0,
autorizacion_fotos tinyint not null default 0,
grupo_whatsapp tinyint not null default 0,
comunicaciones_comerciales tinyint not null default 0,
beca tinyint not null default 0,
constraint fk_solicitudes_tutor foreign key (tutor) references tutores(id),
constraint fk_solicitudes_curso foreign key (curso) references cursos(id)
);

create table if not exists matriculas(
id int primary key auto_increment,
alumno int not null,
curso int not null,
fech_alta date not null,
fech_baja date default null,
autorizacion_fotos tinyint not null default 0,
beca tinyint not null default 0,
constraint fk_matriculas_alumno foreign key (alumno) references alumnos(id),
constraint fk_matriculas_curso foreign key (curso) references cursos(id)
);

create table if not exists recibos(
id int primary key auto_increment,
matricula int not null,
detalle varchar(100) not null,
fecha date not null,
importe decimal not null,
descuento tinyint not null default 0,
pagado tinyint not null default 0,
constraint fk_recibos_matriculas foreign key (matricula) references matriculas(id)
);

create table if not exists faltas_asistencia(
id int primary key auto_increment,
fecha date not null,
alumno int not null,
curso int not null,
constraint fk_faltas_alumno foreign key (alumno) references alumnos(id),
constraint fk_faltas_curso foreign key (curso) references cursos(id)
);

create table if not exists publicaciones(
id int primary key auto_increment,
timestamp datetime not null default now(),
tipo enum("texto", "foto", "video"),
url text,
titulo varchar (150),
descripcion text,
profesor int not null,
constraint fk_publicaciones_profesor foreign key (profesor) references profesores(id)
);


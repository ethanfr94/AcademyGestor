-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 192.168.1.146    Database: escuela_circo
-- ------------------------------------------------------
-- Server version	8.0.42-0ubuntu0.24.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alumnos`
--

DROP TABLE IF EXISTS `alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumnos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido1` varchar(50) NOT NULL,
  `apellido2` varchar(50) NOT NULL,
  `dni` varchar(9) NOT NULL,
  `fecha_nac` date NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefono` varchar(9) DEFAULT NULL,
  `tutor` int DEFAULT NULL,
  `proteccion_datos` tinyint NOT NULL DEFAULT '0',
  `grupo_whatsapp` tinyint NOT NULL DEFAULT '0',
  `comunicaciones_comerciales` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email` (`email`),
  KEY `fk_alumnos_tutores` (`tutor`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnos`
--

LOCK TABLES `alumnos` WRITE;
/*!40000 ALTER TABLE `alumnos` DISABLE KEYS */;
INSERT INTO `alumnos` VALUES (1,'Valeria','Molina','Peña','485475896','2021-12-01','Calle H','Madrid','valeria@circo.com','630000010',6,1,1,1),(2,'Lucas','Rodríguez','Luna','222222222','2015-05-10','Calle A','Madriddfghdfghdfg','lucas@circo.com','630000001',3,1,1,1),(3,'Sofía','Rodríguez','Luna','A2222222B','2000-03-20','Calle A','Madrid','sofia@circo.com','630000002',NULL,1,1,0),(4,'Álvaro','Morales','Gil','A3333333C','2019-11-15','Calle B','Madrid','alvaro@circo.com','630000003',2,1,0,1),(5,'Marta','Hidalgo','Sanz','A4444444D','2013-08-01','Calle C','Madrid','marta@circo.com','630000004',3,1,1,1),(6,'Daniel','Hidalgo','Sanz','A5555555E','2002-01-10','Calle C','dsfhsdfhsdfh','daniel@circo.com','630000005',NULL,1,1,1),(7,'Lucía','Gómez','Vega','A6666666F','2005-09-25','Calle D','Madrid','lucia@circo.com','630000006',NULL,1,1,0),(8,'Javier','Ruiz','Navarro','A7777777G','2004-07-18','Calle E','Madrid','javier@circo.com','630000007',NULL,1,0,1),(9,'Natalia','Fernández','Ortega','A8888888H','2007-06-30','Calle F','Madrid','natalia@circo.com','630000008',2,1,1,1),(10,'Hugo','Torres','Castro','L9999999Ñ','2021-02-12','Calle G','Madrid','hugo@circo.com','630000009',1,1,1,0),(50,'ouyg','ouyg','ouyg','pioug','2000-04-24','lkhjg','lkjg','lug','',NULL,1,0,0),(51,'pome','iuoytf','efd','3254','2000-04-24','sedfg','sfd','saf','',NULL,1,0,0),(52,'lyujg','ouyig','poiuyg','354854634','2025-04-24','ljhv','ljhkvb','ñljkhbv','',1,1,0,0),(54,'Maximiliano','dsfg','df','666666666','2020-10-15','df','dfahg','dsfh','sdfh',NULL,1,0,0);
/*!40000 ALTER TABLE `alumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cursos`
--

DROP TABLE IF EXISTS `cursos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cursos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `cod_curso` varchar(5) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `descripcion` text,
  `horario` text NOT NULL,
  `tipo` int NOT NULL,
  `activo` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  KEY `fk_cursos_tipos` (`tipo`),
  CONSTRAINT `fk_cursos_tipos` FOREIGN KEY (`tipo`) REFERENCES `tipos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cursos`
--

LOCK TABLES `cursos` WRITE;
/*!40000 ALTER TABLE `cursos` DISABLE KEYS */;
INSERT INTO `cursos` VALUES (1,'PQC','PequeCirco','Curso regular para niños de 6 a 9 años','Lunes 16-17 / Miercoles 16-17',1,1),(2,'INF1','Infantil 1','Curso regular para niños de 10 a 12 años','Lunes 17-18 / Miercoles 17-18',1,1),(3,'INF2','Infantil 2','Curso regular para niños de 10 a 12 años','Martes 16-17 / Jueves 16-17',1,1),(4,'INF3','Infantil 3','Curso regular para niños de 10 a 12 años','Martes 17-18 / Jueves 17-18',1,1),(5,'JOV','Jovenes','Curso regular para jovenes de 12 a 16 años','Viernes 18-20',1,1),(6,'ADL','Adultos','Curso regular para adultos de 16 a 50 años','Lunes 18-19 / Miercoles 18-19 / Viernes 18-19',1,1),(7,'CSN','Circo Senior','Curso regular para adultos de mas de 50 años','Viernes 17-18',1,1),(8,'CLN','Taller monografico de Clown','Monográfico creativo Clown','Sabado 10-13 / Domingo 10-13',2,1),(9,'MLB','Taller monografico de Malabares','Monografico de malabares','Sabado 10-13 / Domingo 10-13',2,1),(10,'ACR','Taller monografico de Adcrobacias','Monográfico Acrobacias de suelo','Sabado 10-13 / Domingo 10-13',2,1),(11,'AER','Taller monografico de aereos','Monografico Aereos','Sabado 10-13 / Domingo 10-13',2,1),(12,'EQU','Taller monografico de equilibrios','Monografico Equilibrios','Sabado 10-13 / Domingo 10-13',2,0);
/*!40000 ALTER TABLE `cursos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empresa` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `razon_fiscal` varchar(50) NOT NULL,
  `cif` varchar(9) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefono` varchar(9) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `provincia` varchar(50) NOT NULL,
  `cp` varchar(5) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `cif` (`cif`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (1,'sdfh','sdfh','shf','sdfh','sdfh','sdfh','sdfh','sdfh','sdf');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faltas_asistencia`
--

DROP TABLE IF EXISTS `faltas_asistencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `faltas_asistencia` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `alumno` int NOT NULL,
  `curso` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_faltas_alumno` (`alumno`),
  KEY `fk_faltas_curso` (`curso`),
  CONSTRAINT `fk_faltas_alumno` FOREIGN KEY (`alumno`) REFERENCES `alumnos` (`id`),
  CONSTRAINT `fk_faltas_curso` FOREIGN KEY (`curso`) REFERENCES `cursos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faltas_asistencia`
--

LOCK TABLES `faltas_asistencia` WRITE;
/*!40000 ALTER TABLE `faltas_asistencia` DISABLE KEYS */;
INSERT INTO `faltas_asistencia` VALUES (1,'2025-04-02',1,1);
/*!40000 ALTER TABLE `faltas_asistencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `matriculas`
--

DROP TABLE IF EXISTS `matriculas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `matriculas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `alumno` int NOT NULL,
  `curso` int NOT NULL,
  `fech_alta` date NOT NULL,
  `fech_baja` date DEFAULT NULL,
  `autorizacion_fotos` tinyint NOT NULL DEFAULT '0',
  `beca` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_matriculas_alumno` (`alumno`),
  KEY `fk_matriculas_curso` (`curso`),
  CONSTRAINT `fk_matriculas_alumno` FOREIGN KEY (`alumno`) REFERENCES `alumnos` (`id`),
  CONSTRAINT `fk_matriculas_curso` FOREIGN KEY (`curso`) REFERENCES `cursos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `matriculas`
--

LOCK TABLES `matriculas` WRITE;
/*!40000 ALTER TABLE `matriculas` DISABLE KEYS */;
INSERT INTO `matriculas` VALUES (1,1,1,'2025-01-10','2025-05-13',1,1),(2,2,1,'2025-01-10',NULL,1,0),(3,3,2,'2025-01-11',NULL,1,0),(4,4,6,'2025-02-01','2025-02-03',0,1),(5,5,6,'2025-02-01','2025-02-03',1,0),(6,6,4,'2025-01-12',NULL,1,1),(7,7,5,'2025-01-13','2025-05-13',0,0),(8,8,8,'2025-03-01','2025-03-05',1,0),(9,9,9,'2025-03-02','2025-03-04',1,1),(10,10,3,'2025-01-14',NULL,1,1),(11,1,10,'2025-03-10','2025-03-12',0,0),(12,3,7,'2025-02-15','2025-02-16',1,1),(13,6,3,'2025-01-16','2025-05-14',1,0),(14,7,8,'2025-03-01','2025-03-03',0,1),(15,8,5,'2025-01-18',NULL,1,1),(16,1,7,'2025-02-04','2025-02-06',0,0),(19,54,2,'2025-05-14',NULL,0,0),(20,54,2,'2025-05-14',NULL,0,0),(21,54,2,'2025-05-14','2025-05-14',0,0);
/*!40000 ALTER TABLE `matriculas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesor_curso`
--

DROP TABLE IF EXISTS `profesor_curso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesor_curso` (
  `id` int NOT NULL AUTO_INCREMENT,
  `profesor` int NOT NULL,
  `curso` int NOT NULL,
  `coordinador` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_profesor_curso` (`curso`),
  KEY `fk_curso_profesor` (`profesor`),
  CONSTRAINT `fk_curso_profesor` FOREIGN KEY (`profesor`) REFERENCES `profesores` (`id`),
  CONSTRAINT `fk_profesor_curso` FOREIGN KEY (`curso`) REFERENCES `cursos` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesor_curso`
--

LOCK TABLES `profesor_curso` WRITE;
/*!40000 ALTER TABLE `profesor_curso` DISABLE KEYS */;
INSERT INTO `profesor_curso` VALUES (17,1,1,0),(22,4,1,0),(23,2,1,0);
/*!40000 ALTER TABLE `profesor_curso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `profesores`
--

DROP TABLE IF EXISTS `profesores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `profesores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido1` varchar(50) NOT NULL,
  `apellido2` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `dni` varchar(9) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `telefono` varchar(9) NOT NULL,
  `activo` tinyint NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `profesores`
--

LOCK TABLES `profesores` WRITE;
/*!40000 ALTER TABLE `profesores` DISABLE KEYS */;
INSERT INTO `profesores` VALUES (1,'Laura','González','Martínez','laura@circo.com','P1234567A','Calle Profe 1','Madrid','611000001',1),(2,'Miguel','Santos','Ruiz','miguel@circo.com','P2345678B','Calle Profe 2','Madrid','611000002',1),(3,'Sara','López','Fernández','sara@circo.com','P3456789C','Calle Profe 3','Madrid','611000003',1),(4,'David','Jiménez','Torres','david@circo.com','P4567890D','Calle Profe 4','Madrid','611000004',1),(5,'Elena','Vega','Romero','elena@circo.com','P5678901E','Calle Profe 5','Madrid','611000005',1);
/*!40000 ALTER TABLE `profesores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publicaciones`
--

DROP TABLE IF EXISTS `publicaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publicaciones` (
  `id` int NOT NULL AUTO_INCREMENT,
  `timestamp` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `tipo` enum('texto','foto') DEFAULT NULL,
  `url` text,
  `titulo` varchar(150) DEFAULT NULL,
  `descripcion` text,
  `profesor` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_publicaciones_profesor` (`profesor`),
  CONSTRAINT `fk_publicaciones_profesor` FOREIGN KEY (`profesor`) REFERENCES `profesores` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publicaciones`
--

LOCK TABLES `publicaciones` WRITE;
/*!40000 ALTER TABLE `publicaciones` DISABLE KEYS */;
INSERT INTO `publicaciones` VALUES (3,'2025-02-25 00:00:00','texto','asdfh','eryeryaryaeryae','HOLi',1);
/*!40000 ALTER TABLE `publicaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recibos`
--

DROP TABLE IF EXISTS `recibos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recibos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `matricula` int NOT NULL,
  `detalle` varchar(100) NOT NULL,
  `fecha` date NOT NULL,
  `importe` decimal(10,0) NOT NULL,
  `descuento` tinyint NOT NULL DEFAULT '0',
  `pagado` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_recibos_matriculas` (`matricula`),
  CONSTRAINT `fk_recibos_matriculas` FOREIGN KEY (`matricula`) REFERENCES `matriculas` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recibos`
--

LOCK TABLES `recibos` WRITE;
/*!40000 ALTER TABLE `recibos` DISABLE KEYS */;
INSERT INTO `recibos` VALUES (1,1,'fdsah','2025-01-01',152,0,0);
/*!40000 ALTER TABLE `recibos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `solicitudes`
--

DROP TABLE IF EXISTS `solicitudes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `solicitudes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `curso` int NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `apellido1` varchar(50) NOT NULL,
  `apellido2` varchar(50) NOT NULL,
  `dni` varchar(9) NOT NULL,
  `fecha_nac` date NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `telefono` varchar(9) DEFAULT NULL,
  `tutor` int DEFAULT NULL,
  `proteccion_datos` tinyint NOT NULL DEFAULT '0',
  `autorizacion_fotos` tinyint NOT NULL DEFAULT '0',
  `grupo_whatsapp` tinyint NOT NULL DEFAULT '0',
  `comunicaciones_comerciales` tinyint NOT NULL DEFAULT '0',
  `beca` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `email` (`email`),
  KEY `fk_solicitudes_tutor` (`tutor`),
  KEY `fk_solicitudes_curso` (`curso`),
  CONSTRAINT `fk_solicitudes_curso` FOREIGN KEY (`curso`) REFERENCES `cursos` (`id`),
  CONSTRAINT `fk_solicitudes_tutor` FOREIGN KEY (`tutor`) REFERENCES `tutores` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `solicitudes`
--

LOCK TABLES `solicitudes` WRITE;
/*!40000 ALTER TABLE `solicitudes` DISABLE KEYS */;
INSERT INTO `solicitudes` VALUES (3,'2025-01-15 00:00:00',2,'Maximiliano','dsfg','df','666666666','2020-10-15','df','dfahg','dsfh','sdfh',1,1,0,0,0,0);
/*!40000 ALTER TABLE `solicitudes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipos`
--

DROP TABLE IF EXISTS `tipos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `precio` decimal(5,0) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipos`
--

LOCK TABLES `tipos` WRITE;
/*!40000 ALTER TABLE `tipos` DISABLE KEYS */;
INSERT INTO `tipos` VALUES (1,'Regular',25),(2,'Monográfico',40);
/*!40000 ALTER TABLE `tipos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tutores`
--

DROP TABLE IF EXISTS `tutores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tutores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido1` varchar(50) NOT NULL,
  `apellido2` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `dni` varchar(9) NOT NULL,
  `direccion` varchar(100) NOT NULL,
  `localidad` varchar(50) NOT NULL,
  `telefono` varchar(9) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `dni` (`dni`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tutores`
--

LOCK TABLES `tutores` WRITE;
/*!40000 ALTER TABLE `tutores` DISABLE KEYS */;
INSERT INTO `tutores` VALUES (1,'Carmen','Rodríguez','Luna','carmen@correo.com','T1111111A','Calle Tutor 1','Madrid','620000001'),(2,'Andrés','Morales','Gil','andres@correo.com','72153424d','Calle Tutor 2','Madrid','620000002'),(3,'Rosa','Hidalgo','Sanz','rosa@correo.com','T3333333C','Calle Tutor 3','Madrid','620000003'),(4,'ssadgasdfgagadfgdgdfga','saf','sdg','sdsd','sdgsadg','sdag','sdsdgsd','asdg');
/*!40000 ALTER TABLE `tutores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user` varchar(50) NOT NULL,
  `pass` text NOT NULL,
  `rol` enum('admin','user') DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'root','root','admin');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-14 18:57:58

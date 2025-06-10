package com.example.academygestormobile.Models

import java.time.LocalDate
import java.time.LocalDateTime
import java.util.Date

data class Solicitud(
    val id: Int? = null,
    val fecha: LocalDateTime? = null,
    val curso: Curso,
    val nombre: String,
    val apellido1: String,
    val apellido2: String,
    val dni: String,
    val fechaNac: String? = null,
    val direccion: String,
    val localidad: String,
    val email: String,
    val telefono: String,
    val tutor: Tutor? = null,
    val proteccionDatos: Byte,
    val autorizacionFotos: Byte,
    val grupoWhatsapp: Byte,
    val comunicacionesComerciales: Byte,
    val beca: Byte
)

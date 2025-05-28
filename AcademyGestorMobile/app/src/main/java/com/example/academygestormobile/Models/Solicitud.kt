package com.example.academygestormobile.Models

import java.util.Date

data class Solicitud(
    val id: Int,
    val fecha: Date,
    val curso: Curso,
    val nombre: String,
    val apellido1: String,
    val apellido2: String,
    val dni: String,
    val fechaNac: Date,
    val direccion: String,
    val localidad: String,
    val email: String,
    val telefono: String,
    val tutor: Tutor,
    val proteccionDatos: Byte,
    val autorizacionFotos: Byte,
    val grupoWhatsapp: Byte,
    val comunicacionesComerciales: Byte,
    val beca: Byte
)

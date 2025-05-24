package com.example.academygestormobile.Models

import java.util.Date

data class Alumno(
    val id: Int?,
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
    val grupoWhatsApp: Byte,
    val comunicacionesComerciales: Byte,

    )

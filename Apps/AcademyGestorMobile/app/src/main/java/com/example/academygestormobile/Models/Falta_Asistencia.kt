package com.example.academygestormobile.Models

import java.time.LocalDate
import java.util.Date

data class Falta_Asistencia(
    val id: Int?,
    val alumno: Alumno,
    val curso: Curso,
    val fecha: LocalDate?
)

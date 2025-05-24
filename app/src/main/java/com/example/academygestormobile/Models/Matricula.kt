package com.example.academygestormobile.Models

import java.util.Date

data class Matricula(
    val id : Int?,
    val alumno : Alumno,
    val curso : Curso,
    val fechAlta : Date?,
    val fechBaja : Date?,
    val autorizacionFotos : Byte,
    val beca : Byte
)

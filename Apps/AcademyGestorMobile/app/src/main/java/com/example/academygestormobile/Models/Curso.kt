package com.example.academygestormobile.Models

data class Curso(
    val id: Int? = null,
    val cod_curso: String = "",
    val nombre: String = "",
    val descripcion: String = "",
    val horario: String = "",
    val tipo: Tipo ,
    val activo: Byte? = null,

)

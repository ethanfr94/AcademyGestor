package com.example.academygestormobile.Models

import java.util.Date

data class Publicacion(
    val id: Int,
    val timeStamp: Date,
    val tipo: TipoPublicacion,
    val url: String,
    val titulo: String,
    val descripcion: String,
    val profesor: Profesor
)


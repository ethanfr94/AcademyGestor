package com.example.academygestormobile.Models

import java.util.Date

data class Recibo(
    val id: Int,
    val matricula: Matricula,
    val detalle: String,
    val fecha: Date,
    val importe: Double,
    val descuento: Byte,
    val pagado: Byte
)

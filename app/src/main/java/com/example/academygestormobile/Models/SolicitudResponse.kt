package com.example.academygestormobile.Models

data class SolicitudResponse(
    val `data`: List<Solicitud> = emptyList(),
    val status: String = ""
)

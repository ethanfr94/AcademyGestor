package com.example.academygestormobile.Models

data class PublicacionResponse(
    val `data`: List<Publicacion> = emptyList(),
    val status: String = ""
)

package com.example.academygestormobile.Models

data class UsuarioResponse(
    val `data`: List<Usuario> = emptyList(),
    val status: String = ""
)

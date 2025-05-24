package com.example.academygestormobile.Models

data class EmpresaResponse(
    val `data`: List<Empresa> = emptyList(),
    val status: String = ""
)

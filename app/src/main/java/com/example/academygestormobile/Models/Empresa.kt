package com.example.academygestormobile.Models

data class Empresa(
    val id: Int,
    val nombre: String,
    val razon_fiscal: String,
    val cif: String,
    val email: String,
    val telefono: String,
    val direccion: String,
    val localidad: String,
    val provincia: String,
    val cp: String
)

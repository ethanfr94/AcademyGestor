package com.example.academygestormobile.Navigation

import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Call
import androidx.compose.material.icons.filled.DateRange
import androidx.compose.material.icons.filled.Home
import androidx.compose.material.icons.filled.Info
import androidx.compose.material.icons.filled.Menu
import androidx.compose.material.icons.filled.Person
import androidx.compose.material.icons.filled.Star
import androidx.compose.ui.graphics.vector.ImageVector

sealed class ItemsNav (
    val icono: ImageVector,
    val texto:String,
    val ruta:String
)
{
    object Item_bottom_nav_home:ItemsNav(
        Icons.Filled.Home,"Home", "home")
    object Item_bottom_nav_info:ItemsNav(
        Icons.Filled.Info,"Informacion", "informacion")
    object Item_bottom_nav_contact:ItemsNav(
        Icons.Default.Call,"Contacto", "contacto")
    object Item_bottom_nav_profesor:ItemsNav(
        Icons.Filled.Person,"Profesor", "profesor")


}
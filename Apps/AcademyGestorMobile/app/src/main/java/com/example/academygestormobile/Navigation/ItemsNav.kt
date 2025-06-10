package com.example.academygestormobile.Navigation

import com.example.academygestormobile.R

sealed class ItemsNav(
    val icono: Int,
    val ruta:String
)
{
    object Item_bottom_nav_home:ItemsNav(
        R.drawable.home_24, "home")
    object Item_bottom_nav_info:ItemsNav(
        R.drawable.cursos_24, "cursos")
    object Item_bottom_nav_contact:ItemsNav(
        R.drawable.contact, "contacto")
    object Item_bottom_nav_profesor:ItemsNav(
        R.drawable.prof_24, "profesor")
}

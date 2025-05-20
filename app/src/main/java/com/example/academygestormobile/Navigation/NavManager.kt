package com.example.academygestormobile.Navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.example.academygestormobile.Views.Contact
import com.example.academygestormobile.Views.CursosView
import com.example.academygestormobile.Views.Home
import com.example.academygestormobile.Views.Loggin
import com.example.academygestormobile.Views.SolicitudView

@Composable
fun NavManager(
    navController: NavHostController,
) {

    NavHost(
        navController = navController,
        startDestination = "loggin"
    ) {
        composable("loggin") {
            Loggin(navController)
        }
        composable("home") {
            Home(navController)
        }
        composable("contacto") {
            Contact(navController)
        }
        composable("cursos") {
            CursosView(navController)
        }
        composable("solicitud") {
            SolicitudView(navController)
        }

    }
}

package com.example.academygestormobile.Navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.example.academygestormobile.Views.Home
import com.example.academygestormobile.Views.Loggin

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
    }
}

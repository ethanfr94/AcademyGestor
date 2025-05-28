package com.example.academygestormobile

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.activity.viewModels
import androidx.navigation.compose.rememberNavController
import com.example.academygestormobile.Navigation.NavManager
import com.example.academygestormobile.ViewModels.CursosViewModel
import com.example.academygestormobile.ViewModels.EmpresaViewModel
import com.example.academygestormobile.ViewModels.MatriculasViewModel
import com.example.academygestormobile.ViewModels.PublicacionViewModel
import com.example.academygestormobile.ViewModels.SolicitudViewModel
import com.example.academygestormobile.ViewModels.UsuariosViewModel
import com.example.academygestormobile.Views.Loggin

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {

            val navController = rememberNavController()
            val usuariosViewModel by viewModels<UsuariosViewModel>()
            val cursosViewModel by viewModels<CursosViewModel>()
            val matriculasViewModel by viewModels<MatriculasViewModel>()
            val publicacionViewModel by viewModels<PublicacionViewModel>()
            val solicitudViewModel by viewModels<SolicitudViewModel>()
            val empresaViewModel by viewModels<EmpresaViewModel>()

            NavManager(navController,
                usuariosViewModel,
                cursosViewModel,
                matriculasViewModel,
                publicacionViewModel,
                solicitudViewModel,
                empresaViewModel
            )

        }
    }
}

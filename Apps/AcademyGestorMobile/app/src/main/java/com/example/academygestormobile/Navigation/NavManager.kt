package com.example.academygestormobile.Navigation

import androidx.compose.runtime.Composable
import androidx.navigation.NavHostController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import com.example.academygestormobile.ViewModels.CursosViewModel
import com.example.academygestormobile.ViewModels.EmpresaViewModel
import com.example.academygestormobile.ViewModels.FaltasViewModel
import com.example.academygestormobile.ViewModels.MatriculasViewModel
import com.example.academygestormobile.ViewModels.ProfesoresCursoViewModel
import com.example.academygestormobile.ViewModels.PublicacionViewModel
import com.example.academygestormobile.ViewModels.SolicitudViewModel
import com.example.academygestormobile.ViewModels.TutorViewModel
import com.example.academygestormobile.ViewModels.UsuariosViewModel
import com.example.academygestormobile.Views.Contact
import com.example.academygestormobile.Views.CursosView
import com.example.academygestormobile.Views.Home
import com.example.academygestormobile.Views.Loggin
import com.example.academygestormobile.Views.NewPostView
import com.example.academygestormobile.Views.Profesor
import com.example.academygestormobile.Views.SolicitudView

@Composable
fun NavManager(
    navController: NavHostController,
    // ViewModels
    usuariosViewModel: UsuariosViewModel,
    cursosViewModel: CursosViewModel,
    matriculasViewModel: MatriculasViewModel,
    publicacionViewModel: PublicacionViewModel,
    solicitudViewModel: SolicitudViewModel,
    empresaViewModel: EmpresaViewModel,
    faltasViewModel: FaltasViewModel,
    tutorViewModel: TutorViewModel,
    profesorCursoViewModel: ProfesoresCursoViewModel

) {

    NavHost(
        navController = navController,
        startDestination = "loggin"
    ) {
        composable("loggin") {
            Loggin(navController, usuariosViewModel)
        }
        composable("home") {
            Home(navController, publicacionViewModel)
        }
        composable("contacto") {
            Contact(navController, empresaViewModel)
        }
        composable("cursos") {
            CursosView(navController, cursosViewModel)
        }
        composable("solicitud") {
            SolicitudView(navController, solicitudViewModel, tutorViewModel)
        }
        composable("profesor") {
            Profesor(navController, profesorCursoViewModel, matriculasViewModel, faltasViewModel)
        }
        composable("newPost") {
            NewPostView(navController, publicacionViewModel)
        }

    }
}

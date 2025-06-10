package com.example.academygestormobile.Views

import android.widget.Toast
import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.Components.imagePicker
import com.example.academygestormobile.Models.TipoPublicacion
import com.example.academygestormobile.R
import com.example.academygestormobile.ViewModels.ProfesorViewModel
import com.example.academygestormobile.ViewModels.PublicacionViewModel

@Composable
fun NewPostView(nav: NavController, publicacionViewModel: PublicacionViewModel = viewModel(), profesorViewModel: ProfesorViewModel = viewModel()) {

    var titulo by remember { mutableStateOf("") }
    var contenido by remember { mutableStateOf("") }
    var tipo by remember { mutableStateOf(TipoPublicacion.Texto) }
    var enable by remember { mutableStateOf(false) }
    val prof by profesorViewModel.profesor.observeAsState()

    Scaffold(
        topBar = { TopAppBar(nav) },
        bottomBar = { BottomAppBar(nav) }
    ) { innerPadding ->
        Box(
            modifier = Modifier
                .fillMaxSize()
                .padding(innerPadding)
        ) {
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(16.dp)
            ) {
                Card(
                    modifier = Modifier
                        .fillMaxSize()
                        .padding(10.dp)
                        .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                    shape = RoundedCornerShape(12.dp),
                ) {
                    Box(modifier = Modifier.padding(16.dp)) {
                        Column {
                            // Aquí puedes agregar el contenido de la tarjeta

                            Text(
                                text = "Nueva Publicación",
                                fontSize = 18.sp,
                                fontWeight = FontWeight.Bold,
                                modifier = Modifier.padding(30.dp, 0.dp, 0.dp, 0.dp)
                            )

                            OutlinedTextField(
                                value = titulo,
                                onValueChange = { titulo = it },
                                label = {
                                    Text(
                                        "Titulo"
                                    )
                                },
                                keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .padding(vertical = 12.dp), // Margen uniforme vertical
                                shape = RoundedCornerShape(12.dp), // Bordes más suaves
                            )

                            OutlinedTextField(
                                value = contenido,
                                onValueChange = { contenido = it },
                                label = {
                                    Text(
                                        "Contenido"
                                    )
                                },
                                keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .height(200.dp) // Ajusta la altura según sea necesario
                                    .padding(vertical = 12.dp), // Margen uniforme vertical
                                shape = RoundedCornerShape(12.dp), // Bordes más suaves
                            )

                            var context = LocalContext.current

                            imagePicker(context)

                            Button(
                                onClick = {
                                    Toast.makeText(
                                        nav.context,
                                        "Servicio en desarrollo",
                                        Toast.LENGTH_SHORT
                                    ).show()
                                },
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .padding(top = 20.dp),  // Padding superior para el botón
                                shape = RoundedCornerShape(50.dp)
                            )
                            {
                                Text(
                                    text = "Subir publicacion",
                                    fontSize = 20.sp,
                                    fontWeight = FontWeight.Bold
                                )
                            }
                        }
                    }
                }
            }
        }
    }
    BackHandler {
        nav.navigate("home") {
            popUpTo("home") { inclusive = true }
        }
    }
}


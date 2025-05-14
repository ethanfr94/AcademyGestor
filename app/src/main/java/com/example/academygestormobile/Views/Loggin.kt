package com.example.academygestormobile.Views

import androidx.activity.compose.BackHandler
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Lock
import androidx.compose.material.icons.filled.Person
import androidx.compose.material3.Button
import androidx.compose.material3.ButtonDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.focus.focusModifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.input.PasswordVisualTransformation
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavHostController
import com.example.academygestormobile.R

@Composable
fun Loggin(nav: NavHostController) {

    var user by remember { mutableStateOf("") }
    var pass by remember { mutableStateOf("") }

    Box(
        modifier = Modifier
            .fillMaxSize()
    ) {
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(horizontal = 30.dp)
                .padding(top = 50.dp),
            horizontalAlignment = Alignment.CenterHorizontally,
            verticalArrangement = Arrangement.Top
        ) {
            // imagen centrada

            Image(
                painter = painterResource(id = R.drawable.ag),
                contentDescription = "Logo de la App",
                modifier = Modifier
                    .size(400.dp)
                    .padding(top = 100.dp)// Aumenta el tamaño de la imagen sin afectar el layout
            )
            // campos inicio de sesion usuario y boton

            OutlinedTextField(
                value = user,
                onValueChange = { user = it },
                label = { Text("Usuario") },
                leadingIcon = {
                    Icon(
                        imageVector = Icons.Default.Person,
                        contentDescription = "Icono de usuario"
                    )
                },
                keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(vertical = 12.dp), // Margen uniforme vertical
                shape = RoundedCornerShape(12.dp), // Bordes más suaves
            )

            OutlinedTextField(
                value = pass,
                onValueChange = { pass = it },
                label = { Text("Contraseña") },
                leadingIcon = {
                    Icon(
                        imageVector = Icons.Default.Lock,
                        contentDescription = "Icono de contraseña"
                    )
                },
                visualTransformation = PasswordVisualTransformation(),
                keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Password),
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(vertical = 12.dp), // Margen uniforme vertical
                shape = RoundedCornerShape(12.dp), // Bordes más suaves
            )

            Button(
                onClick = { /* verificacion de campos rellenos y de credenciales en la api*/ },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(top = 20.dp),  // Padding superior para el botón
                shape = RoundedCornerShape(50.dp)
            )
            {
                Text(
                    text = "Iniciar sesion",
                    fontSize = 20.sp,
                    fontWeight = FontWeight.Bold
                )
            }

            // boton inicio invitado

            Button(
                onClick = { nav.navigate("home") },
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(top = 20.dp),  // Padding superior para el botón
                shape = RoundedCornerShape(50.dp)
            )
            {
                Text(
                    text = "Acceder como invitado",
                    fontSize = 20.sp,
                    fontWeight = FontWeight.Bold
                )
            }
        }
    }
    BackHandler {
        // Manejo del botón de retroceso
    }
}
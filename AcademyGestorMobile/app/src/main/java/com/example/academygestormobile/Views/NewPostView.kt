package com.example.academygestormobile.Views

import androidx.activity.compose.BackHandler
import androidx.compose.foundation.Image
import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Create
import androidx.compose.material.icons.filled.Email
import androidx.compose.material.icons.filled.MailOutline
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.OutlinedTextFieldDefaults
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Switch
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.res.vectorResource
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.R

@Composable
fun NewPostView(nav: NavController) {

    var email by remember { mutableStateOf("") }
    var asunto by remember { mutableStateOf("") }
    var cuerpo by remember { mutableStateOf("") }

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
                    //colors = CardDefaults.cardColors(containerColor = color),
                    //border = if (actividad.fini == LocalDate.now().toString()) BorderStroke(3.dp, GreenBar) else null
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
                                value = email,
                                onValueChange = { email = it },
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
                                value = asunto,
                                onValueChange = { asunto = it },
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

                            Row(
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .padding(vertical = 16.dp), // Adds vertical spacing
                                horizontalArrangement = Arrangement.SpaceEvenly, // Evenly spaces the items horizontally
                                verticalAlignment = Alignment.CenterVertically // Aligns items vertically at the center
                            ) {
                                Text(
                                    text = "Texto",
                                    fontSize = 18.sp,
                                    fontWeight = FontWeight.Bold
                                )

                                var enable by remember { mutableStateOf(false) }
                                Switch(
                                    enabled = true,
                                    checked = enable,
                                    onCheckedChange = { enable = it },
                                    modifier = Modifier.size(20.dp) // Adjusts the size of the switch
                                )

                                Text(
                                    text = "Foto",
                                    fontSize = 18.sp,
                                    fontWeight = FontWeight.Bold
                                )
                            }

                            Box(
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .height(250.dp) // Adjust the height as needed
                                    .padding(vertical = 12.dp)
                                    .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)) // Optional border for the box
                            ) {
                                IconButton(
                                    onClick = { /* Action when the icon is clicked */ },
                                    modifier = Modifier.align(Alignment.Center) // Center the icon in the box
                                ) {
                                    Icon(
                                        imageVector = ImageVector.vectorResource(id = R.drawable.add_photo_24),
                                        contentDescription = "Add Image",
                                        tint = Color.Gray,
                                        modifier = Modifier.size(50.dp) // Adjust the icon size
                                    )
                                }
                            }

                            Button(
                                onClick = { /* verificacion de campos rellenos y de credenciales en la api*/ },
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
        // Manejo del botón de retroceso
    }
}


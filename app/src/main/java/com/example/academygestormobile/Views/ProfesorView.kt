package com.example.academygestormobile.Views

import android.widget.Space
import android.widget.ToggleButton
import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Check
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.CardDefaults
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.IconToggleButton
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Slider
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
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import java.time.LocalDate

@Composable
fun Profesor(nav: NavController) {

    Scaffold(
        topBar = { TopAppBar(nav,) },
        bottomBar = { BottomAppBar(nav) }
    ) { innerPadding ->
        Box(
            modifier = Modifier
                .fillMaxSize()
                .padding(innerPadding)
        ) {
            Column {
                    Box(modifier = Modifier.padding(16.dp)) {
                        Column {
                            Text(
                                text = "Mis Cursos",
                                fontSize = 18.sp,
                                fontWeight = FontWeight.Bold,
                                textAlign = TextAlign.Center
                            )
                            Row(
                                modifier = Modifier
                                    .fillMaxWidth()
                                    .height(100.dp)
                            ) {
                                LazyRow {
                                    items(5) { actividad ->
                                        Card(
                                            modifier = Modifier
                                                .padding(5.dp)
                                                .fillMaxHeight()
                                                .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                                            shape = RoundedCornerShape(12.dp),
                                            onClick = {
                                            },
                                        ) {
                                            Box(
                                                modifier = Modifier
                                                    .fillMaxSize()
                                                    .padding(16.dp),
                                                contentAlignment = Alignment.Center // Centra el contenido dentro de la tarjeta
                                            ) {
                                                Text(
                                                    text = "Curso",
                                                    fontSize = 18.sp,
                                                    fontWeight = FontWeight.Bold,
                                                    textAlign = TextAlign.Center
                                                )
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }



                Box(modifier = Modifier.padding(16.dp)) {
                    Column {
                        Row(
                            modifier = Modifier
                                .fillMaxWidth()
                                .padding(horizontal = 16.dp, vertical = 8.dp),
                            horizontalArrangement = Arrangement.SpaceBetween
                        ) {
                            Text(
                                text = "Alumnos",
                                fontSize = 18.sp,
                                fontWeight = FontWeight.Bold,
                                textAlign = TextAlign.Start
                            )
                            Text(
                                text = "Faltas",
                                fontSize = 18.sp,
                                fontWeight = FontWeight.Bold,
                                textAlign = TextAlign.Start
                            )
                        }
                        LazyColumn(
                            modifier = Modifier
                                .weight(1f) // Permite que el LazyColumn ocupe el espacio restante
                        ) {
                            items(7) { actividad ->
                                Spacer(modifier = Modifier.height(8.dp))
                                Card(
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                                    shape = RoundedCornerShape(12.dp),
                                ) {
                                    Row(
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(16.dp),
                                        horizontalArrangement = Arrangement.SpaceBetween
                                    ) {
                                        Text(
                                            text = "Nombre",
                                            fontSize = 18.sp,
                                            fontWeight = FontWeight.Bold,
                                            textAlign = TextAlign.Start,
                                            modifier = Modifier.align(Alignment.CenterVertically)
                                        )
                                        Row(
                                            verticalAlignment = Alignment.CenterVertically,
                                            modifier = Modifier.align(Alignment.CenterVertically)
                                        ) {
                                            Text(
                                                text = "Falta",
                                                fontSize = 16.sp,
                                                fontWeight = FontWeight.Normal,
                                                textAlign = TextAlign.End,
                                                modifier = Modifier.padding(end = 8.dp)
                                            )
                                            var enable by remember { mutableStateOf(false) }
                                            Switch(
                                                enabled = true,
                                                checked = enable,
                                                onCheckedChange = { enable = it },
                                                modifier = Modifier.align(Alignment.CenterVertically)
                                            )
                                        }
                                    }
                                }
                            }
                        }
                        Button(
                            onClick = { /* Acción del botón */ },
                            modifier = Modifier
                                .fillMaxWidth()
                                .padding(top = 8.dp) // Espaciado entre el LazyColumn y el botón
                        ) {
                            Text(text = "Registrar faltas")
                        }
                    }
                }



            }
            BackHandler {
                // Manejo del botón de retroceso
            }
        }
    }
}
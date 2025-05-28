package com.example.academygestormobile.Views

import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Card
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar

@Composable
fun Home(nav: NavController) {

    Scaffold(
        topBar = { TopAppBar(nav) },
        bottomBar = { BottomAppBar(nav) }
    ) { innerPadding ->
        Box(
            modifier = Modifier
                .fillMaxSize()
                .padding(innerPadding)
        ) {
            LazyColumn {
                items(/*coleccion que recogera las publicaciones*/25) { item ->
                    Row(
                        modifier = Modifier
                            .fillMaxWidth()
                            .padding(16.dp)
                    ) {
                        Card(
                            modifier = Modifier
                                .weight(1f)
                                .padding(10.dp)
                                .fillMaxHeight()
                                .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                            shape = RoundedCornerShape(12.dp),
                            //colors = CardDefaults.cardColors(containerColor = color),
                            //border = if (actividad.fini == LocalDate.now().toString()) BorderStroke(3.dp, GreenBar) else null
                        )  {
                            Box(modifier = Modifier.padding(16.dp)) {
                                Column {
                                    // Aquí puedes agregar el contenido de la tarjeta
                                    Text(
                                        text = "Titulo publicacion",
                                        fontSize = 18.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Start
                                    )
                                    Text(
                                        text = "Contenido",
                                        fontSize = 14.sp,
                                        textAlign = TextAlign.Start
                                    )
                                }
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
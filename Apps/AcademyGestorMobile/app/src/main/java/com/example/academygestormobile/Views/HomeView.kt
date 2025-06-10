package com.example.academygestormobile.Views

import android.util.Log
import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Card
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.Models.Publicacion
import com.example.academygestormobile.ViewModels.PublicacionViewModel

@Composable
fun Home(nav: NavController, publicacionViewModel: PublicacionViewModel = PublicacionViewModel()) {

    val publicaciones: List<Publicacion> by publicacionViewModel.items.observeAsState(emptyList())

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
                items(publicaciones) { item ->
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
                        )  {
                            Box(modifier = Modifier.padding(16.dp)) {
                                Column {
                                    Text(
                                        text = item.titulo,
                                        fontSize = 12.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Start,
                                        modifier = Modifier.padding(bottom = 8.dp)
                                    )

                                    // Description below the title
                                    Text(
                                        text = item.descripcion,
                                        fontSize = 16.sp,
                                        textAlign = TextAlign.Start,
                                        modifier = Modifier.padding(bottom = 8.dp)
                                    )

                                    Row(
                                        modifier = Modifier.fillMaxWidth(),
                                        horizontalArrangement = Arrangement.End
                                    ) {
                                        Text(
                                            text = "${item.profesor.nombre} ${item.profesor.apellido1} ${item.profesor.apellido2}",
                                            fontSize = 12.sp,
                                            textAlign = TextAlign.End
                                        )
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    LaunchedEffect(Unit){
        publicacionViewModel.getPublicaciones()
    }

    BackHandler {
    }
}
package com.example.academygestormobile.Views

import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.Curso
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.ViewModels.CursosViewModel

@Composable
fun  CursosView(nav: NavController, cursosViewModel: CursosViewModel= CursosViewModel()) {

   val cursos by cursosViewModel.cursos.observeAsState(emptyList())
    var visible  by remember { mutableStateOf<String?>(null) }

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
                items(cursos) { item ->
                   // var visible by remember { mutableStateOf(false) }
                    Row(
                        modifier = Modifier
                            .fillMaxWidth()
                            .padding(16.dp)
                    ) {
                        Card(
                            modifier = Modifier
                                .weight(1f)
                                .padding(10.dp)
                                .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                            shape = RoundedCornerShape(12.dp),
                            onClick = {
                                visible = if (visible == item.cod_curso) null else item.cod_curso
                            }
                        )  {
                            Box(modifier = Modifier.padding(16.dp)) {
                                Column {
                                    // Aquí puedes agregar el contenido de la tarjeta
                                    Text(
                                        text = item.nombre,
                                        fontSize = 18.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Start
                                    )
                                    if(visible == item.cod_curso) {

                                        Spacer(modifier = Modifier.padding(8.dp))

                                        Text(
                                            text = item.descripcion,
                                            fontSize = 14.sp,
                                            textAlign = TextAlign.Start
                                        )

                                        Spacer(modifier = Modifier.padding(8.dp))

                                        Text(
                                            text = item.horario,
                                            fontSize = 14.sp,
                                            textAlign = TextAlign.Start
                                        )
                                        Spacer(modifier = Modifier.padding(8.dp))


                                        Text(
                                            text = "Curso "+item.tipo.nombre,
                                            fontSize = 14.sp,
                                            textAlign = TextAlign.Start
                                        )
                                        Spacer(modifier = Modifier.padding(8.dp))


                                        Button(
                                            onClick = {
                                                Curso.curso = item
                                                nav.navigate("solicitud")
                                            },
                                            modifier = Modifier
                                                .fillMaxWidth()
                                                .padding(top = 20.dp),  // Padding superior para el botón
                                            shape = RoundedCornerShape(50.dp)
                                        )
                                        {
                                            Text(
                                                text = "Solicitar plaza",
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
            }
        }
    }

    LaunchedEffect(Unit){
        cursosViewModel.getCursos()
    }

    BackHandler {
        // Manejo del botón de retroceso
        nav.navigate("home") {
            popUpTo("home") { inclusive = true }
        }
    }
}

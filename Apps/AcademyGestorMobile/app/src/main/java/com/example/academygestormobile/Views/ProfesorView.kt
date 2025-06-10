package com.example.academygestormobile.Views

import android.util.Log
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
import androidx.compose.foundation.lazy.items
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
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.runtime.mutableStateListOf
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
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Models.Curso
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.Components.User
import com.example.academygestormobile.Models.Alumno
import com.example.academygestormobile.Models.Falta_Asistencia
import com.example.academygestormobile.Models.Matricula
import com.example.academygestormobile.ViewModels.FaltasViewModel
import com.example.academygestormobile.ViewModels.MatriculasViewModel
import com.example.academygestormobile.ViewModels.ProfesorViewModel
import com.example.academygestormobile.ViewModels.ProfesoresCursoViewModel
import java.time.LocalDate

@Composable
fun Profesor(
    nav: NavController,
    profesoresCursoViewModel: ProfesoresCursoViewModel = viewModel(),
    matriculasViewModel: MatriculasViewModel = viewModel(),
    faltasViewModel: FaltasViewModel = viewModel()
) {

    val profCurs by profesoresCursoViewModel.items.observeAsState(emptyList())
    val cursos = remember { mutableStateListOf<Curso>() }
    val matriculas by matriculasViewModel.matriculas.observeAsState(emptyList())
    val alumnos = remember { mutableStateListOf<Alumno>() }
    val curso = remember { mutableStateOf<Curso?>(null) }
    val faltas by faltasViewModel.items.observeAsState(emptyList())

    Scaffold(
        topBar = { TopAppBar(nav) },
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
                                items(cursos) { cur ->
                                    Card(
                                        modifier = Modifier
                                            .padding(5.dp)
                                            .fillMaxHeight()
                                            .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                                        shape = RoundedCornerShape(12.dp),
                                        onClick = {
                                            alumnos.clear()
                                            curso.value = cur
                                            for (matricula in matriculas) {
                                                if (matricula.curso.id == cur.id) {
                                                    alumnos.add(matricula.alumno)
                                                }
                                            }
                                        },
                                    ) {
                                        Box(
                                            modifier = Modifier
                                                .fillMaxSize()
                                                .padding(16.dp),
                                            contentAlignment = Alignment.Center // Centra el contenido dentro de la tarjeta
                                        ) {
                                            Text(
                                                text = cur.nombre,
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
                            items(alumnos) { alumno ->
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
                                            text = "${alumno.nombre} ${alumno.apellido1} ${alumno.apellido2}",
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
                                                onCheckedChange = {
                                                    enable = it
                                                    if(enable){
                                                        curso.value?.let { it1 ->
                                                            Falta_Asistencia(
                                                                alumno = alumno,
                                                                curso = curso?.value!!,
                                                                id = null,
                                                                fecha = null
                                                            ).let { falta ->
                                                                faltasViewModel.saveFalta(falta)
                                                                Log.d("Profesor", "Falta registrada para ${alumno.nombre}")
                                                            }
                                                        }
                                                    }
                                                },
                                                modifier = Modifier.align(Alignment.CenterVertically)
                                            )
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


            }

            LaunchedEffect(profCurs) {
                matriculasViewModel.getMatriculas()
                profesoresCursoViewModel.getProfesoresCursos()
                faltasViewModel.getFaltas()

                if (profCurs.isNotEmpty()) {
                    for (pc in profCurs) {
                        if (pc.profesor.email == User.user?.user) {
                            cursos.add(pc.curso)
                        }
                    }
                }

                Log.d("Profesor", "Cursos: ${cursos.size}")
            }

            BackHandler {
                nav.navigate("home") {
                    popUpTo("home") { inclusive = true }
                }
            }
        }
    }
}
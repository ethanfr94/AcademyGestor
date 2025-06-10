package com.example.academygestormobile.Views

import android.content.Intent
import android.net.Uri
import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Create
import androidx.compose.material.icons.filled.Email
import androidx.compose.material.icons.filled.MailOutline
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedTextField
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
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.lifecycle.viewmodel.compose.viewModel
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import com.example.academygestormobile.Models.Empresa
import com.example.academygestormobile.ViewModels.EmpresaViewModel

@Composable
fun Contact(nav: NavController, empresaViewModel: EmpresaViewModel = viewModel()) {

    val empresa: Empresa? by empresaViewModel.empresa.observeAsState()
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
            Column {
                Row(
                    modifier = Modifier
                        .fillMaxWidth()
                ) {
                    Card(
                        modifier = Modifier
                            .weight(1f)
                            .padding(10.dp)
                            .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                        shape = RoundedCornerShape(12.dp),
                        //colors = CardDefaults.cardColors(containerColor = color),
                        //border = if (actividad.fini == LocalDate.now().toString()) BorderStroke(3.dp, GreenBar) else null
                    ) {
                        Box(modifier = Modifier.padding(16.dp)) {
                            Column {
                                Text(
                                    text = "Envianos tu consulta",
                                    fontSize = 18.sp,
                                    fontWeight = FontWeight.Bold,
                                    textAlign = TextAlign.Justify,
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .padding(bottom = 8.dp) // Espacio entre el texto y el número
                                )

                                OutlinedTextField(
                                    value = asunto,
                                    onValueChange = { asunto = it },
                                    label = {
                                        Text(
                                            "ASUNTO",
                                            modifier = Modifier.padding(30.dp, 0.dp, 0.dp, 0.dp)
                                        );
                                        Icon(
                                            imageVector = Icons.Default.MailOutline,
                                            contentDescription = "Icono"
                                        )
                                    },
                                    keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .padding(vertical = 12.dp), // Margen uniforme vertical
                                    shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                )

                                OutlinedTextField(
                                    value = cuerpo,
                                    onValueChange = { cuerpo = it },
                                    label = {
                                        Text(
                                            "CUERPO",
                                            modifier = Modifier.padding(30.dp, 0.dp, 0.dp, 0.dp)
                                        );
                                        Icon(
                                            imageVector = Icons.Default.Create,
                                            contentDescription = "Icono",
                                        )
                                    },
                                    keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .height(200.dp) // Ajusta la altura según sea necesario
                                        .padding(vertical = 12.dp), // Margen uniforme vertical
                                    shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                )

                                Button(
                                    onClick = {
                                        empresa?.email?.let { empresaEmail ->
                                            val intent = Intent(Intent.ACTION_SEND).apply {
                                                type = "message/rfc822" // Tipo MIME para correo electrónico
                                                putExtra(Intent.EXTRA_EMAIL, arrayOf(empresaEmail)) // Destinatario
                                                putExtra(Intent.EXTRA_SUBJECT, asunto) // Asunto
                                                putExtra(Intent.EXTRA_TEXT, cuerpo) // Cuerpo del mensaje
                                            }
                                            nav.context.startActivity(Intent.createChooser(intent, "Enviar correo electrónico")) // Selector de aplicaciones
                                        }
                                    },
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .padding(top = 20.dp),  // Padding superior para el botón
                                    shape = RoundedCornerShape(50.dp)
                                )
                                {
                                    Text(
                                        text = "Enviar via Email",
                                        fontSize = 20.sp,
                                        fontWeight = FontWeight.Bold
                                    )
                                }

                                Spacer(modifier = Modifier.height(20.dp))

                                Button(
                                    onClick = {
                                        empresa?.telefono?.let { telefono ->
                                            val intent = Intent(Intent.ACTION_VIEW).apply {
                                                data = Uri.parse("https://wa.me/$telefono?text=${Uri.encode(cuerpo)}") // WhatsApp chat URI with pre-filled text
                                            }
                                            nav.context.startActivity(intent) // Open WhatsApp
                                        }
                                    },
                                    modifier = Modifier
                                        .fillMaxWidth()
                                        .padding(top = 20.dp),  // Padding superior para el botón
                                    shape = RoundedCornerShape(50.dp)
                                ) {
                                    Text(
                                        text = "Enviar via WhatsApp",
                                        fontSize = 20.sp,
                                        fontWeight = FontWeight.Bold
                                    )
                                }
                            }
                        }
                    }
                }

                Row(
                    modifier = Modifier
                        .fillMaxWidth()
                ) {
                    Card(
                        modifier = Modifier
                            .weight(1f)
                            .padding(10.dp)
                            .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                        shape = RoundedCornerShape(12.dp),
                        //colors = CardDefaults.cardColors(containerColor = color),
                        //border = if (actividad.fini == LocalDate.now().toString()) BorderStroke(3.dp, GreenBar) else null
                    ) {
                        Box(modifier = Modifier.padding(16.dp)) {
                            LazyColumn (
                                modifier = Modifier.fillMaxWidth()
                            ) {
                                item{
                                    // Texto informativo justificado
                                    Text(
                                        text = "También puedes contactar a nuestro número de teléfono: Horario de lunes a viernes de 09:30 a 14:30",
                                        fontSize = 18.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Justify,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(bottom = 8.dp) // Espacio entre el texto y el número
                                    )
                                    Button(
                                        onClick = {
                                            empresa?.telefono?.let { telefono ->
                                                val intent = Intent(Intent.ACTION_DIAL).apply {
                                                    data =
                                                        Uri.parse("tel:$telefono")
                                                }
                                                nav.context.startActivity(intent)
                                            }
                                        },
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(top = 20.dp),  // Padding superior para el botón
                                        shape = RoundedCornerShape(50.dp)
                                    ) {
                                        Text(
                                            text = "Llamar",
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


        LaunchedEffect (Unit){
            empresaViewModel.getEmpresa()
        }

        BackHandler {
            nav.navigate("home") {
                popUpTo("home") { inclusive = true }
            }
        }
    }
}
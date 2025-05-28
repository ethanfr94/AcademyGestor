package com.example.academygestormobile.Views

import android.annotation.SuppressLint
import androidx.activity.compose.BackHandler
import androidx.compose.foundation.border
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.KeyboardOptions
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.DateRange
import androidx.compose.material3.Button
import androidx.compose.material3.Card
import androidx.compose.material3.Icon
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.input.KeyboardType
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.navigation.NavController
import com.example.academygestormobile.Components.BottomAppBar
import com.example.academygestormobile.Components.TopAppBar
import android.app.DatePickerDialog
import android.widget.DatePicker
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.style.TextAlign
import java.util.*

@SuppressLint("UnusedMaterial3ScaffoldPaddingParameter")
@Composable
fun SolicitudView(nav: NavController) {

    var nombre by remember { mutableStateOf("") }
    var ape1 by remember { mutableStateOf("") }
    var ape2 by remember { mutableStateOf("") }
    var dni by remember { mutableStateOf("") }
    var direccion by remember { mutableStateOf("") }
    var localidad by remember { mutableStateOf("") }
    var email by remember { mutableStateOf("") }
    var tlfn by remember { mutableStateOf("") }
    var nombreTut by remember { mutableStateOf("") }
    var ape1Tut by remember { mutableStateOf("") }
    var ape2Tut by remember { mutableStateOf("") }
    var dniTut by remember { mutableStateOf("") }
    var direccionTut by remember { mutableStateOf("") }
    var localidadTut by remember { mutableStateOf("") }
    var emailTut by remember { mutableStateOf("") }
    var tlfnTut by remember { mutableStateOf("") }
    var selectedDate by remember { mutableStateOf("") }
    var isMinor by remember { mutableStateOf(true) }

    Scaffold(
        topBar = { TopAppBar(nav) },
        bottomBar = { BottomAppBar(nav) }
    ) { innerPadding ->

        LazyColumn {
            item {
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
                                .weight(1f)
                                .padding(10.dp)
                                .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                            shape = RoundedCornerShape(12.dp),
                            //colors = CardDefaults.cardColors(containerColor = color),
                            //border = if (actividad.fini == LocalDate.now().toString()) BorderStroke(3.dp, GreenBar) else null
                        ) {
                            Box(modifier = Modifier.padding(16.dp)) {
                                Column {
                                    OutlinedTextField(
                                        value = "nombre del curso",
                                        onValueChange = {  },
                                        label = {
                                            Text(
                                                "Curso",
                                            )
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = false,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    // Aquí puedes agregar el contenido de la tarjeta
                                    Text(
                                        text = "Alumno",
                                        fontSize = 20.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Center,
                                        modifier = Modifier.padding(16.dp)
                                    )

                                    OutlinedTextField(
                                        value = nombre,
                                        onValueChange = { nombre = it },
                                        label = {
                                            Text(
                                                "Nombre",
                                            )
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = ape1,
                                        onValueChange = { ape1 = it },
                                        label = {
                                            Text(
                                                "Primer apellido",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = ape2,
                                        onValueChange = { ape2 = it },
                                        label = {
                                            Text(
                                                "Segundo apellido",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = dni,
                                        onValueChange = { dni = it },
                                        label = {
                                            Text(
                                                "DNI",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    DatePickerOutlinedTextField(
                                        selectedDate = selectedDate,
                                        onDateSelected = { date ->
                                            selectedDate = date
                                            isMinor = calculateAge(date) < 18
                                        }
                                    )

                                    OutlinedTextField(
                                        value = direccion,
                                        onValueChange = { direccion = it },
                                        label = {
                                            Text(
                                                "Direccion",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )
                                    OutlinedTextField(
                                        value = localidad,
                                        onValueChange = { localidad = it },
                                        label = {
                                            Text(
                                                "Localidad",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )
                                    OutlinedTextField(
                                        value = email,
                                        onValueChange = { email = it },
                                        label = {
                                            Text(
                                                "EMAIL",
                                            )
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = tlfn,
                                        onValueChange = { tlfn = it },
                                        label = {
                                            Text(
                                                "Telefono",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Phone),
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    Text(
                                        text = "Tutor",
                                        fontSize = 20.sp,
                                        fontWeight = FontWeight.Bold,
                                        textAlign = TextAlign.Center,
                                        modifier = Modifier.padding(16.dp)
                                    )

                                    OutlinedTextField(
                                        value = nombreTut,
                                        onValueChange = { nombreTut = it },
                                        label = {
                                            Text(
                                                "Nombre",
                                            )
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = ape1Tut,
                                        onValueChange = { ape1Tut = it },
                                        label = {
                                            Text(
                                                "Primer apellido",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = ape2Tut,
                                        onValueChange = { ape2Tut = it },
                                        label = {
                                            Text(
                                                "Segundo apellido",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = dniTut,
                                        onValueChange = { dniTut = it },
                                        label = {
                                            Text(
                                                "DNI",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = direccionTut,
                                        onValueChange = { direccionTut = it },
                                        label = {
                                            Text(
                                                "Direccion",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )
                                    OutlinedTextField(
                                        value = localidadTut,
                                        onValueChange = { localidadTut = it },
                                        label = {
                                            Text(
                                                "Localidad",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Text),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )
                                    OutlinedTextField(
                                        value = emailTut,
                                        onValueChange = { emailTut = it },
                                        label = {
                                            Text(
                                                "EMAIL",
                                            )
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Email),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )

                                    OutlinedTextField(
                                        value = tlfnTut,
                                        onValueChange = { tlfnTut = it },
                                        label = {
                                            Text(
                                                "Telefono",
                                            );
                                        },
                                        keyboardOptions = KeyboardOptions(keyboardType = KeyboardType.Phone),
                                        enabled = isMinor,
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(vertical = 12.dp), // Margen uniforme vertical
                                        shape = RoundedCornerShape(12.dp), // Bordes más suaves
                                    )


                                    Button(
                                        onClick = {
                                            if(nombre.isNotEmpty() && ape1.isNotEmpty() && ape2.isNotEmpty() && dni.isNotEmpty() && selectedDate.isNotEmpty() && direccion.isNotEmpty() && localidad.isNotEmpty() && email.isNotEmpty() && tlfn.isNotEmpty()) {
                                                if(isMinor){
                                                    if(nombreTut.isNotEmpty() && ape1Tut.isNotEmpty() && ape2Tut.isNotEmpty() && dniTut.isNotEmpty() && direccionTut.isNotEmpty() && localidadTut.isNotEmpty() && emailTut.isNotEmpty() && tlfnTut.isNotEmpty()){
                                                        // comprobar si existen alumno y tutor y crear solicitud
                                                    }else{
                                                        // Mostrar mensaje de error todos los campos del tutor obligatorios
                                                    }
                                                }else{
                                                    // comprobar si existe alumno y crear solicitud
                                                }
                                            }else{
                                                // Mostrar mensaje de error todos los campos obligatorios
                                            }
                                        },
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(top = 20.dp),  // Padding superior para el botón
                                        shape = RoundedCornerShape(50.dp)
                                    )
                                    {
                                        Text(
                                            text = "Enviar consulta",
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
    BackHandler {
        // Manejo del botón de retroceso
    }
}

@Composable
fun DatePickerOutlinedTextField(
    selectedDate: String,
    onDateSelected: (String) -> Unit
) {
    var showDatePicker by remember { mutableStateOf(false) }

    if (showDatePicker) {
        val calendar = Calendar.getInstance()
        DatePickerDialog(
            LocalContext.current,
            { _: DatePicker, year: Int, month: Int, dayOfMonth: Int ->
                val formattedDate = String.format("%02d/%02d/%04d", dayOfMonth, month + 1, year)
                onDateSelected(formattedDate)
                showDatePicker = !showDatePicker
            },
            calendar.get(Calendar.YEAR),
            calendar.get(Calendar.MONTH),
            calendar.get(Calendar.DAY_OF_MONTH)
        ).show()
    }

    OutlinedTextField(
        value = selectedDate,
        onValueChange = {},
        label = { Text("Fecha de nacimiento") },
        modifier = Modifier
            .fillMaxWidth()
            .padding(vertical = 12.dp),
        shape = RoundedCornerShape(12.dp),
        readOnly = true,
        trailingIcon = {
            Icon(
                imageVector = Icons.Default.DateRange,
                contentDescription = "Select Date",
                modifier = Modifier.clickable {
                    showDatePicker = !showDatePicker
                } // Show date picker on click
            )
        },
        singleLine = true
    )
}

// Función para calcular la edad
fun calculateAge(birthDate: String): Int {
    val formatter = java.text.SimpleDateFormat("dd/MM/yyyy", Locale.getDefault())
    val date = formatter.parse(birthDate)
    val calendar = Calendar.getInstance()
    val today = Calendar.getInstance()

    calendar.time = date!!
    var age = today.get(Calendar.YEAR) - calendar.get(Calendar.YEAR)

    if (today.get(Calendar.DAY_OF_YEAR) < calendar.get(Calendar.DAY_OF_YEAR)) {
        age--
    }

    return age
}



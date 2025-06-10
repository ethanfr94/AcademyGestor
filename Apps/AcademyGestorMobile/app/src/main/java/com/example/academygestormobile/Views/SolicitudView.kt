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
import android.widget.Toast
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Checkbox
import androidx.compose.material3.DatePickerDialog
import androidx.compose.material3.DateRangePicker
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.runtime.livedata.observeAsState
import androidx.compose.ui.Alignment
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.text.AnnotatedString
import androidx.compose.ui.text.input.OffsetMapping
import androidx.compose.ui.text.input.TransformedText
import androidx.compose.ui.text.input.VisualTransformation
import androidx.compose.ui.text.style.TextAlign
import com.example.academygestormobile.Components.Curso
import com.example.academygestormobile.Models.Solicitud
import com.example.academygestormobile.Models.Tutor
import com.example.academygestormobile.ViewModels.SolicitudViewModel
import com.example.academygestormobile.ViewModels.TutorViewModel
import com.google.gson.Gson
import com.google.gson.GsonBuilder
import com.google.gson.JsonElement
import com.google.gson.JsonPrimitive
import com.google.gson.JsonSerializationContext
import com.google.gson.JsonSerializer
import java.lang.reflect.Type
import java.text.SimpleDateFormat
import java.time.LocalDate
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.util.*

@OptIn(ExperimentalMaterial3Api::class)
@SuppressLint("UnusedMaterial3ScaffoldPaddingParameter")
@Composable
fun SolicitudView(
    nav: NavController,
    solicitudViewModel: SolicitudViewModel = SolicitudViewModel(),
    tutorViewModel: TutorViewModel = TutorViewModel()
) {

    val tutor: Tutor? by tutorViewModel.tutor.observeAsState()
    val context = LocalContext.current
    var solicitud: Solicitud? by remember { mutableStateOf(null) }

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
    var fechaNac by remember { mutableStateOf(LocalDate.now()) }
    var day by remember { mutableStateOf(fechaNac.dayOfMonth) }
    var month by remember { mutableStateOf(fechaNac.monthValue) }
    var year by remember { mutableStateOf(fechaNac.year) }
    var isMinor by remember { mutableStateOf(true) }
    var proteccionDatos by remember { mutableStateOf(false) }
    var autorizaFotos by remember { mutableStateOf(false) }
    var whatsApp by remember { mutableStateOf(false) }
    var comComerciales by remember { mutableStateOf(false) }
    var beca by remember { mutableStateOf(false) }

    var showDatePicker by remember { mutableStateOf(false) }
    var showErrorDialog by remember { mutableStateOf(false) }
    var errorMessage by remember { mutableStateOf("") }

    var showDialog by remember { mutableStateOf(false) }
    var jsonToShow by remember { mutableStateOf("") }

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

                        Card(
                            modifier = Modifier
                                .padding(10.dp)
                                .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)),
                            shape = RoundedCornerShape(12.dp),
                        ) {
                            Box(modifier = Modifier.padding(16.dp)) {
                                Column {
                                    OutlinedTextField(
                                        value = Curso.curso!!.nombre,
                                        onValueChange = { },
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

                                    OutlinedTextField(
                                        value = fechaNac.format(DateTimeFormatter.ofPattern("dd/MM/yyyy")),
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
                                                contentDescription = "Seleccionar fecha",
                                                modifier = Modifier.clickable { showDatePicker = true }
                                            )
                                        },
                                        singleLine = true
                                    )

                                    if (showDatePicker) {
                                        DatePickerDialog(
                                            context,
                                            { _: DatePicker, selectedYear: Int, selectedMonth: Int, selectedDay: Int ->
                                                year = selectedYear
                                                month = selectedMonth + 1 // Los meses en DatePicker son 0-indexed
                                                day = selectedDay
                                                fechaNac = LocalDate.of(year, month, day)

                                                isMinor = calculateAge("$day/$month/$year") < 18
                                                showDatePicker = false
                                            },
                                            year,
                                            month - 1, // Ajustar el mes a 0-indexed
                                            day
                                        ).show()
                                    }


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

                                    CustomCheckbox(
                                        checked = proteccionDatos,
                                        onCheckedChange = { proteccionDatos = it },
                                        label = "Autorizacion proteccion de datos"
                                    )

                                    CustomCheckbox(
                                        checked = autorizaFotos,
                                        onCheckedChange = { autorizaFotos = it },
                                        label = "Autorización de fotos"
                                    )

                                    CustomCheckbox(
                                        checked = whatsApp,
                                        onCheckedChange = { whatsApp = it },
                                        label = "Autorización de grupo de WhatsApp"
                                    )

                                    CustomCheckbox(
                                        checked = comComerciales,
                                        onCheckedChange = { comComerciales = it },
                                        label = "Acepta recibir comunicaciones comerciales"
                                    )

                                    CustomCheckbox(
                                        checked = beca,
                                        onCheckedChange = { beca = it },
                                        label = "Aplica beca"
                                    )

                                    // Botón para enviar la solicitud
                                    Button(
                                        onClick = {
                                            Toast.makeText(
                                                context,
                                                "Servicio en desarrollo.",
                                                Toast.LENGTH_SHORT
                                            ).show()
                                            /*
                                            if (nombre.isNotEmpty()
                                                && ape1.isNotEmpty()
                                                && ape2.isNotEmpty()
                                                && dni.isNotEmpty()
                                                && direccion.isNotEmpty()
                                                && localidad.isNotEmpty()
                                                && email.isNotEmpty()
                                                && tlfn.isNotEmpty()) {

                                                if (isMinor) {
                                                    if (nombreTut.isNotEmpty()
                                                        && ape1Tut.isNotEmpty()
                                                        && ape2Tut.isNotEmpty()
                                                        && dniTut.isNotEmpty()
                                                        && direccionTut.isNotEmpty()
                                                        && localidadTut.isNotEmpty()
                                                        && emailTut.isNotEmpty()
                                                        && tlfnTut.isNotEmpty()) {

                                                        if(isValidDNI(dniTut)){
                                                            tutorViewModel.getTutorByDni(dniTut.toInt())

                                                            if(tutor != null) {
                                                                val gson = GsonBuilder()
                                                                    .registerTypeAdapter(LocalDate::class.java, LocalDateSerializer())
                                                                    .create()

// Convert the Solicitud object to JSON
                                                                val json = gson.toJson(fechaNac)
                                                                solicitud = Solicitud(
                                                                    nombre = nombre,
                                                                    apellido1 = ape1,
                                                                    apellido2 = ape2,
                                                                    dni = dni,
                                                                    fechaNac = json,
                                                                    direccion = direccion,
                                                                    localidad = localidad,
                                                                    email = email,
                                                                    telefono = tlfn,
                                                                    tutor = tutor!!,
                                                                    curso = Curso.curso!!,
                                                                    proteccionDatos = if (proteccionDatos) 1.toByte() else 0.toByte(),
                                                                    autorizacionFotos = if (autorizaFotos) 1.toByte() else 0.toByte(),
                                                                    grupoWhatsapp = if (whatsApp) 1.toByte() else 0.toByte(),
                                                                    comunicacionesComerciales = if (comComerciales) 1.toByte() else 0.toByte(),
                                                                    beca = if (beca) 1.toByte() else 0.toByte(),
                                                                    id = null,
                                                                    fecha = null
                                                                )

                                                                solicitudViewModel.saveSolicitud(solicitud!!)
                                                                Toast.makeText(
                                                                    context,
                                                                    "Solicitud enviada correctamente.",
                                                                    Toast.LENGTH_SHORT
                                                                ).show()
                                                                nav.navigate("home") {
                                                                    popUpTo("home") {
                                                                        inclusive = true
                                                                    }
                                                                }
                                                            } else run {
                                                                var nuevo = Tutor(
                                                                    id = null,
                                                                    nombre = nombreTut,
                                                                    apellido1 = ape1Tut,
                                                                    apellido2 = ape2Tut,
                                                                    dni = dniTut,
                                                                    direccion = direccionTut,
                                                                    localidad = localidadTut,
                                                                    email = emailTut,
                                                                    telefono = tlfnTut
                                                                )
                                                                if(tutorViewModel.saveTutor(nuevo!!)){
                                                                    tutorViewModel.getTutorByDni(dniTut.toInt())
                                                                    if(tutor != null) {
                                                                        val gson = GsonBuilder()
                                                                            .registerTypeAdapter(LocalDate::class.java, LocalDateSerializer())
                                                                            .create()

// Convert the Solicitud object to JSON
                                                                        val json = gson.toJson(fechaNac)
                                                                        solicitud = Solicitud(
                                                                            nombre = nombre,
                                                                            apellido1 = ape1,
                                                                            apellido2 = ape2,
                                                                            dni = dni,
                                                                            fechaNac = json,
                                                                            direccion = direccion,
                                                                            localidad = localidad,
                                                                            email = email,
                                                                            telefono = tlfn,
                                                                            tutor = tutor!!,
                                                                            curso = Curso.curso!!,
                                                                            proteccionDatos = if (proteccionDatos) 1.toByte() else 0.toByte(),
                                                                            autorizacionFotos = if (autorizaFotos) 1.toByte() else 0.toByte(),
                                                                            grupoWhatsapp = if (whatsApp) 1.toByte() else 0.toByte(),
                                                                            comunicacionesComerciales = if (comComerciales) 1.toByte() else 0.toByte(),
                                                                            beca = if (beca) 1.toByte() else 0.toByte(),
                                                                        )
                                                                        solicitudViewModel.saveSolicitud(
                                                                            solicitud!!
                                                                        )
                                                                        Toast.makeText(
                                                                            context,
                                                                            "Solicitud enviada correctamente.",
                                                                            Toast.LENGTH_SHORT
                                                                        ).show()
                                                                        nav.navigate("home") {
                                                                            popUpTo("home") {
                                                                                inclusive = true
                                                                            }
                                                                        }
                                                                    } else {
                                                                        errorMessage =
                                                                            "Error al guardar el tutor."
                                                                        showErrorDialog = true
                                                                    }
                                                                }

                                                            }
                                                        } else{
                                                            errorMessage = "DNI del tutor no válido."
                                                            showErrorDialog = true
                                                        }
                                                    } else {
                                                        errorMessage =
                                                            "Todos los campos del tutor son obligatorios para menores de edad."
                                                        showErrorDialog = true
                                                    }
                                                } else {
                                                    if (isValidDNI(dni)) {
                                                        if (isValidEmail(email)) {
                                                            if (isValidPhoneNumber(tlfn)) {

                                                                val gson = GsonBuilder()
                                                                    .registerTypeAdapter(LocalDate::class.java, LocalDateSerializer())
                                                                    .create()

// Convert the Solicitud object to JSON
                                                                val json = gson.toJson(fechaNac)

                                                                solicitud = Solicitud(
                                                                    nombre = nombre,
                                                                    apellido1 = ape1,
                                                                    apellido2 = ape2,
                                                                    dni = dni,
                                                                    fechaNac = json,
                                                                    direccion = direccion,
                                                                    localidad = localidad,
                                                                    email = email,
                                                                    telefono = tlfn,
                                                                    curso = Curso.curso!!,
                                                                    proteccionDatos = if (proteccionDatos) 1.toByte() else 0.toByte(),
                                                                    autorizacionFotos = if (autorizaFotos) 1.toByte() else 0.toByte(),
                                                                    grupoWhatsapp = if (whatsApp) 1.toByte() else 0.toByte(),
                                                                    comunicacionesComerciales = if (comComerciales) 1.toByte() else 0.toByte(),
                                                                    beca = if (beca) 1.toByte() else 0.toByte(),
                                                                )

// Create a Gson instance with the custom serializer



                                                                if (solicitudViewModel.saveSolicitud(
                                                                        solicitud!!
                                                                    )
                                                                ) {
                                                                    Toast.makeText(
                                                                        context,
                                                                        "Solicitud enviada correctamente.",
                                                                        Toast.LENGTH_SHORT
                                                                    ).show()
                                                                    nav.navigate("home") {
                                                                        popUpTo("home") {
                                                                            inclusive = true
                                                                        }
                                                                    }
                                                                } else {
                                                                    Toast.makeText(
                                                                        context,
                                                                        "Error al enviar la solicitud.",
                                                                        Toast.LENGTH_SHORT
                                                                    ).show()
                                                                }
                                                            } else {
                                                                errorMessage = "Teléfono no válido."
                                                                showErrorDialog = true
                                                            }
                                                        } else {
                                                            errorMessage = "Email no válidos."
                                                            showErrorDialog = true
                                                        }
                                                    } else {
                                                        errorMessage = "DNI no válido."
                                                        showErrorDialog = true
                                                    }
                                                }
                                                val gson = Gson()
                                                val json = gson.toJson(solicitud)

                                                // Mostrar el AlertDialog con el JSON
                                                showDialog = true
                                                jsonToShow = json
                                            } else {
                                                errorMessage = "Todos los campos son obligatorios."
                                                showErrorDialog = true
                                            }*/
                                        },
                                        modifier = Modifier
                                            .fillMaxWidth()
                                            .padding(top = 20.dp),  // Padding superior para el botón
                                        shape = RoundedCornerShape(50.dp)
                                    )
                                    {
                                        Text(
                                            text = "Enviar solicitud",
                                            fontSize = 20.sp,
                                            fontWeight = FontWeight.Bold
                                        )
                                    }

                                    ErrorDialog(
                                        showDialog = showErrorDialog,
                                        errorMessage = errorMessage,
                                        onDismiss = { showErrorDialog = false }
                                    )
                                }
                            }
                        }

                }
            }
        }
    }

    if (showDialog) {
        AlertDialog(
            onDismissRequest = { showDialog = false },
            title = { Text("JSON de la solicitud") },
            text = { Text(jsonToShow + "  --  " + fechaNac) },
            confirmButton = {
                Button(onClick = {
                    showDialog = false
                    solicitudViewModel.saveSolicitud(solicitud!!)
                    Toast.makeText(
                        context,
                        "Solicitud enviada correctamente.",
                        Toast.LENGTH_SHORT
                    ).show()
                    nav.navigate("home") {
                        popUpTo("home") { inclusive = true }
                    }
                }) {
                    Text("Enviar")
                }
            },
            dismissButton = {
                Button(onClick = { showDialog = false }) {
                    Text("Cancelar")
                }
            }
        )
    }

    BackHandler {
        nav.navigate("home") {
            popUpTo("home") { inclusive = true }
        }
    }
}



@Composable
fun CustomCheckbox(
    checked: Boolean,
    onCheckedChange: (Boolean) -> Unit,
    label: String
) {
    Row(
        modifier = Modifier
            .fillMaxWidth()
            .padding(vertical = 12.dp) // Uniform vertical margin
            .border(1.dp, Color.Gray, RoundedCornerShape(12.dp)) // Rounded borders
            .padding(16.dp) // Internal padding
    ) {
        Checkbox(
            checked = checked,
            onCheckedChange = onCheckedChange,
            modifier = Modifier.padding(end = 8.dp) // Space between checkbox and text
        )
        Text(
            text = label,
            fontSize = 16.sp,
            fontWeight = FontWeight.Normal,
            modifier = Modifier.align(Alignment.CenterVertically) // Center text vertically
        )
    }
}

@Composable
fun ErrorDialog(
    showDialog: Boolean,
    errorMessage: String,
    onDismiss: () -> Unit
) {
    if (showDialog) {
        AlertDialog(
            onDismissRequest = { onDismiss() },
            title = {
                Text(text = "Error", fontWeight = FontWeight.Bold)
            },
            text = {
                Text(text = errorMessage)
            },
            confirmButton = {
                Button(onClick = { onDismiss() }) {
                    Text(text = "OK")
                }
            }
        )
    }
}



// Función para calcular la edad
fun calculateAge(birthDate: String): Int {
    val formatter = SimpleDateFormat("dd/MM/yyyy", Locale.getDefault())
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


fun isValidDNI(dni: String): Boolean {
    val dniRegex = Regex("^[0-9]{8}[A-Za-z]$")
    if (!dniRegex.matches(dni)) return false

    val dniLetters = "TRWAGMYFPDXBNJZSQVHLCKE"
    val numberPart = dni.substring(0, 8).toIntOrNull() ?: return false
    val letterPart = dni.last().uppercaseChar()

    val correctLetter = dniLetters[numberPart % 23]
    return correctLetter == letterPart
}

fun isValidEmail(email: String): Boolean {
    val emailRegex = Regex("^[A-Za-z0-9+_.-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$")
    return emailRegex.matches(email)
}

fun isValidPhoneNumber(phoneNumber: String): Boolean {
    val phoneRegex = Regex("^[6-9][0-9]{8}$")
    return phoneRegex.matches(phoneNumber)
}

// Custom serializer for LocalDate
class LocalDateSerializer : JsonSerializer<LocalDate> {
    override fun serialize(src: LocalDate?, typeOfSrc: Type?, context: JsonSerializationContext?): JsonElement {
        return JsonPrimitive(src?.format(DateTimeFormatter.ISO_LOCAL_DATE)) // Directly formats as "yyyy-MM-dd"
    }
}

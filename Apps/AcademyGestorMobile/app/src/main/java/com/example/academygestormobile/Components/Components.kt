package com.example.academygestormobile.Components

import android.Manifest
import android.app.Activity
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.graphics.Bitmap
import android.net.Uri
import android.provider.MediaStore
import android.widget.Toast
import androidx.activity.ComponentActivity
import androidx.activity.compose.rememberLauncherForActivityResult
import androidx.activity.result.contract.ActivityResultContracts
import androidx.camera.core.CameraSelector
import androidx.camera.core.ImageCapture
import androidx.camera.core.ImageCaptureException
import androidx.camera.core.Preview
import androidx.camera.lifecycle.ProcessCameraProvider
import androidx.camera.view.PreviewView
import androidx.compose.foundation.Image
import androidx.compose.foundation.border
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.ExitToApp
import androidx.compose.material.icons.filled.KeyboardArrowLeft
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Button
import androidx.compose.material3.ExperimentalMaterial3Api
import androidx.compose.material3.Icon
import androidx.compose.material3.IconButton
import androidx.compose.material3.MaterialTheme.colorScheme
import androidx.compose.material3.NavigationBar
import androidx.compose.material3.NavigationBarItem
import androidx.compose.material3.NavigationBarItemDefaults
import androidx.compose.material3.Text
import androidx.compose.material3.TopAppBar
import androidx.compose.material3.TopAppBarDefaults
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.asImageBitmap
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.platform.LocalContext
import androidx.compose.ui.res.vectorResource
import androidx.compose.ui.unit.dp
import androidx.compose.ui.viewinterop.AndroidView
import androidx.compose.ui.window.Dialog
import androidx.compose.ui.window.DialogProperties
import androidx.core.content.ContextCompat
import androidx.navigation.NavController
import androidx.navigation.compose.currentBackStackEntryAsState
import coil.compose.rememberImagePainter
import com.example.academygestormobile.Navigation.ItemsNav
import com.example.academygestormobile.R
import java.io.File

@Composable
fun currentRoute(navController: NavController): String? =
    navController.currentBackStackEntryAsState().value?.destination?.route

@Composable
fun BottomAppBar(navController: NavController) {
    val bar_items = if (User.user != null) {
        listOf(
            ItemsNav.Item_bottom_nav_home,
            ItemsNav.Item_bottom_nav_profesor
        )
    } else {
        listOf(
            ItemsNav.Item_bottom_nav_home,
            ItemsNav.Item_bottom_nav_info,
            ItemsNav.Item_bottom_nav_contact
        )
    }
    NavigationBar(
        modifier = Modifier.height(70.dp),
        containerColor = colorScheme.primary,
        contentColor = Color.White
    ) {
        bar_items.forEach { item ->
            val clicked = currentRoute(navController) == item.ruta
            NavigationBarItem(
                selected = clicked,
                onClick = { navController.navigate(item.ruta) },
                {
                    Icon(
                        imageVector = ImageVector.vectorResource(id = item.icono),
                        contentDescription = null
                    )
                },
                colors = NavigationBarItemDefaults.colors(
                    selectedIconColor = Color.Gray, // Color del ícono seleccionado
                    unselectedIconColor = Color.White // Color del ícono no seleccionado
                )
            )
        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun TopAppBar(navController: NavController) {
    var showDialog by remember { mutableStateOf(false) }

    TopAppBar(
        modifier = Modifier.height(80.dp),
        title = {
            /*Icon(
               painter = painterResource(R.drawable.logowhite), // Asegúrate de tener un logo blanco en res/drawable
                contentDescription = "Logo",
                modifier = Modifier
                    .padding(8.dp)
                    .size(250.dp), // Ajusta el tamaño según sea necesario
                tint = Color.Unspecified // Asegúrate de que el color no se sobreescriba
            )*/
        },
        actions = {
            if (User.user != null) {
                // Mostrar el botón de añadir publicación solo si el usuario está autenticado
                IconButton(onClick = {
                    navController.navigate("newpost")
                }) {
                    Icon(
                        imageVector = ImageVector.vectorResource(id = R.drawable.new_post),
                        contentDescription = "añadir publicacion"
                    )
                }
            }
        },
        navigationIcon = {
            IconButton(onClick = {
                if (User.user != null) {
                    showDialog = true
                } else {
                    navController.navigate("loggin")
                }
            }) {
                Icon(
                    imageVector = Icons.Default.ExitToApp,
                    contentDescription = "Loggin",
                    tint = Color.White
                )
            }
        },
        colors = TopAppBarDefaults.smallTopAppBarColors(
            containerColor = colorScheme.primary,
            titleContentColor = colorScheme.onPrimary,
            actionIconContentColor = colorScheme.onPrimary
        ),
    )
    if (showDialog) {
        AlertDialog(
            onDismissRequest = { showDialog = false },
            title = { Text(text = "Cerrar sesión") },
            text = { Text(text = "¿Estás seguro de que deseas cerrar sesión?") },
            confirmButton = {
                Button(onClick = {
                    User.user = null
                    showDialog = false
                    navController.navigate("loggin") {
                        popUpTo(navController.graph.startDestinationId) { inclusive = true }
                    }
                }) {
                    Text("Sí")
                }
            },
            dismissButton = {
                Button(onClick = { showDialog = false }) {
                    Text("No")
                }
            }
        )
    }
}

@Composable
fun imagePicker(context: Context) {
    var imageUri by remember { mutableStateOf<Uri?>(null) }
    var bitmap by remember { mutableStateOf<Bitmap?>(null) }
    var showDialog by remember { mutableStateOf(false) }

    // Launcher para seleccionar imagen desde la galería
    val galleryLauncher = rememberLauncherForActivityResult(
        contract = ActivityResultContracts.GetContent()
    ) { uri: Uri? ->
        imageUri = uri
    }

    var showOptionsDialog by remember { mutableStateOf(false) }

    Box(
        modifier = Modifier
            .fillMaxWidth()
            .height(250.dp)
            .padding(vertical = 12.dp)
            .border(1.dp, Color.Gray, RoundedCornerShape(12.dp))
    ) {
        if (bitmap != null) {
            Image(
                bitmap = bitmap!!.asImageBitmap(),
                contentDescription = "Selected Image",
                modifier = Modifier.fillMaxWidth().clickable { showOptionsDialog = true }
            )
        } else if (imageUri != null) {
            Image(
                painter = rememberImagePainter(data = imageUri),
                contentDescription = "Selected Image",
                modifier = Modifier.fillMaxWidth().clickable { showOptionsDialog = true }
            )
        } else {
            IconButton(
                onClick = { showDialog = true },
                modifier = Modifier.align(Alignment.Center)
            ) {
                Icon(
                    imageVector = ImageVector.vectorResource(id = R.drawable.add_photo_24),
                    contentDescription = "Add Image",
                    tint = Color.Gray,
                    modifier = Modifier.size(50.dp)
                )
            }
        }
    }

    if (showDialog) {
        AlertDialog(
            onDismissRequest = { showDialog = false },
            title = { Text("Seleccionar imagen") },
            text = { Text("Elige una opción para añadir una imagen.") },
            confirmButton = {
                Button(onClick = {
                    showDialog = false

                    galleryLauncher.launch("image/*")
                }) {
                    Text("Galería")
                }
            },
            dismissButton = {
                Button(onClick = {
                    Toast.makeText(
                        context,
                        "Servicio en deasrrollo",
                        Toast.LENGTH_SHORT
                    ).show()
                }) {
                    Text("Cámara")
                }
            }
        )
    }

    if (showOptionsDialog) {
        AlertDialog(
            onDismissRequest = { showOptionsDialog = false },
            title = { Text("Opciones de imagen") },
            text = { Text("¿Qué deseas hacer con la imagen?") },
            confirmButton = {
                Button(onClick = {
                    showOptionsDialog = false
                    galleryLauncher.launch("image/*") // Seleccionar nueva imagen
                }) {
                    Text("Seleccionar nueva")
                }
            },
            dismissButton = {
                Button(onClick = {
                    showOptionsDialog = false
                    imageUri = null
                    bitmap = null // Eliminar la imagen actual
                }) {
                    Text("Eliminar")
                }
            }
        )
    }
}




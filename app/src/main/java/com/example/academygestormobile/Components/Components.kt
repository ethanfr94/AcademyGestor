package com.example.academygestormobile.Components

import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
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
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.compose.ui.res.vectorResource
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import androidx.navigation.compose.currentBackStackEntryAsState
import com.example.academygestormobile.Navigation.ItemsNav
import com.example.academygestormobile.R

@Composable
fun currentRoute(navController: NavController): String? =
    navController.currentBackStackEntryAsState().value?.destination?.route

@Composable
fun BottomAppBar(navController: NavController) {
    val bar_items = if (User.currentUser) {
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
        modifier = Modifier.height(65.dp),
        containerColor = colorScheme.primary,
        contentColor = Color.White
    ) {
        bar_items.forEach { item ->
            val clicked = currentRoute(navController) == item.ruta
            NavigationBarItem(
                selected = clicked,
                onClick = { navController.navigate(item.ruta) },
                icon = { Icon(imageVector = item.icono, contentDescription = null) },
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
        modifier = Modifier.height(60.dp),
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
            if (User.currentUser) {
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
                if (User.currentUser) {
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
                    User.currentUser = false
                    showDialog = false
                    navController.navigate("loggin")
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
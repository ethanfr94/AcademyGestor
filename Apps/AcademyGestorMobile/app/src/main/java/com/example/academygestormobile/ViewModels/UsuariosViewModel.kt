package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Usuario
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch

class UsuariosViewModel():ViewModel() {

    private val _usuario = MutableLiveData<Usuario?>()
    val usuario: LiveData<Usuario?> = _usuario

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getUsuario(user: String, pass: String) {
        viewModelScope.launch {
            try {
                val usuarioResponse = serv.getUsuarioByLogin(user, pass)
                _usuario.value = usuarioResponse
                Log.d("Usuario", "Received: $usuarioResponse")
            } catch (e: Exception) {
                Log.d("Usuario", "$e")
                e.printStackTrace()
            }
        }
    }

    fun updateUsuario(usuario: Usuario) {
        CoroutineScope(Dispatchers.IO).launch {
            try {
                serv.updateUsuario(usuario.id!!, usuario)
                _usuario.postValue(usuario)

                Log.d("Usuario", "Updated usuario: $usuario")
            } catch (e: Exception) {
                Log.d("Usuario", "$e")
                e.printStackTrace()
            }
        }
    }

    fun resetUsuario() {
        _usuario.value = null
    }
}
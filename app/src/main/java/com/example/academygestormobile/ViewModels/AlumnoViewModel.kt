package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Alumno
import kotlinx.coroutines.launch

class AlumnoViewModel: ViewModel() {
    private val _alumno = MutableLiveData<Alumno>()
    val alumno: MutableLiveData<Alumno> = _alumno
    private val _alumnos = MutableLiveData<List<Alumno>>()
    val alumnos: MutableLiveData<List<Alumno>> = _alumnos

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getAlumnos() {
        viewModelScope.launch {
            try {
                val alumnosList = serv.getAlumnos()
                _alumnos.value = alumnosList
                Log.d("Alumnos", "Received list: $alumnosList")
            } catch (e: Exception) {
                Log.d("Alumnos", "$e")
                e.printStackTrace()
            }
        }
    }
}
package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Curso
import kotlinx.coroutines.launch

class CursosViewModel: ViewModel() {

    private val _curso = MutableLiveData<Curso>()
    val curso: LiveData<Curso> = _curso
    private val _cursos = MutableLiveData<List<Curso>>()
    val cursos: LiveData<List<Curso>> = _cursos

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getCursos() {
        viewModelScope.launch {
            try {
                val cursosList = serv.getCursos()
                _cursos.value = cursosList
                Log.d("Cursos", "Received list: $cursosList")
            } catch (e: Exception) {
                Log.d("Cursos", "$e")
                e.printStackTrace()
            }
        }
    }

}
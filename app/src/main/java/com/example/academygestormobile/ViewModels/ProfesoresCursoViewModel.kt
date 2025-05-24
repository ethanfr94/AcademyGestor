package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Profesor_Curso
import kotlinx.coroutines.launch

class ProfesoresCursoViewModel: ViewModel() {
    private val _item = MutableLiveData<Profesor_Curso>()
    val item: MutableLiveData<Profesor_Curso> = _item
    private val _items = MutableLiveData<List<Profesor_Curso>>()
    val items: MutableLiveData<List<Profesor_Curso>> = _items

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getProfesoresCursos() {
        viewModelScope.launch {
            try {
                val itemList = serv.getProfCurso()
                _items.value = itemList
                Log.d("Profesor_Curso", "Received list: $itemList")
            } catch (e: Exception) {
                Log.d("Profesor_Curso", "$e")
                e.printStackTrace()
            }
        }
    }
}
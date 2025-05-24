package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Matricula
import kotlinx.coroutines.launch

class MatriculasViewModel: ViewModel() {
    private val _matricula = MutableLiveData<Matricula>()
    val matricula: MutableLiveData<Matricula> = _matricula
    private val _matriculas = MutableLiveData<List<Matricula>>()
    val matriculas: MutableLiveData<List<Matricula>> = _matriculas

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getMatriculas() {
        viewModelScope.launch {
            try {
                val matriculasList = serv.getMatriculas()
                _matriculas.value = matriculasList
                Log.d("Matriculas", "Received list: $matriculasList")
            } catch (e: Exception) {
                Log.d("Matriculas", "$e")
                e.printStackTrace()
            }
        }
    }

    fun saveMatricula(matricula: Matricula) {
        viewModelScope.launch {
            try {
                val resp = serv.postMatricula(matricula)
                if(resp.isSuccessful){
                    getMatriculas()
                    val savedMatricula = resp.body()
                }else{
                    Log.d("Matriculas", "Error: ${resp.code()} - ${resp.message()}")
                }
            }catch (e: Exception){
                Log.d("Matriculas", "$e")
                e.printStackTrace()
            }
        }
    }
}
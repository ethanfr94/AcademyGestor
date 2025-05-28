package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Matricula
import com.example.academygestormobile.Models.Tutor
import kotlinx.coroutines.launch

class TutorViewModel: ViewModel() {
    private val _tutor = MutableLiveData<Tutor>()
    val tutor: MutableLiveData<Tutor> = _tutor
    private val _tutores = MutableLiveData<List<Tutor>>()
    val tutores: MutableLiveData<List<Tutor>> = _tutores

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getTutores() {
        viewModelScope.launch {
            try {
                val tutoresList = serv.getTutores()
                _tutores.value = tutoresList
                Log.d("Tutores", "Received list: $tutoresList")
            } catch (e: Exception) {
                Log.d("Tutores", "$e")
                e.printStackTrace()
            }
        }
    }

    fun saveTutor(tutor: Tutor) {
        viewModelScope.launch {
            try {
                val resp = serv.postTutor(tutor)
                if(resp.isSuccessful){
                    getTutores()
                    val savedTutor = resp.body()
                }else{
                    Log.d("Tutores", "Error: ${resp.code()} - ${resp.message()}")
                }
            }catch (e: Exception){
                Log.d("Tutores", "$e")
                e.printStackTrace()
            }
        }
    }
}
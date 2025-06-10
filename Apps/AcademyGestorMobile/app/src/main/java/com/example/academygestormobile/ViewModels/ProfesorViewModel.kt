package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Profesor
import kotlinx.coroutines.launch

class ProfesorViewModel(): ViewModel() {
    private val _profesor = MutableLiveData<Profesor?>()
    val profesor: LiveData<Profesor?> = _profesor

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getProfesorByEmail(email: String) {
        viewModelScope.launch {
            try {
                val ProfesorResponse = serv.getProfesorByEmail(email)
                _profesor.value = ProfesorResponse
                Log.d("Profesor", "Received: $ProfesorResponse")
            } catch (e: Exception) {
                Log.d("Profesor", "$e")
                e.printStackTrace()
            }
        }
    }
}
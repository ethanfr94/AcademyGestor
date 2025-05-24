package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Empresa
import kotlinx.coroutines.launch

class EmpresaViewModel: ViewModel() {
    private val _empresa = MutableLiveData<Empresa>()
    val empresa: LiveData<Empresa> = _empresa

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getEmpresa() {
        viewModelScope.launch {
            try {
                val empresa = serv.getEmpresa()
                _empresa.value = empresa
                Log.d("Empresa", "Received list: $empresa")
            } catch (e: Exception) {
                Log.d("Empresa", "$e")
                e.printStackTrace()
            }
        }
    }
}
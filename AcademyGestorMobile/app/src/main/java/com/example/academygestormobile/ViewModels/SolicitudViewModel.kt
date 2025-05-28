package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Falta_Asistencia
import com.example.academygestormobile.Models.Solicitud
import kotlinx.coroutines.launch

class SolicitudViewModel: ViewModel() {
    private val _item = MutableLiveData<Solicitud>()
    val item: MutableLiveData<Solicitud> = _item
    private val _items = MutableLiveData<List<Solicitud>>()
    val items: MutableLiveData<List<Solicitud>> = _items

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getSolicitudes() {
        viewModelScope.launch {
            try {
                val itemList = serv.getSolicitudes()
                _items.value = itemList
                Log.d("Solicitud", "Received list: $itemList")
            } catch (e: Exception) {
                Log.d("Solicitud", "$e")
                e.printStackTrace()
            }
        }
    }

    fun saveSolicitud(solicitud: Solicitud) {
        viewModelScope.launch {
            try {
                val resp = serv.postSolicitud(solicitud)
                if (resp.isSuccessful) {
                    getSolicitudes()
                    val savedItem = resp.body()
                } else {
                    Log.d("Solicitud", "Error: ${resp.code()} - ${resp.message()}")
                }
            } catch (e: Exception) {
                Log.d("Solicitud", "$e")
                e.printStackTrace()
            }
        }
    }
}
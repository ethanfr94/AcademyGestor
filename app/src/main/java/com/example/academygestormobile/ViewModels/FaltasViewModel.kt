package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Falta_Asistencia
import kotlinx.coroutines.launch

class FaltasViewModel: ViewModel() {
    private val _item = MutableLiveData<Falta_Asistencia>()
    val item: MutableLiveData<Falta_Asistencia> = _item
    private val _items = MutableLiveData<List<Falta_Asistencia>>()
    val items: MutableLiveData<List<Falta_Asistencia>> = _items

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getFaltas() {
        viewModelScope.launch {
            try {
                val itemList = serv.getFaltas()
                _items.value = itemList
                Log.d("Falta_Asistencia", "Received list: $itemList")
            } catch (e: Exception) {
                Log.d("Falta_Asistencia", "$e")
                e.printStackTrace()
            }
        }
    }

    fun saveFalta(falta: Falta_Asistencia) {
        viewModelScope.launch {
            try {
                val resp = serv.postFalta(falta)
                if (resp.isSuccessful) {
                    getFaltas()
                    val savedItem = resp.body()
                } else {
                    Log.d("Falta_Asistencia", "Error: ${resp.code()} - ${resp.message()}")
                }
            } catch (e: Exception) {
                Log.d("Falta_Asistencia", "$e")
                e.printStackTrace()
            }
        }
    }
}
package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Publicacion
import com.example.academygestormobile.Models.Tutor
import kotlinx.coroutines.launch

class PublicacionViewModel: ViewModel() {
    private val _item = MutableLiveData<Publicacion>()
    val item: MutableLiveData<Publicacion> = _item
    private val _items = MutableLiveData<List<Publicacion>>()
    val items: MutableLiveData<List<Publicacion>> = _items

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getPublicaciones() {
        viewModelScope.launch {
            try {
                val itemList = serv.getPublicaciones()
                _items.value = itemList
                Log.d("Publicacion", "Received list: $itemList")
            } catch (e: Exception) {
                Log.d("Publicacion", "$e")
                e.printStackTrace()
            }
        }
    }

    fun savePublicacion(publicacion: Publicacion) {
        viewModelScope.launch {
            try {
                val resp = serv.postPublicacion(publicacion)
                if (resp.isSuccessful) {
                    getPublicaciones()
                    val savedItem = resp.body()
                } else {
                    Log.d("Publicacion", "Error: ${resp.code()} - ${resp.message()}")
                }
            } catch (e: Exception) {
                Log.d("Publicacion", "$e")
                e.printStackTrace()
            }
        }
    }
}
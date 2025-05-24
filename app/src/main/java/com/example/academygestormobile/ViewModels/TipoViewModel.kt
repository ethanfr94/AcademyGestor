package com.example.academygestormobile.ViewModels

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.example.academygestormobile.API.RetrofitServiceFactory
import com.example.academygestormobile.Models.Tipo
import kotlinx.coroutines.launch

class TipoViewModel: ViewModel() {
    private val _item = MutableLiveData<Tipo>()
    val item: MutableLiveData<Tipo> = _item
    private val _items = MutableLiveData<List<Tipo>>()
    val items: MutableLiveData<List<Tipo>> = _items

    private val serv = RetrofitServiceFactory.makeRetrofitService()

    fun getTipos() {
        viewModelScope.launch {
            try {
                val itemList = serv.getTipos()
                _items.value = itemList
                Log.d("Tipo", "Received list: $itemList")
            } catch (e: Exception) {
                Log.d("Tipo", "$e")
                e.printStackTrace()
            }
        }
    }
}
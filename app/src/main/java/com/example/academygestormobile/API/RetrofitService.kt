package com.example.academygestormobile.API

import com.example.academygestormobile.Models.Alumno
import com.example.academygestormobile.Models.Curso
import com.example.academygestormobile.Models.Empresa
import com.example.academygestormobile.Models.Falta_Asistencia
import com.example.academygestormobile.Models.Matricula
import com.example.academygestormobile.Models.Profesor_Curso
import com.example.academygestormobile.Models.Publicacion
import com.example.academygestormobile.Models.Solicitud
import com.example.academygestormobile.Models.Tipo
import com.example.academygestormobile.Models.Tutor
import com.example.academygestormobile.Models.Usuario
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.PUT
import retrofit2.http.Path

interface RetrofitService {

    // GET

    @GET("cursos")
    suspend fun getCursos(): List<Curso>


    @GET("usuarios")
    suspend fun getUsuarios(): List<Usuario>


    @GET("empresa")
    suspend fun getEmpresa(): Empresa


    @GET("matriculas")
    suspend fun getMatriculas(): List<Matricula>


    @GET("alumnos")
    suspend fun getAlumnos(): List<Alumno>


    @GET("tutores")
    suspend fun getTutores(): List<Tutor>


    @GET("profesoresCurso")
    suspend fun getProfCurso(): List<Profesor_Curso>


    @GET("publicaciones")
    suspend fun getPublicaciones(): List<Publicacion>


    @GET("tipos")
    suspend fun getTipos(): List<Tipo>


    @GET("faltas_asistencia")
    suspend fun getFaltas(): List<Falta_Asistencia>


    @GET("solicitudes")
    suspend fun getSolicitudes(): List<Solicitud>

    // POST

    @POST("faltas_asistencia/insertar")
    suspend fun postFalta(@Body faltaAsistencia: Falta_Asistencia): Response<Falta_Asistencia>

    @POST("publicaciones/insertar")
    suspend fun postPublicacion(@Body publicacion: Publicacion): Response<Publicacion>

    @POST("solicitudes/insertar")
    suspend fun postSolicitud(@Body solicitud: Solicitud): Response<Solicitud>

    @POST("tutores/insertar")
    suspend fun postTutor(@Body tutor: Tutor): Response<Tutor>

    @POST("matriculas/insertar")
    suspend fun postMatricula(@Body matricula: Matricula): Response<Matricula>

    // PUT

    @PUT("usuarios/modificar//{id}")
    suspend fun updateUsuario(
        @Path("id") id: Int?,
        @Body usuario: Usuario
    ): Usuario


}

object RetrofitServiceFactory {

    fun makeRetrofitService(): RetrofitService {
        return Retrofit.Builder()
            .baseUrl("http://192.168.1.133:8080/escuela_circo/")
            .addConverterFactory(GsonConverterFactory.create())
            .build().create(RetrofitService::class.java)
    }

}
abstract class BaseRepository {
    string baseUrl;


// protected R getBodyOrThrow<R>(IHttpHandler call)  where R : class {
//      try {
//             var response = call.execute()
//             if (response.isSuccessful) return response.body()
//             if (response.code() == 401) {
//                 throw AuthenticationException()
//             }
//             throw HttpException(response.code(), response.message())
//         } catch (e: IOException) {
//             e.printStackTrace()
//             throw InternetConnectionException()
//         }
//     }

//     abstract fun getService(interceptors: List<Interceptor> = emptyList()): PokedexAPI

//     internal fun dumbRequest() {
//         getBodyOrThrow(getService().dumbRequest())
//     }
}
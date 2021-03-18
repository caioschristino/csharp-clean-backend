using System.Threading.Tasks;
using System.Net.Http;

namespace clean_sharp
{
    public abstract class BaseRepository
    {
        public R getBodyOrThrow<R>(Task<R> call)
           where R : class
        {
            try
            {
                var response = execute(call);
                if (response.IsCompletedSuccessfully)
                {
                    return response.Result;
                }
                else
                {
                    throw new AuthenticationException();
                }

                // if (response.StatusCode == 401) {
                //     throw AuthenticationException()
                // }
                // throw HttpException(response.code(), response.message())
            }
            catch (System.Exception)
            {
                throw new InternetConnectionException();
            }
        }
        public abstract PokedexAPI getService();

        private async Task<R> execute<R>(Task<R> call)
            where R : class
        {
            return await call;
        }
    }
}
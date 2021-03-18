using System.Threading.Tasks;
using Refit;

namespace clean_sharp {
    public interface PokedexAPI
    {
        [Get("/pokemon")]
        Task<Landing> fetch();
    }
}
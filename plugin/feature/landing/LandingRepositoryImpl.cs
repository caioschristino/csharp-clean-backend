using System.Collections.Generic;

namespace clean_sharp
{
    class LandingRepositoryImpl : LandingRepository
    {
        public Landing doFetch()
        {
            List<Pokemon> pokemon = new List<Pokemon>();
            pokemon.Add(new Pokemon("1", "Teste 1"));
            pokemon.Add(new Pokemon("2", "Teste 2"));
            pokemon.Add(new Pokemon("3", "Teste 3"));
            pokemon.Add(new Pokemon("4", "Teste 4"));

            return new Landing(1, "TEST", pokemon);
        }
    }
}
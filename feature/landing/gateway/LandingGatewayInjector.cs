

namespace clean_sharp {
    public sealed class LandingGatewayInjector
    {
        static LandingGatewayInjector _instancia;
        public static LandingGatewayInjector Instancia
        {
            get { return _instancia ?? (_instancia = new LandingGatewayInjector()); }
        }

        private LandingGatewayInjector() { }
        public LandingUseCase fetch;
    }
}
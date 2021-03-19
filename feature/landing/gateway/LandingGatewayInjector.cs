

namespace clean_sharp {
    public sealed class LandingGatewayInjector
    {
        static LandingGatewayInjector _self;
        public static LandingGatewayInjector Self
        {
            get { return _self ?? (_self = new LandingGatewayInjector()); }
        }

        private LandingGatewayInjector() { }
        public LandingUseCase fetch;
    }
}
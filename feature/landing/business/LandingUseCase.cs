namespace clean_sharp {
    public class LandingUseCase : UseCase<Void, Landing>
    {
        LandingRepository repo { get; set; }

        public LandingUseCase(LandingRepository repo) : base() {
            this.repo = repo;
        }

        public override Output<Landing> execute(Void param)
        {
            var landing = repo.doFetch();
            return new ValueOutput<Landing>(landing);
        }
    }
}

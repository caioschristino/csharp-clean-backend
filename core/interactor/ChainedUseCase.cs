using System;

namespace clean_sharp {
    public class ChainedUseCase<P, R, T> : UseCase<P, T> where P:class where R:class where T:class
    {
        public UseCase<P, R> first { get; set; }
        public UseCase<R, T> second { get; set; }
        public override Output<T> execute(P param)
        {
            var intermediate = first.execute(param);
            if (intermediate.isSuccess()) {
                return second.execute(intermediate.value);
            }
            return new ErrorOutput<T>(intermediate.error);
        }
    }
}
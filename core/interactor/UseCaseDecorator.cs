using System;

namespace clean_sharp {
    public abstract class UseCaseDecorator<P, R> : UseCase<P, R>
        where R : class
        where P : class
    {   
        public UseCase<P, R> useCase { get; set; }

        public override Output<R> execute(P param)
        {
            return useCase.execute(param);
        }

        public override bool guard(P param)
        {
            return useCase.guard(param);
        }

        public override void onResult(Output<R> output)
        {
            useCase.onResult(output);
        }

        public override void onError(Exception exception)
        {
            useCase.onError(exception);
        }
    }
}
using System;

namespace clean_sharp {
    public class CallbackDecorator<P,R> : UseCaseDecorator<P,R>
            where P : class
            where R : class {
        public Action<Output<R>> callback { get; set; }

        public CallbackDecorator(UseCase<P,R> useCase, Action<Output<R>> callback){
            this.useCase = useCase;
            this.callback = callback;
        }

        public override void onResult(Output<R> output)
        {
            base.onResult(output);
            callback.Invoke(output);
        }

        public override void onError(Exception error)
        {
            base.onError(error);
            callback.Invoke(new ErrorOutput<R>(error));
        }
    }
}
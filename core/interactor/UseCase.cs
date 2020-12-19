using System;

namespace clean_sharp {
    public abstract class UseCase<P, R> 
        where P: class 
        where R:class 
    {
        public virtual void process(P param){
            try
            {
                if (guard(param)) {
                    var execution = execute(param);
                    onResult(execution);
                }   
            }
            catch (Exception error)
            {
                onError(error);
            }
        }

        public abstract Output<R> execute(P param);

        public virtual void onError(Exception error){
            var output = new ErrorOutput<R>(error);
            onResult(output);
        }

        public virtual void onResult(Output<R> output) {
        }

        public virtual bool guard(P param){
            return true;
        }
    }
}
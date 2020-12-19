
namespace clean_sharp {
    public class UseCaseUnit<P, R> 
        where R : class
        where P : class
    {
        UseCase<P, R> useCase { get; set; }
        P param { get; set; }

        public Output<R> process(){
            var callback = new Callback();
            var decorator = new CallbackDecorator<P, R>(useCase, callback.set);
            decorator.process(param);
            return callback.output;
        }

        public class Callback {
            public Output<R> output { get; set; }

            public void set(Output<R> output){
                this.output = new ValueOutput<R>(output.value);
            }
        }
    }
}
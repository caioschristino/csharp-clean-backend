using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace clean_sharp {
    public class UseCaseDispatcher <P,R> 
        where R : class
        where P : class
    {
        DispatcherDecorator<P,R> decorator { get; set; }
        
        public UseCaseDispatcher(UseCaseDecorator<P,R> decorator){
            var executeOn = Dispatcher.CreateDefault();
            var resultOn = Dispatcher.CreateDefault();
            this.decorator = new DispatcherDecorator<P, R>(decorator.useCase, executeOn, resultOn);
        }

        public Task dispatch(P param){
            return decorator.dispatch(param);
        }
    }
    internal class DispatcherDecorator <P,R> : UseCaseDecorator<P,R>
                where R : class
                where P : class{
        Dispatcher executeOn { get; set; }
        Dispatcher resultOn { get; set; }

        public DispatcherDecorator(UseCase<P, R> useCase, Dispatcher executeOn, Dispatcher resultOn) {
            this.useCase = useCase;
            this.executeOn = executeOn;
            this.resultOn = resultOn;
        }

        public Task dispatch(P param){
            Action doWorkAction = new Action(delegate{ process(param); });
            return executeOn.InvokeAsync(doWorkAction);
        }

        public override void onResult(Output<R> output)
        {
            Action doWorkAction = new Action(delegate{ useCase.onResult(output); });
            resultOn.InvokeAsync(doWorkAction);    
        }
        
        public override void onError(Exception exception)
        {
            Action doWorkAction = new Action(delegate{ useCase.onError(exception); });
            resultOn.InvokeAsync(doWorkAction);
        }
    }
}
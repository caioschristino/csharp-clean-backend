using System;
using Microsoft.AspNetCore.Mvc;

namespace clean_sharp
{
    public abstract class BaseController : ControllerBase {
        CompositeJobDisposable compositeJobDisposable { get; set; }

        public IDisposable dispatchUseCase<P, R>(P param,UseCase<P, R> useCase, Action<Output<R>> listener)  
            where R : class
            where P : class
        {
            var dispatcher = new UseCaseDispatcher<P, R>(new CallbackDecorator<P, R>(useCase, listener));
            var job = dispatcher.dispatch(param);
            compositeJobDisposable.add(job);
            
            return job;
        }
        
       public Output<R> processUseCase<P, R>(P param, UseCase<P, R> useCase)
            where R : class
            where P : class
        {
            var callback = new UseCaseUnit<P,R>.Callback();
            new CallbackDecorator<P, R>(useCase, callback.set).process(param);

            return callback.output;
        }
    }
}
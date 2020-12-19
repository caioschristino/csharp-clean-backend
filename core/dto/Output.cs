using System;


namespace clean_sharp {
    public abstract class Output<R> where R : class {
        public R value { get; set; }
        public Exception error { get; set; }

        public Output(R value, Exception error){
            this.value = value;
            this.error = error;
        }

        public bool isSuccess() {
            return !isError();
        }

        public virtual bool isError() {
            return error!= null; 
        }
        
        public bool isEmpty() {
            return value != null;
        }
    }
}
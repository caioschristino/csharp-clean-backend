using System;
using System.Threading.Tasks;

namespace clean_sharp
{
    public class CompositeJobDisposable : IDisposable
    {
        Task job { get; set; }

        public void Dispose() {
            job.Dispose();
        }
        
        public void add(Task job) {
            this.job = job;
        }
    }
}
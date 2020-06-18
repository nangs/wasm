using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.JSInterop;

using Shiny.Jobs;


namespace Shiny.Wasm.Jobs
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Background_Tasks_API
        // foreground jobs could use web workers
    public class JobManager : IJobManager
    {
        readonly IJSInProcessRuntime interop;
        public JobManager(IJSInProcessRuntime interop) => this.interop = interop;


        public bool IsRunning => throw new NotImplementedException();

        public IObservable<JobInfo> JobStarted => throw new NotImplementedException();

        public IObservable<JobRunResult> JobFinished => throw new NotImplementedException();

        public Task Cancel(string jobName)
        {
            throw new NotImplementedException();
        }

        public Task CancelAll()
        {
            throw new NotImplementedException();
        }

        public Task<JobInfo?> GetJob(string jobIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobInfo>> GetJobs()
        {
            throw new NotImplementedException();
        }

        public Task<AccessState> RequestAccess()
        {
            throw new NotImplementedException();
        }

        public Task<JobRunResult> Run(string jobIdentifier, CancellationToken cancelToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobRunResult>> RunAll(CancellationToken cancelToken = default, bool runSequentially = false)
        {
            throw new NotImplementedException();
        }

        public void RunTask(string taskName, Func<CancellationToken, Task> task)
        {
            throw new NotImplementedException();
        }

        public Task Schedule(JobInfo jobInfo)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppEvaTec.Helpers
{
    public sealed class FicAsyncLock
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly Task<IDisposable> _releaser;

        public FicAsyncLock()
        {
            _releaser = Task.FromResult((IDisposable)new Releaser(this));
        }

        public Task<IDisposable> LockAsync()
        {
            var wait = _semaphore.WaitAsync();
            return wait.IsCompleted ?
                _releaser :
                wait.ContinueWith((_, state) => (IDisposable)state,
                _releaser.Result, CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
        }

        private sealed class Releaser : IDisposable
        {
            private readonly FicAsyncLock m_toRelease;

            internal Releaser(FicAsyncLock toRelease)
            {
                m_toRelease = toRelease;
            }

            public void Dispose()
            {
                m_toRelease._semaphore.Release();
            }
        }
    }
}

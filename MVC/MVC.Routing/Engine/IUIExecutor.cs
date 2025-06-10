using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace MVC.Routing.Engine
{
    public interface IUIExecutor
    {
        Task<T> Execute<T>(Func<T> producer);
    }

    public class UIExecutor : IUIExecutor
    {
        private readonly SynchronizationContext _uiContext;

        public UIExecutor([NotNull] SynchronizationContext uiContext)
        {
            _uiContext = uiContext ?? throw new ArgumentNullException(nameof(uiContext));
        }

        public Task<T> Execute<T>(Func<T> producer)
        {
            var source = new TaskCompletionSource<T>();
            _uiContext.Post(_ => source.TrySetResult(producer()), null);
            return source.Task;
        }
    }
}
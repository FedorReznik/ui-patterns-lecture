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

    public interface IUIContextHolder
    {
        void SetContext(SynchronizationContext context);
    }

    public class UIExecutor : IUIExecutor, IUIContextHolder
    {
        private SynchronizationContext _uiContext;

        public Task<T> Execute<T>(Func<T> producer)
        {
            var source = new TaskCompletionSource<T>();
            _uiContext.Post(_ => source.TrySetResult(producer()), null);
            return source.Task;
        }

        public void SetContext([NotNull] SynchronizationContext context)
        {
            if(_uiContext != null) throw new InvalidOperationException("UIContext is already set");
            
            _uiContext = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AssetManagementApp.Data
{
    /// <summary>
    /// reference link https://devblogs.microsoft.com/pfxteam/asynclazyt/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncLazy<T>
    {
        readonly Lazy<Task<T>> instance;

        public AsyncLazy(Func<T> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public AsyncLazy(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }
    }
}

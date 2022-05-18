using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LocalStorageDb.Utilities
{
    public class AzyncLazy<T>
    {
        readonly Lazy<Task<T>> instance;


        public AzyncLazy(Func<Task<T>> factory)
        {
            instance = new Lazy<Task<T>>(() => Task.Run(factory));
        }
        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();

        }

        public void Start()
        {
            var unused = instance.Value;
        }

    }
}

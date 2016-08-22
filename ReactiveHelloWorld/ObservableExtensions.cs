using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveHelloWorld
{
    public static class ObservableExtensions
    {
        public static void DisposeWith(this IDisposable disposable, CompositeDisposable bag)
        {
            bag.Add(disposable);
        }
    }
}

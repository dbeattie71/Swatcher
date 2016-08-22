using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using MizzellConsulting.Swatcher;

namespace ReactiveHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Reactive Hello World";
            Console.WriteLine("Starting up Swatcher...");
            
            var disposables = new CompositeDisposable();
            var config = CreateConfiguration();
            var swatcher = new ObservableSwatcher(config);
            swatcher.Start();

            swatcher.Changed.Subscribe(x =>
            {
                Console.WriteLine(
                    $"[Changed] Id:{x.SwatcherId ?? 0}, Name: {x.Name}, ChangeType: {x.ChangeType}, Timestamp:{x.Timestamp.ToLocalTime()}");
            })
            .DisposeWith(disposables);

            swatcher.Created.Subscribe(x =>
            {
                Console.WriteLine(
                    $"[Created] Id:{x.SwatcherId ?? 0}, Name: {x.Name}, ChangeType: {x.ChangeType}, Timestamp:{x.Timestamp.ToLocalTime()}");
            })
            .DisposeWith(disposables);

            swatcher.Deleted.Subscribe(x =>
            {
                Console.WriteLine(
                    $"[Deleted] Id:{x.SwatcherId ?? 0}, Name: {x.Name}, ChangeType: {x.ChangeType}, Timestamp:{x.Timestamp.ToLocalTime()}");
            })
            .DisposeWith(disposables);

            swatcher.Error.Subscribe(x =>
            {
                Console.WriteLine(
                    $"[Error] At {x.Timestamp.ToLocalTime()}, {x.Message}\r\nStack Trace:\r\n{x.StackTrace}");
            })
            .DisposeWith(disposables);

            swatcher.Renamed.Subscribe(x =>
            {
                Console.WriteLine(
                    $"[Renamed] Id:{x.SwatcherId ?? 0}, OldName: {x.OldName}, Name: {x.Name}, ChangeType: {x.ChangeType}, Timestamp:{x.Timestamp.ToLocalTime()}");
            })
            .DisposeWith(disposables);

            Console.WriteLine("Swatcher has started and is listening for events...");
            Console.ReadKey();

            //Shutting down
            swatcher.Stop();
            //Unsubscribe after you Stop if you're done with the component.
            disposables.Dispose();
            swatcher.Dispose();

            //voila! contrived, but pretty easy, eh?
        }

        private static ISwatcherConfig CreateConfiguration()
        {
            //The swatcherId parameter is nullable in case you don't want to use it. It really comes 
            //in handy when you are creating several Swatchers at runtime and you need to know from  
            //which Swatcher an event is being raised.
            var swatcherId = 12345;
            //The folderPath parameter is the path to a folder that you want Swatcher to watch.
            //UNC paths are not supported! If you want to monitor a network folder, you need to map
            //it as a drive.
            var folderPath = @"C:\Users\Martin\Desktop";
            //The changeTypes parameter is an bitwise OR of the change types that you want Swatcher to tell you about.
            //see docs here: https://msdn.microsoft.com/en-us/library/t6xf43e0(v=vs.110).aspx
            var changeTypes = WatcherChangeTypes.All;
            //The itemTypes parameter is used to tell Swatcher if you want to be notified of changes to files, folders,
            //or both. 
            var itemTypes = WatcherItemTypes.All;
            //see docs here: https://msdn.microsoft.com/en-us/library/system.io.notifyfilters(v=vs.110).aspx
            var notificationFilters = NotifyFilters.Attributes | NotifyFilters.CreationTime |
                                      NotifyFilters.DirectoryName | NotifyFilters.FileName |
                                      NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                                      NotifyFilters.Security | NotifyFilters.Size;

            return new SwatcherConfig(swatcherId, folderPath,
                changeTypes, itemTypes, notificationFilters);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizzellConsulting.Swatcher;

namespace SwatcherSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting up Swatcher...");
            //First, we need to create a configuration object to tell Swatcher how to run.

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

            var config = new SwatcherConfig(swatcherId, folderPath,
                changeTypes, itemTypes,notificationFilters);


            var swatcher = new Swatcher(config);
            swatcher.Changed += SwatcherOnChanged; 
            swatcher.Created += SwatcherOnCreated;
            swatcher.Deleted += SwatcherOnDeleted; 
            swatcher.Renamed += SwatcherOnRenamed;
            swatcher.Error += SwatcherOnError;
            //We're running synchronously here, but await is fully supported.
            swatcher.Start();

            Console.WriteLine("Swatcher has started and is listening for events...");
            Console.ReadKey();

            //Shutting down
            swatcher.Stop();
            //Unsubscribe after you Stop if you're done with the component.
            swatcher.Changed -= SwatcherOnChanged;
            swatcher.Created -= SwatcherOnCreated;
            swatcher.Deleted -= SwatcherOnDeleted;
            swatcher.Error -= SwatcherOnError;
            swatcher.Renamed -= SwatcherOnRenamed;
            //cleanup
            swatcher.Dispose();
        }

        private static void SwatcherOnRenamed(object sender, SwatcherRenamedEventArgs e)
        {
            Console.WriteLine($"[Renamed] Id:{e.SwatcherId ?? 0}, OldName: {e.OldName}, Name: {e.Name}, ChangeType: {e.ChangeType}, Timestamp:{e.Timestamp.ToLocalTime()}");
        }

        private static void SwatcherOnDeleted(object sender, SwatcherEventArgs e)
        {
            Console.WriteLine($"[Deleted] Id:{e.SwatcherId ?? 0}, Name: {e.Name}, ChangeType: {e.ChangeType}, Timestamp:{e.Timestamp.ToLocalTime()}");
        }

        private static void SwatcherOnCreated(object sender, SwatcherEventArgs e)
        {
            Console.WriteLine($"[Created] Id:{e.SwatcherId ?? 0}, Name: {e.Name}, ChangeType: {e.ChangeType}, Timestamp:{e.Timestamp.ToLocalTime()}");
        }

        private static void SwatcherOnChanged(object sender, SwatcherEventArgs e)
        {
            Console.WriteLine($"[Changed] Id:{e.SwatcherId ?? 0}, Name: {e.Name}, ChangeType: {e.ChangeType}, Timestamp:{e.Timestamp.ToLocalTime()}");
        }
        private static void SwatcherOnError(object sender, SwatcherErrorEventArgs e)
        {
            Console.WriteLine($"[Error] At {e.Timestamp.ToLocalTime()}, {e.Message}\r\nStack Trace:\r\n{e.StackTrace}");
        }
    }
}

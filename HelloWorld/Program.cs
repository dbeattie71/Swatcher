using System;
using System.IO;
using BraveLantern.Swatcher;
using BraveLantern.Swatcher.Args;
using BraveLantern.Swatcher.Config;

namespace SwatcherSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Hello World With Events!";
            Console.WriteLine("Starting up Swatcher...");
            //First, we need to create a configuration object to tell Swatcher how to run.
            var config = CreateConfiguration();

            var swatcher = new Swatcher(config);
            swatcher.ItemChanged += SwatcherOnChanged; 
            swatcher.ItemCreated += SwatcherOnCreated;
            swatcher.ItemDeleted += SwatcherOnDeleted; 
            swatcher.ItemRenamed += SwatcherOnRenamed;

            swatcher.Start();

            Console.WriteLine("Swatcher has started and is listening for events...");
            Console.ReadKey();

            //Shutting down
            swatcher.Stop();
            //Unsubscribe after you Stop if you're done with the component.
            swatcher.ItemChanged -= SwatcherOnChanged;
            swatcher.ItemCreated -= SwatcherOnCreated;
            swatcher.ItemDeleted -= SwatcherOnDeleted;
            swatcher.ItemRenamed -= SwatcherOnRenamed;
            //cleanup
            swatcher.Dispose();
        }

        private static ISwatcherConfig CreateConfiguration()
        {
            //The swatcherId parameter is optional in case you don't want to use it. It really comes 
            //in handy when you are creating several Swatchers at runtime and you need to know from  
            //which Swatcher an event is being raised.
            //var swatcherId = 12345;
            
            //The folderPath parameter is the path to a folder that you want Swatcher to watch.
            //UNC paths are not supported! If you want to monitor a network folder, you need to map
            //it as a drive.
            var folderPath = @"C:\Users\martin\Desktop";
            //The changeTypes parameter is an bitwise OR of the change types that you want Swatcher to tell you about.
            //see docs here: https://msdn.microsoft.com/en-us/library/t6xf43e0(v=vs.110).aspx
            var changeTypes = WatcherChangeTypes.All;
            //The itemTypes parameter is used to tell Swatcher if you want to be notified of changes to files, folders,
            //or both. 
            var itemTypes = SwatcherItemTypes.All;
            //see docs here: https://msdn.microsoft.com/en-us/library/system.io.notifyfilters(v=vs.110).aspx
            var notificationFilters = SwatcherNotificationTypes.All;

            return new SwatcherConfig(folderPath,changeTypes,itemTypes,notificationFilters, loggingEnabled:true);
        }

        //NOTE: you will get logging message output to the console if you enabled logging in the Swatcher config.
        //put your business logic in the handlers below and you're good to go.
        private static void SwatcherOnRenamed(object sender, SwatcherRenamedEventArgs e)
        {

        }

        private static void SwatcherOnDeleted(object sender, SwatcherEventArgs e)
        {

        }

        private static void SwatcherOnCreated(object sender, SwatcherCreatedEventArgs e)
        {

        }

        private static void SwatcherOnChanged(object sender, SwatcherEventArgs e)
        {

        }

    }
}

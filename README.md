# Swatcher - Say goodbye to the woes of FileSystemWatcher!
The FileSystemWatcher is great for demo apps. For production code? Not so much. Swatcher was written from the ground-up to replace FileSystemWatcher and add the features you need: speed, reliability, events raised when they're supposed to be and an intuitive API that's awesome. Heck, it even provides both observables and events to cater to your coding style. 

#### Features
* No false change notifications when a file system item is created, deleted or renamed.
* When a large file is being uploaded, copied or moved, Swatcher will wait until the IO operations are completed before sending a creation notice. 
* In addition to the aforementioned, `SwatcherCreatedEventArgs` includes a `TimeInTransit` property to inform you as to how long the IO operation took.
* In the `ISwatcherConfig`, you can specify a custom filter for `Created`, `Changed`, `Deleted` and `Renamed` events so an event is never raised for stuff you're not interested in.
* I added `Common.Logging` to enable developers to "hook" diagnostic info as a Swatcher is processing file system events. Thus, you'll be able to seamlessly integrate a Swatcher with whatever logging mechanism you're using. Create an issue for info your interested in and I will consider adding it to the product!

#### Installation
Swatcher is installed using [NuGet](https://www.nuget.org/packages/Swatcher/):
`Install-Package Swatcher`
      
#### Configuring a Swatcher
```c#
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
```

#### Consuming a Swatcher
There are two different ways a Swatcher can be consumed:
* [Usage via Events](https://github.com/MizzellConsulting/Swatcher/wiki/Usage-via-Events)
* [Usage via Rx Observables](https://github.com/MizzellConsulting/Swatcher/wiki/Usage-via-Rx-Observables)

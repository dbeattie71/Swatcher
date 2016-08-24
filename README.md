# Swatcher - A FileSystemWatcher for .Net 
If you've ever used the built-in FileSystemWatcher component for .Net, you know that it has issues. In addition to remediating said issues, Swatcher augments the functionality of FileSystemWatcher to make the developers life easy, all with an intuitive API and very little boiletplate.

#### Features
* No false change notifications when a file system item is created, deleted or renamed.
* When a large file is being uploaded, copied or moved, Swatcher will wait until the IO operations are completed before sending a creation notice. 
* In addition to the aforementioned, `SwatcherCreatedEventArgs` includes a `TimeInTransit` property to inform you as to how long the IO operation took.

#### Installation
Swatcher is installed using [NuGet link](https://www.nuget.org/packages/Swatcher/):
`Install-Package Swatcher`
      
#### Documentation in Progress!

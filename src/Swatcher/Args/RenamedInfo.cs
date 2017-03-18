namespace BraveLantern.Swatcher.Args
{
    sealed class RenamedInfo
    {
        public string Name { get; set; }
        public FileSystemItemEvent Event { get; set; }
    }
}

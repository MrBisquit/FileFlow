namespace FileFlow
{
    public class File
    {
        public FileInfo GetFile(string path)
        {
            return new FileInfo(path);
        }
    }
    public class Directory
    {
        public class FileSystemListener
        {
            FileSystemWatcher watcher;
            public FileSystemListener(DirectoryInfo directory)
            {
                watcher = new FileSystemWatcher(directory.FullName);
                watcher.EnableRaisingEvents = true;
            }
            public void AddFileCreatedListener(FileSystemEventHandler action)
            {
                watcher.Created += action;
            }
            public void AddFileChangedListener(FileSystemEventHandler action)
            {
                watcher.Changed += action;
            }
            public void AddFileRenamedListener(RenamedEventHandler action)
            {
                watcher.Renamed += action;
            }
            public void AddFileDeletedListener(FileSystemEventHandler action)
            {
                watcher.Deleted += action;
            }
            public void Destroy()
            {
                watcher.Dispose();
            }
        }
    }
}
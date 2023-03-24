namespace FileFlow
{
    public class File
    {
        /// <summary>
        /// Gets a file as a FileInfo class which can be used later
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns>A FileInfo class of the file path provided</returns>
        public FileInfo GetFile(string path)
        {
            return new FileInfo(path);
        }
        /// <summary>
        /// Removes a file
        /// </summary>
        /// <param name="file">A FileInfo class (can be generated using GetFile)</param>
        public void RemoveFile(FileInfo file)
        {
            file.Delete();
        }
        public FileInfo MoveFile(FileInfo file, string PathToMoveTo)
        {
            file.MoveTo(PathToMoveTo);
            return file;
        }

        public List<FileInfo> AddToFileList(FileInfo toadd, List<FileInfo> filelist)
        {
            filelist.Add(toadd);

            return filelist;
        }

        public List<FileInfo> AddToFileList(FileInfo[] toadd, List<FileInfo> filelist)
        {
            for (int i = 0; i < toadd.Length; i++)
            {
                filelist.Add(toadd[i]);
            }

            return filelist;
        }

        public List<FileInfo> RemoveFromFileList(FileInfo toremove, List<FileInfo> filelist)
        {
            filelist.Remove(toremove);

            return filelist;
        }

        public List<FileInfo> RemoveFromFileList(FileInfo[] toremove, List<FileInfo> filelist)
        {
            for (int i = 0; i < toremove.Length; i++)
            {
                filelist.Remove(toremove[i]);
            }

            return filelist;
        }

        public void DeleteFiles(List<FileInfo> files)
        {
            files.ForEach(file => file.Delete());
        }
    }
    public class Directory
    {
        /// <summary>
        /// Gets a directory as a DirectoryInfo class which can be used later
        /// </summary>
        /// <param name="path">The path of the directory</param>
        /// <returns>A DirectoryInfo class of the directory path provided</returns>
        public DirectoryInfo GetDirectory(string path)
        {
            return new DirectoryInfo(path);
        }
        /// <summary>
        /// Makes the FileSystemWatcher class a little more easier
        /// </summary>
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
            public void RemoveFileCreatedListener(FileSystemEventHandler action)
            {
                watcher.Created -= action;
            }
            public void RemoveFileChangedListener(FileSystemEventHandler action)
            {
                watcher.Changed -= action;
            }
            public void RemoveFileRenamedListener(RenamedEventHandler action)
            {
                watcher.Renamed -= action;
            }
            public void RemoveFileDeletedListener(FileSystemEventHandler action)
            {
                watcher.Deleted -= action;
            }
            public void Dispose()
            {
                watcher.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
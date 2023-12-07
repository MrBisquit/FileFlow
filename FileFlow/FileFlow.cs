using FileFlow.Types;

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

        /// <summary>
        /// Moves a file from one place to another
        /// </summary>
        /// <param name="file">The source file</param>
        /// <param name="PathToMoveTo">The destination of where it should be moved it</param>
        /// <returns>The source file</returns>
        public FileInfo MoveFile(FileInfo file, string PathToMoveTo)
        {
            file.MoveTo(PathToMoveTo);
            return file;
        }

        /// <summary>
        /// Adds a file to list of files that you can mass delete or mass move
        /// </summary>
        /// <param name="toadd">The file to add to the list of files</param>
        /// <param name="filelist">The list of files (can be an empty list)</param>
        /// <returns>The list, now containing the file</returns>
        public List<FileInfo> AddToFileList(FileInfo toadd, List<FileInfo> filelist)
        {
            filelist.Add(toadd);

            return filelist;
        }

        /// <summary>
        /// The same as AddToFileList but with multiple files
        /// </summary>
        /// <param name="toadd">The files to add to the list of files</param>
        /// <param name="filelist">The list of files (can be an empty list)</param>
        /// <returns>The list, new containing the files</returns>
        public List<FileInfo> AddToFileList(FileInfo[] toadd, List<FileInfo> filelist)
        {
            for (int i = 0; i < toadd.Length; i++)
            {
                filelist.Add(toadd[i]);
            }

            return filelist;
        }

        /// <summary>
        /// The reverse of AddToFileList, removes a file from the list
        /// </summary>
        /// <param name="toremove">The file to remove from the list of files</param>
        /// <param name="filelist">The list of files (can be empty, but there's no point)</param>
        /// <returns>The list, now not containing the file</returns>
        public List<FileInfo> RemoveFromFileList(FileInfo toremove, List<FileInfo> filelist)
        {
            filelist.Remove(toremove);

            return filelist;
        }

        /// <summary>
        /// The same as RemoveFromFileList but with multiple files
        /// </summary>
        /// <param name="toremove">The files to remove from the list of files</param>
        /// <param name="filelist">The list of files (can be empty, but there's no point)</param>
        /// <returns>The list, now not containing the files</returns>
        public List<FileInfo> RemoveFromFileList(FileInfo[] toremove, List<FileInfo> filelist)
        {
            for (int i = 0; i < toremove.Length; i++)
            {
                filelist.Remove(toremove[i]);
            }

            return filelist;
        }

        /// <summary>
        /// Mass deletes all of the files in the list
        /// </summary>
        /// <param name="files">The list of files to be deleted</param>
        public void DeleteFiles(List<FileInfo> files)
        {
            files.ForEach(file => file.Delete());
        }

        /// <summary>
        /// Mass moves all of the files in the list
        /// </summary>
        /// <param name="files">The list of files to be moved</param>
        /// <param name="destination">The directory where they will be placed</param>
        public void MoveFiles(List<FileInfo> files, string destination)
        {
            files.ForEach(file => file.MoveTo(destination));
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
        /// <summary>
        /// Searches the directory provided with the quer(y/ies) provided, (subdirectory available but can take a long time and power)
        /// </summary>
        /// <param name="query">Typeof Queries.SearchQuery, see documentation for Queries.SearchQuery for more information</param>
        /// <returns>Returns typeof FileSearchResult, see documentation for FileSearchResult for more information</returns>
        [Obsolete("Not in use (Does not work)")]
        public FileSearchResult QueryDirectory(Queries.SearchQuery query)
        {
            FileSearchResult fileSearchResult = new FileSearchResult();

            //if (query.subdirectories) throw new NotImplementedException("Cannot yet query subdirectories.");

            //System.IO.Directory.GetFiles(query.directory.FullName);

            return fileSearchResult;
        }
        /// <summary>
        /// Is literally System.IO.Directory.GetFiles.
        /// </summary>
        /// <param name="searchPath"></param>
        /// <param name="searchpattern"></param>
        /// <param name="searchoption"></param>
        /// <returns>An array of files.</returns>
        public string[] SearchDirectory(string searchPath, string searchpattern, SearchOption searchoption)
        {
            return System.IO.Directory.GetFiles(searchPath, searchpattern, searchoption);
        }
    }
}
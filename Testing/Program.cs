using FileFlow;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Loading cache...");
            if(!System.IO.Directory.Exists(Path.Combine(Environment.CurrentDirectory, "FileFlow", "Cache")))
            {
                System.IO.Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "FileFlow", "Cache"));
            }
            Caching cache = new Caching(Path.Combine(Environment.CurrentDirectory, "FileFlow", "Cache"));
            cache.AddFile(new FileInfo(Path.Combine(Environment.CurrentDirectory, "Testing.exe")));

            /*string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string cacheFolderPath = Path.Combine(appDataFolder, "FileFlowTesting", "FileFlow", "Cache");

            if(System.IO.Directory.Exists(cacheFolderPath))
            {
                System.IO.Directory.CreateDirectory(cacheFolderPath);
            }*/

            /*Caching cache = new Caching(cacheFolderPath);
            try
            {
                cache.AddFile(new FileInfo(Environment.CurrentDirectory + "\\Testing.exe"));
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }*/

            //var fsl = new FileFlow.Directory.FileSystemListener(new DirectoryInfo(Console.ReadLine()));
            List<FileInfo> files = new List<FileInfo>();
            var fsl = new FileFlow.Directory.FileSystemListener(new DirectoryInfo(Environment.CurrentDirectory));
            Console.Clear();
            Console.WriteLine(Environment.CurrentDirectory);
                Console.WriteLine("| Type    | File name");
            fsl.AddFileCreatedListener((sender, e) =>
            {
                Console.WriteLine("| Created | " + e.Name);
                FileFlow.File file = new FileFlow.File();
                //file.RemoveFile(new FileInfo(e.Name));
                files = file.AddToFileList(new FileInfo(e.Name), files);
            });
            fsl.AddFileChangedListener((sender, e) =>
            {
                Console.WriteLine("| Changed | " + e.Name);
            });
            fsl.AddFileDeletedListener((sender, e) =>
            {
                Console.WriteLine("| Deleted | " + e.Name);
            });
            fsl.AddFileRenamedListener((sender, e) => {
                Console.WriteLine("| Renamed | " + e.Name);
            });
            Console.ReadLine();
            FileFlow.File file = new FileFlow.File();
            file.DeleteFiles(files);
            fsl.Dispose();
            Console.ReadLine();
        }
    }
}
namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fsl = new FileFlow.Directory.FileSystemListener(new DirectoryInfo(Console.ReadLine()));
            Console.Clear();
                Console.WriteLine("| Type    | File name");
            fsl.AddFileCreatedListener((sender, e) =>
            {
                Console.WriteLine("| Created | " + e.Name);
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
            fsl.Dispose();
            Console.ReadLine();
        }
    }
}
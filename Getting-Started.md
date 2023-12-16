# Setting up FileFlow for your .NET project
First, there's a few steps to import the package:
1. Download the NuGet package using the instructions here: https://www.nuget.org/packages/FileFlow
2. Import the package in your IDE (For Visual Studio use the built-in NuGet package manager)
3. You've successfully imported FileFlow into your project

Depending on how you want to use FileFlow, there are a few different sections:
## General usage (Includes all)

There are many features to explore but the first one is the File Event Listner and this is how you use it:
```cs
FileFlow.Directory.FileSystemListener fsl = new FileFlow.Directory.FileSystemListener(new DirectoryInfo(Environment.CurrentDirectory));
    Console.WriteLine("| Type    | File name");
fsl.AddFileCreatedListener((sender, e) =>
{
    Console.WriteLine("| Created | " + e.Name); // Listen for files/directories created
});
fsl.AddFileChangedListener((sender, e) =>
{
    Console.WriteLine("| Changed | " + e.Name); // Listen for files/directories changed
});
fsl.AddFileDeletedListener((sender, e) =>
{
    Console.WriteLine("| Deleted | " + e.Name); // Listen for files/directories deleted
});
fsl.AddFileRenamedListener((sender, e) => {
    Console.WriteLine("| Renamed | " + e.Name); // Listen for files/directories renamed
});
```

## Caching
(Not fully built yet and will have some issues)

```cs
// Initialise the cache
Caching cache = new Caching(Path.Combine(Environment.CurrentDirectory, "FileFlow", "Cache"));
// Add a file to the cache
cache.AddFile(new FileInfo(Path.Combine(Environment.CurrentDirectory, "Testing.exe"))); // Add the Testing.exe application to the file cache
```

## Exceptions
If you encounter any exceptions, they are documented <a href="FileFlow/Exceptions/Exceptions.md">here</a>.
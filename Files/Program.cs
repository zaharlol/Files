using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime;

class Drive
{
    public Drive(string name, long capacity, long freeplace)
    {
        Name = name;
        Capacity = capacity;
        FreePlace = freeplace;
    }
    public string Name { get; }
    public long Capacity { get; }
    public long FreePlace { get; }
}
public class Folder
{
    public List<string> Files { get; set; } = new List<string>();

    Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

    public void CreateFolder(string name)
    {
        Folders.Add(name, new Folder());
    }
}

namespace DriveManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // получим системные диски
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"/" /* Или С:\\ для Windows */ );
                if (dirInfo.Exists)
                {
                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }

                DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");
                if (!newDirectory.Exists)
                    newDirectory.Create();

                Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                dirInfo.Delete(true);
                newDirectory.Delete(true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            static void Swap()
            {
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(@"D:/VS/SkillFactory/testFolder");
                    string trashPath = "/Users/denma/.Trash";

                    dirInfo.MoveTo(trashPath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}
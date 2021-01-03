using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleForInterview.Examples
{
    public static class Utility
    {
        public static long GetDirectorySize(string directory, ref int totalFiles)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            long dirSzie = 0;
            foreach(var subDir in di.GetDirectories())
            {
                dirSzie += GetDirectorySize(subDir.FullName, ref totalFiles);
            }

            foreach(var file in di.GetFiles())
            {
                totalFiles++;
                Console.WriteLine($"{file.FullName} : {file.Length}bytes");
                dirSzie += file.Length;
            }

            return dirSzie;
        }

        public static void DeleteDirectory(string directory)
        {
            DirectoryInfo di = new DirectoryInfo(directory);
            long dirSzie = 0;
            foreach (var subDir in di.GetDirectories())
            {
                DeleteDirectory(subDir.FullName);
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                Console.WriteLine("Deleting File : "+file);
                dirSzie += file.Length;
                File.Delete(file);
            }

            Console.WriteLine("Deleting Folder : " + directory);
            Directory.Delete(directory);
        }

        public static void CopyDirectory(string source, string dest)
        {
            DirectoryInfo di = new DirectoryInfo(source);
            Console.WriteLine(di.Name);
            string destFolder = Path.Combine(dest, di.Name);
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }

            foreach (var subDir in di.GetDirectories())
            {
                Task.Run(() => { CopyDirectory(subDir.FullName, destFolder); });
            }

            foreach (var file in Directory.GetFiles(source))
            {
                Console.WriteLine("Copying File : " + file);
                FileInfo fi = new FileInfo(file);
                string destFileName = Path.Combine(destFolder, fi.Name);
                File.Copy(file, destFileName);
            }
        }
    }
}

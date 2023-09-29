using System;
using System.IO;

namespace ChronoSaver
{
    //src -  "source"
    //dst - "destination"
    public class FileMethods
    {
        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                DirectoryInfo sourceDirInfo = new DirectoryInfo(sourcePath);
                foreach (FileInfo file in sourceDirInfo.GetFiles())
                {
                    string destFile = Path.Combine(destinationPath, file.Name);
                    file.CopyTo(destFile, true);
                }

                foreach (DirectoryInfo subDir in sourceDirInfo.GetDirectories())
                {
                    string destSubDir = Path.Combine(destinationPath, subDir.Name);
                    CopyDirectory(subDir.FullName, destSubDir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании в папку {destinationPath}: {ex.Message}");
            }
        }

        public static void DeleteFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                    Console.WriteLine($"Папка {folderPath} успешно удалена.");
                }
                else
                {
                    Console.WriteLine($"Папка {folderPath} не существует.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении папки {folderPath}: {ex.Message}");
            }
        }
        
        public static void CopyFile(string sourceFilePath, string destinationFolderPath)
        {
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
            
            File.Copy(sourceFilePath, destinationFilePath, true);
        }
    }
}
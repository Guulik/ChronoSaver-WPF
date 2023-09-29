<<<<<<<< Updated upstream:Source/FileMethods.cs
using System;
========
﻿using System;
>>>>>>>> Stashed changes:Modules/FileMethods.cs
using System.IO;

namespace ChronoSaver
{
    //src - stands for "source"
    //dst - stands for "destination"
    public class FileMethods
    {
<<<<<<<< Updated upstream:Source/FileMethods.cs

        public static void CopyDirectory(string src, string dst)
        {
            string sourceDir = src;
            string destDir = dst;


            // Создаем новую директорию, если она не существует
            if (!Directory.Exists(destDir))
            {
                Directory.CreateDirectory(destDir);
            }

            // Копируем содержимое директории в новую директорию
            DirectoryInfo sourceDirInfo = new DirectoryInfo(sourceDir);
            foreach (FileInfo file in sourceDirInfo.GetFiles())
            {
                string destFile = Path.Combine(destDir, file.Name);
                file.CopyTo(destFile, true);
            }
========
        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }
>>>>>>>> Stashed changes:Modules/FileMethods.cs

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
<<<<<<<< Updated upstream:Source/FileMethods.cs
                string destSubDir = Path.Combine(destDir, subDir.Name);
                CopyDirectory(subDir.FullName, destSubDir);
            }
        }
========
                Console.WriteLine($"Ошибка при копировании в папку {destinationPath}: {ex.Message}");
            }
        }

>>>>>>>> Stashed changes:Modules/FileMethods.cs
        public static void DeleteFolder(string folderPath)
        {
            try
            {
<<<<<<<< Updated upstream:Source/FileMethods.cs
                // Проверяем, существует ли папка
========
>>>>>>>> Stashed changes:Modules/FileMethods.cs
                if (Directory.Exists(folderPath))
                {
                    // Удаляем папку и её содержимое
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
<<<<<<<< Updated upstream:Source/FileMethods.cs

========
        
        public static void CopyFile(string sourceFilePath, string destinationFolderPath)
        {
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));
            
            File.Copy(sourceFilePath, destinationFilePath, true);
        }
>>>>>>>> Stashed changes:Modules/FileMethods.cs
    }
}
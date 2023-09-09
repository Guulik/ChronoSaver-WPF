using System;
using System.IO;

namespace ChronoSaver
{
    //src - stands for "source"
    //dst - stands for "destination"
    public class FileMethods
    {

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

            foreach (DirectoryInfo subDir in sourceDirInfo.GetDirectories())
            {
                string destSubDir = Path.Combine(destDir, subDir.Name);
                CopyDirectory(subDir.FullName, destSubDir);
            }
        }
        public static void DeleteFolder(string folderPath)
        {
            try
            {
                // Проверяем, существует ли папка
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

    }
}
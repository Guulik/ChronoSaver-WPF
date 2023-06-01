using System.IO;

namespace ChronoSaver
{
    //src - stands for "source"
    //dst - stands for "destination"
    public class FileMethods
    {

        public static void CopyFile(string src, string dst)
        {
            string sourceFilePath = src;
            string destinationFolderPath = dst;
            string destinationFilePath = Path.Combine(destinationFolderPath, Path.GetFileName(sourceFilePath));

            File.Copy(sourceFilePath, destinationFilePath, true);
        }
        public static void MoveDirectory(string src, string dst)
        {
            string sourceDirectory = src;
            string destinationDirectory = dst;


            Directory.Move(sourceDirectory, destinationDirectory);

        }
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

    }
}
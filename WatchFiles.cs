using System.IO;

namespace ChronoSaver;

public class WatchFiles
{
    private readonly FileSystemWatcher _fileWatcher = new FileSystemWatcher($@"{Paths.ChronoSaverPath}\usrSaves");
    public string ChangedPath = "";
    public WatchFiles()
    {
        _fileWatcher.IncludeSubdirectories = true;
        _fileWatcher.Changed += OnChanged;
        _fileWatcher.Created += OnChanged;
        _fileWatcher.Deleted += OnDeleted;
        _fileWatcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType is not (WatcherChangeTypes.Changed or WatcherChangeTypes.Created)) return;

        if (e.FullPath.EndsWith(@"0\caption.jpg"))
        {
            ChangedPath = e.FullPath;
        }
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        if (e.FullPath.EndsWith(@"0\caption.jpg"))
        {
            ChangedPath = e.FullPath;
        }
    }
}
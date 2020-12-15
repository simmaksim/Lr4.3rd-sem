using System;
using System.IO;
using System.Windows;

namespace DataManager.WorkWithWindowService
{
    public class FolderWatcher
    {
        private readonly FileSystemWatcher watcher;

        public FolderWatcher(string directoryName)
        {
            watcher = new FileSystemWatcher(directoryName);
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
        }

        public void StartWatching()
        {
            watcher.EnableRaisingEvents = true;
        }

        public void StopWatching()
        {
            watcher.EnableRaisingEvents = false;
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            ShowChanges("deleted", e.FullPath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            ShowChanges("added", e.FullPath);
        }

        private void ShowChanges(string fileEvent, string filePath)
        {
            MessageBox.Show($"{DateTime.Now:dd/MM/yyyy HH:mm:ss} file {filePath} was {fileEvent}", Path.GetDirectoryName(filePath),MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}

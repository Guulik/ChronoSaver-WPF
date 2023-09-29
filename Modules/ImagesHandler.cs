using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace ChronoSaver
{
    public class ImagesHandler
    {
        private WatchFiles _watcher = new WatchFiles();

        
        private MainWindow _mainWindow;

        public ImagesHandler(MainWindow mainWindow)
        {
            this._mainWindow = mainWindow;
            SetImages();
        }

        private readonly string[] _sourceImagePaths =
        {
            $@"{Paths.ChronoSaverPath}\usrSaves\1\0\caption.jpg",
            $@"{Paths.ChronoSaverPath}\usrSaves\2\0\caption.jpg",
            $@"{Paths.ChronoSaverPath}\usrSaves\3\0\caption.jpg"
        };
        

        private List<BitmapImage> BitmapImages { get; set; } = new List<BitmapImage>();

        private void SetImages()
        {
            CreateBitmapList();
            for (int i = 0; i < _mainWindow.Images.Count; i++)
            {
                _mainWindow.Images[i].Source = BitmapImages[i];
            }
        }
        

        private void CreateBitmapList()
        {
            foreach (var imagePath in _sourceImagePaths)
            {
                BitmapImage bitmapImage;
                if (!File.Exists(imagePath))
                    bitmapImage = LoadEmptyBitmap();
                else
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    using MemoryStream stream = new MemoryStream(imageBytes);
                    bitmapImage = LoadBitmapFromStream(stream);
                }

                BitmapImages.Add(bitmapImage);
            }

            Console.WriteLine("BitmapList Created! ");
        }


        public void UpdateImage()
        {
            BitmapImage changedImage;
            Console.WriteLine("Wathcer ChangedPath: " + _watcher.ChangedPath); 
            if (!File.Exists(_watcher.ChangedPath))
            {
                changedImage = LoadEmptyBitmap();
            }
            else
            {
                byte[] imageBytes = File.ReadAllBytes(_watcher.ChangedPath);
                using MemoryStream stream = new MemoryStream(imageBytes);
                changedImage = LoadBitmapFromStream(stream);
            }

            BitmapImages[_mainWindow.SelectedSlot] = changedImage;
            _mainWindow.Images[_mainWindow.SelectedSlot].Source = BitmapImages[_mainWindow.SelectedSlot];
            
            Console.WriteLine("changeToImage: " + changedImage);
            
        }
        
        private BitmapImage LoadBitmapFromStream(MemoryStream stream)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            return bitmapImage;
        }
        private BitmapImage LoadEmptyBitmap()
        {
            return new BitmapImage(new Uri($@"{Paths.ChronoSaverPath}\usrSaves\empty.jpg", UriKind.Absolute));
        }
        
        
        //for debug purposes
        private void ShowBitmapInfo()
        {
            foreach (var bitmapImage in BitmapImages)
            {
                Console.WriteLine(bitmapImage + " \\|/");
            }
        }
    }
}
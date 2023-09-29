using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ChronoSaver
{
    public struct MyPaths
    {
        public static string ChronoSaverPath =
         Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");

        public static string gamePath =
             Path.Combine(ChronoSaverPath, @"..");

        public static string sourcePath =
            $@"{gamePath}\mlc01\usr\save\00050000\101c9500\user\80000001";

        public static string useChoicePath =
            $@"{ChronoSaverPath}\usrSaves\unAllocated";//for saves

        public static string testPath =
            $@"{ChronoSaverPath}\test\destination";//for load function


    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //copy files FROM src TO dst
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            
        }

        private static void Copy(string src, string dst)
        { FileMethods.CopyDirectory(src, dst); }
        private static void Delete(string folder) 
        { FileMethods.DeleteFolder(folder); }
        

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string[] _imagePaths =
        {
            $@"{MyPaths.ChronoSaverPath}\usrSaves\1\0\caption.jpg",
            $@"{MyPaths.ChronoSaverPath}\usrSaves\2\0\caption.jpg",
            $@"{MyPaths.ChronoSaverPath}\usrSaves\3\0\caption.jpg",
        };

        private List<BitmapImage> _images = new List<BitmapImage>();
        private void ChangeImage()
        {
            for (int i = 0; i < _imagePaths.Length; i++)
            {
                string imagePath = _imagePaths[i];
                if (!File.Exists(_imagePaths[i]))
                {
                    imagePath = $@"{MyPaths.ChronoSaverPath}\usrSaves\empty.jpg";
                }
                // Освободить ресурсы предыдущего BitmapImage (если есть)
                /*if (_images.Count > i && _images[i] != null)
                {
                    _images[i].UriSource = null;
                    _images[i] = null;
                }*/

                // Создать новый BitmapImage
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                //_imagePaths[i] = imagePath;
                _images.Add(bitmapImage);
            }
            //OnPropertyChanged("ImageSource");

        }

        public List<BitmapImage> ImageSource
        {
            get
            {
                ChangeImage();
                return _images;
            }
            set 
            {
                //OnPropertyChanged("ImageSource");
            }
        }
        /*public string SelectedImage
        {
            get { return _imagePaths[SelectedSlot]; }
            set { OnPropertyChanged(); }
        }*/



        private bool[] _slotArray = new bool[] { false, false, false };
        public bool[] SlotArray
        {
            get { return _slotArray; }
            set { _slotArray = value; }
        }
        public int SelectedSlot
        {
            get { return Array.IndexOf(_slotArray, true); }
            set { OnPropertyChanged("SlotArray"); }
        }

        private string _savePath = "unAllocated";
        public string SavePath
        {
            get {
                return _savePath; }
            set
            {
                if (_savePath != value)
                {
                    _savePath = value;
                    OnPropertyChanged();
                }
            }
        }


        private string[] _statuses = 
        { 
            "Chrono successfully saved! no need to worry",
            "Chrono loaded! check it in game now",
            "You deleted the chrono. Good bye!! :)"
        };
        private string _status = "hola";
        public string Status
        {
            get { return _status; } 
            set { _status = value;
                OnPropertyChanged();} 
        }
        

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Copy(MyPaths.sourcePath, MyPaths.useChoicePath);
            ChangeImage();
            //OnPropertyChanged("ImageSource");
            Status = _statuses[0];
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {   
            Copy(MyPaths.useChoicePath, MyPaths.sourcePath);
            Status = _statuses[1];
        }
        private void SlotRadioButton_Click(object sender, RoutedEventArgs e)
        {
            MyPaths.useChoicePath = SelectedSlot != -1 ?
                Path.Combine(MyPaths.useChoicePath+@"\..",
                (SelectedSlot + 1).ToString()) : MyPaths.useChoicePath;
            //отладочная информация
            SavePath = (SelectedSlot + 1).ToString();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Delete(MyPaths.useChoicePath);
            Status = _statuses[2];
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
<<<<<<< Updated upstream
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
=======

namespace ChronoSaver
{
    public struct Paths
    {
        public static readonly string ChronoSaverPath =  Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
        
        public static readonly string ChronosSourcePath =
            $@"P:\Games\The legend of Zelda\mlc01\usr\save\00050000\101c9500\user\80000001";
        static string testPath =
>>>>>>> Stashed changes
            $@"{ChronoSaverPath}\test\destination";//for load function
    }
<<<<<<< Updated upstream
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //copy files FROM src TO dst
=======

    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly ImagesHandler _imagesHandler;
        public List<Image> Images { get; set; }
        private string _userChosenPath = $@"{Paths.ChronoSaverPath}\usrSaves\unAllocated";
        
>>>>>>> Stashed changes
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
<<<<<<< Updated upstream
            
        }

        private static void Copy(string src, string dst)
        { FileMethods.CopyDirectory(src, dst); }
        private static void Delete(string folder) 
        { FileMethods.DeleteFolder(folder); }
=======
            DataContext = this;
            Images = new List<Image>(){SlotImage1,SlotImage2,SlotImage3};
            _imagesHandler = new ImagesHandler(this);
        }
>>>>>>> Stashed changes
        

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

<<<<<<< Updated upstream
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
=======
        public bool[] SlotArray { get; set; } = { false, false, false };

        public int SelectedSlot => Array.IndexOf(SlotArray, true);

>>>>>>> Stashed changes

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


        private readonly string[] _statuses =
        {
            "Chrono successfully saved! no need to worry",
            "Chrono loaded! check it in game now",
            "You deleted the chrono. Good bye!! :)"
        };
        private string _status = "hola";
        public string Status
        {
<<<<<<< Updated upstream
            get { return _status; } 
            set { _status = value;
                OnPropertyChanged();} 
        }
        

        

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Copy(MyPaths.sourcePath, MyPaths.useChoicePath);
            ChangeImage();
            //OnPropertyChanged("ImageSource");
=======
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FileMethods.CopyDirectory(Paths.ChronosSourcePath, _userChosenPath);
            _imagesHandler.UpdateImage();

>>>>>>> Stashed changes
            Status = _statuses[0];
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
<<<<<<< Updated upstream
        {   
            Copy(MyPaths.useChoicePath, MyPaths.sourcePath);
=======
        {
            if (!Directory.Exists(_userChosenPath)) return;
            FileMethods.CopyDirectory(_userChosenPath, Paths.ChronosSourcePath);

>>>>>>> Stashed changes
            Status = _statuses[1];
        }
        private void SlotRadioButton_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream
            MyPaths.useChoicePath = SelectedSlot != -1 ?
                Path.Combine(MyPaths.useChoicePath+@"\..",
                (SelectedSlot + 1).ToString()) : MyPaths.useChoicePath;
            //отладочная информация
            SavePath = (SelectedSlot + 1).ToString();
=======
            _userChosenPath = SelectedSlot != -1 ?
                Path.Combine($@"{Paths.ChronoSaverPath}\usrSaves",
                (SelectedSlot + 1).ToString()) : _userChosenPath;
            //debug
            debugSavePath = _userChosenPath;
>>>>>>> Stashed changes
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< Updated upstream
            Delete(MyPaths.useChoicePath);
=======
            if (!Directory.Exists(_userChosenPath))
            {
                //debug
                Console.WriteLine($"Папка {_userChosenPath} не существует.");
                return;
            }
            FileMethods.DeleteFolder(_userChosenPath);
            _imagesHandler.UpdateImage();

>>>>>>> Stashed changes
            Status = _statuses[2];
        }
    }
}

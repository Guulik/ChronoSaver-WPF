//version 1.0.0
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;


namespace ChronoSaver
{
    public struct Paths
    {
        public static readonly string ChronoSaverPath =  Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
        
        public static readonly string ChronosSourcePath =
            $@"{ChronoSaverPath}\..\mlc01\usr\save\00050000\101c9500\user\80000001";
        static string testPath =
            $@"{ChronoSaverPath}\test\destination";//for test
    }

    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly ImagesHandler _imagesHandler;
        public List<Image> Images { get; set; }
        private string _userChosenPath = $@"{Paths.ChronoSaverPath}\usrSaves\unAllocated";
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Images = new List<Image>(){SlotImage1,SlotImage2,SlotImage3};
            _imagesHandler = new ImagesHandler(this);
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool[] SlotArray { get; set; } = { false, false, false };

        public int SelectedSlot => Array.IndexOf(SlotArray, true);


        private string _debugSavePath = "unAllocated";
        public string debugSavePath
        {
            get => _debugSavePath;
            set
            {
                _debugSavePath = value;
                OnPropertyChanged();
            }
        }


        private readonly string[] _statuses =
        {
            "Chrono successfully saved! no need to worry",
            "Chrono loaded! check it in game now",
            "You deleted the chrono. Good bye, chrono!! :)"
        };
        private string _status = "hola";
        public string Status
        {
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

            Status = _statuses[0];
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(_userChosenPath)) return;
            FileMethods.CopyDirectory(_userChosenPath, Paths.ChronosSourcePath);

            Status = _statuses[1];
        }
        private void SlotRadioButton_Click(object sender, RoutedEventArgs e)
        {
            _userChosenPath = SelectedSlot != -1 ?
                Path.Combine($@"{Paths.ChronoSaverPath}\usrSaves",
                (SelectedSlot + 1).ToString()) : _userChosenPath;
            //debug
            debugSavePath = _userChosenPath;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(_userChosenPath))
            {
                //debug
                Console.WriteLine($"Папка {_userChosenPath} не существует.");
                return;
            }
            FileMethods.DeleteFolder(_userChosenPath);
            _imagesHandler.UpdateImage();

            Status = _statuses[2];
        }
    }
}

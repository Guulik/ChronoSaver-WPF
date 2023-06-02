using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Media3D;

namespace ChronoSaver
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private static string ChronoSaverPath =
             Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");

        private static string gamePath =
             Path.Combine(ChronoSaverPath, @"..");

        static string sourcePath =
            $@"{gamePath}\mlc01\usr\save\00050000\101c9500\user\80000001";

        public string userSavePath =
            $@"{ChronoSaverPath}\usrSaves\unAllocated";//for saves

        static string testPath =
            $@"{ChronoSaverPath}\test\destination";//for load function

        private void changeImage()
        {
            for (int i = 0; i < _imageSource.Length - 1; i++)
            {
                if (!File.Exists(_imageSource[i]))
                {
                    _imageSource[i] = _imageSource[3];
                }
                else
                {
                    continue;
                }
            }
        }
        private string[] _imageSource =
        {
            //превьюшки изменены с целью демонстрации
            //нужно поменять вторую циферку на 0, чтобы они подгружались корректно
            $@"{ChronoSaverPath}\usrSaves\1\0\caption.jpg",
            $@"{ChronoSaverPath}\usrSaves\2\0\caption.jpg",
            $@"{ChronoSaverPath}\usrSaves\3\0\caption.jpg",
            $@"{ChronoSaverPath}\usrSaves\empty.jpg"
        };

        public string[] ImageSource
        {
            get
            {
                changeImage();
                return _imageSource;
                /*
                string outImagePath = $@"{ChronoSaverPath}\usrSaves\empty.jpg";
                foreach (string image in _imageSource)
                {
                    if (!File.Exists(image) || SelectedSlot == -1)
                    {
                        outImagePath = _imageSource[3];
                    }
                    else
                    {
                        outImagePath = _imageSource[SelectedSlot];
                    }
                }

                return outImagePath;
                */
            }
            set { OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool[] _slotArray = new bool[] { false, false, false };
        public bool[] SlotArray
        {
            get { return _slotArray; }
            set { _slotArray = value; }
        }
        public int SelectedSlot
        {
            get { return Array.IndexOf(_slotArray, true); }
            set { OnPropertyChanged(); }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        //copy FROM src TO dst
        public static void Copy(string src, string dst)
        { FileMethods.CopyDirectory(src, dst); }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Copy(sourcePath, userSavePath);
            status.Text = "Chrono successfully saved! no need to worry";
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Copy(userSavePath, sourcePath);
            status.Text = "Chrono loaded! check it in game now";
        }
        private void SlotRadioButton_Click(object sender, RoutedEventArgs e)
        {
            userSavePath = SelectedSlot != -1 ?
                Path.Combine(ChronoSaverPath, "usrSaves", (SelectedSlot + 1).ToString())
                : userSavePath;
            //отладочная информация
            path.Text = userSavePath;//костыль. по хорошему надо через binding
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            ((Image)sender).GetBindingExpression(Image.SourceProperty)
                              .UpdateTarget();
        }

      
    }
}

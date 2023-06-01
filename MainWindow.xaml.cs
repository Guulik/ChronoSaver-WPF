using System;
using System.Windows;
using System.Windows.Controls;

namespace ChronoSaver 
{ 
    public partial class MainWindow : Window
    {
        static string sourcePath =
            @"P:\Games\The legend of Zelda\mlc01\usr\save\00050000\101c9500\user\80000001";
        static string userSavePath =
            @"P:\Games\The legend of Zelda\ChronoSaver\usrSaves\unAllocated";
        static string testPath = 
            @"P:\Games\The legend of Zelda\ChronoSaver\test\destination";//for load function

        //copy FROM src TO dst
        public static void Copy(string src, string dst) 
        {FileMethods.CopyDirectory(src, dst);}

        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Copy(sourcePath, userSavePath);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Copy(userSavePath, testPath);
        }
        private void SlotRadioButton_Click(object sender, RoutedEventArgs e)
        {
            // Действия при выборе слота
            // Например, изменение состояния или выполнение других операций
            RadioButton radioButton = (RadioButton)sender;
            // Отменить выбор предыдущего RadioButton в группе
            foreach (var child in grid.Children)
            {
                if (child is RadioButton rb && rb != radioButton && rb.GroupName == radioButton.GroupName)
                {
                    rb.IsChecked = false;
                }
            }
        }
    }
}

using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using KORGOPOLOV555.ViewModel;
using Microsoft.Win32;

namespace KORGOPOLOV555
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _fileContents;
        public string FileContents
        {
            get { return _fileContents; }
            set
            {
                _fileContents = value;
                NotifyPropertyChanged("FileContents");
            }
        }

        private string _statusBarContent;
        public string StatusBarContent
        {
            get { return _statusBarContent; }
            set
            {
                _statusBarContent = value;
                NotifyPropertyChanged("StatusBarContent");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public BindableCommand OpenFileCommand { get; set; }
        public BindableCommand SaveFileCommand { get; set; }
        public BindableCommand CloseApplicationCommand { get; set; }

        public MainViewModel()
        {
            OpenFileCommand = new BindableCommand(_ => OpenFile());
            SaveFileCommand = new BindableCommand(_ => SaveFile());
            CloseApplicationCommand = new BindableCommand(_ => CloseApplication());
        }



        public void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                FileContents = File.ReadAllText(filePath);
                StatusBarContent = "Unsaved changes";
            }
        }

        public void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt|JSON Files|*.json|XML Files|*.xml";

            if (saveFileDialog.ShowDialog() == true)
            {
                string savePath = saveFileDialog.FileName;
                File.WriteAllText(savePath, FileContents);
                MessageBox.Show("File saved successfully.", "Save File", MessageBoxButton.OK);
                StatusBarContent = "Ready";
            }
        }

        public void CloseApplication()
        {
            if (StatusBarContent == "Unsaved changes")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the changes before closing?", "Unsaved Changes", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFile();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            Application.Current.Shutdown();
        }
    }
}
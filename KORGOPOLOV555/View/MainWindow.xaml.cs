using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace KORGOPOLOV555.View
{
    public partial class MainWindow : Window
    {
        private string filePath;

        public MainWindow()
        {
            
            InitializeComponent();
            DataContext = new MainViewModel();
        }

       



        /*
private void OpenFileButton_Click(object sender, RoutedEventArgs e)
{
  OpenFileDialog openFileDialog = new OpenFileDialog();
  openFileDialog.Filter = "Text Files (*.txt)|*.txt|JSON Files (*.json)|*.json|XML Files (*.xml)|*.xml";

  if (openFileDialog.ShowDialog() == true)
  {
      filePath = openFileDialog.FileName;
      string fileContents = File.ReadAllText(filePath);
      FileContents.Text = fileContents;
  }
}

private void SaveFileButton_Click(object sender, RoutedEventArgs e)
{
  SaveFileDialog saveFileDialog = new SaveFileDialog();
  saveFileDialog.Filter = "Text Files|*.txt|JSON Files|*.json|XML Files|*.xml";

  if (saveFileDialog.ShowDialog() == true)
  {
      string savePath = saveFileDialog.FileName;
      File.WriteAllText(savePath, FileContents.Text);
      MessageBox.Show("File saved successfully.", "Save File", MessageBoxButton.OK);
  }
}
*/

        /*

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusBar.Content.ToString() == "Unsaved changes")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the changes before closing?", "Unsaved Changes", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFileButton_Click(sender, e);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            Application.Current.Shutdown();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (StatusBar.Content.ToString() == "Unsaved changes")
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save the changes before closing?", "Unsaved Changes", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    SaveFileButton_Click(sender, null);
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }*/


    }
}

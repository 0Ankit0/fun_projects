using Microsoft.WindowsAPICodePack.Dialogs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace TemplateWizard.Windows
{
    public class MyInputViewModel : INotifyPropertyChanged
    {
        private string _modal;
        private string _template;
        private string _fileName;
        private string _filePath;
        private string _selectedTemplate;

        public ObservableCollection<string> Templates { get; set; }

        public string Modal
        {
            get => _modal;
            set
            {
                _modal = value;
                OnPropertyChanged();
            }
        }

        public string Template
        {
            get => _template;
            set
            {
                _template = value;
                OnPropertyChanged();
            }
        }

        public string FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                OnPropertyChanged();
            }
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTemplate
        {
            get => _selectedTemplate;
            set
            {
                _selectedTemplate = value;
                OnPropertyChanged();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand BrowseTemplateFileCommand { get; }

        public MyInputViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
            BrowseTemplateFileCommand = new RelayCommand(BrowseTemplateFile);
        }

        private void BrowseTemplateFile()
        {
            var dlg = new CommonOpenFileDialog
            {
                Filters = { new CommonFileDialogFilter("T4 Files", "*.tt") }
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SelectedTemplate = dlg.FileName;
            }
        }

        private void Submit()
        {
            string message = $"Modal: {Modal}\nTemplate: {SelectedTemplate}\nFile Name: {FileName}\nFile Path: {FilePath}";
            System.Windows.MessageBox.Show(message, "Input Values", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

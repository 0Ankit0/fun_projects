using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.CodeAnalysis.CSharp;

namespace TemplateWizard.Windows
{
    public class MyInputViewModel : INotifyPropertyChanged
    {
        private string _modal;
        private string _template;
        private string _fileName;
        private string _filePath;
        private string _selectedModal;
        private string _selectedTemplate;

        public ObservableCollection<string> Modals { get; set; }
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

        public string SelectedModal
        {
            get => _selectedModal;
            set
            {
                _selectedModal = value;
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
        public ICommand BrowseFolderCommand { get; }
        public ICommand BrowseTemplateFileCommand { get; }

        public MyInputViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
            BrowseFolderCommand = new RelayCommand(BrowseFolder);
            BrowseTemplateFileCommand = new RelayCommand(BrowseTemplateFile);
            LoadModalsAsync().ConfigureAwait(false);
            LoadTemplates();
        }

        private async Task LoadModalsAsync()
        {
            Modals = new ObservableCollection<string>();

            // Define the folders to check
            var foldersToCheck = new[] { "Model", "Models" };

            // Register MSBuild instance
            MSBuildLocator.RegisterDefaults();

            // Get the current solution path
            var solutionPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "YourSolution.sln");

            using (var workspace = MSBuildWorkspace.Create())
            {
                var solution = await workspace.OpenSolutionAsync(solutionPath);

                foreach (var project in solution.Projects)
                {
                    foreach (var document in project.Documents)
                    {
                        var filePath = document.FilePath;

                        // Check if the document's file path contains any of the specified folders
                        if (foldersToCheck.Any(folder => filePath.Contains(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder))))
                        {
                            var syntaxTree = await document.GetSyntaxTreeAsync();
                            var semanticModel = await document.GetSemanticModelAsync();

                            var types = (await semanticModel.SyntaxTree.GetRootAsync()).DescendantNodes()
                                .OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>()
                                .Select(c => c.Identifier.Text);

                            foreach (var type in types)
                            {
                                Modals.Add(type);
                            }
                        }
                    }
                }
            }
        }

        private void LoadTemplates()
        {
            Templates = new ObservableCollection<string>();

            string templateDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template");
            if (Directory.Exists(templateDirectory))
            {
                var templateFiles = Directory.GetFiles(templateDirectory, "*.t4");
                foreach (var file in templateFiles)
                {
                    Templates.Add(file);
                }
            }
        }

        private void BrowseFolder()
        {
            var dlg = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                FilePath = dlg.FileName;
            }
        }

        private void BrowseTemplateFile()
        {
            var dlg = new CommonOpenFileDialog
            {
                Filters = { new CommonFileDialogFilter("T4 Files", "*.t4") }
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                SelectedTemplate = dlg.FileName;
                Templates.Add(SelectedTemplate);
            }
        }

        private void Submit()
        {
            string message = $"Modal: {SelectedModal}\nTemplate: {SelectedTemplate}\nFile Name: {FileName}\nFile Path: {FilePath}";
            System.Windows.MessageBox.Show(message, "Input Values", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

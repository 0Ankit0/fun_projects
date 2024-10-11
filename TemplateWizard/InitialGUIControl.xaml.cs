using System;
using System.Windows;
using System.Windows.Controls;

namespace TemplateWizard
{
    public partial class InitialGUIControl : UserControl
    {
        public InitialGUIControl()
        {
            InitializeComponent();
        }

        private void OnCreateFileButtonClick(object sender, RoutedEventArgs e)
        {
            // Retrieve values from input fields
            var selectedModal = (ComboBoxItem)ModalComboBox.SelectedItem;
            var fileName = FileNameTextBox.Text;
            var selectedTemplate = (ComboBoxItem)TemplateComboBox.SelectedItem;
            var selectedFolder = FolderTextBox.Text;

            // Perform your logic here
            if (selectedModal == null || string.IsNullOrWhiteSpace(fileName) || selectedTemplate == null || string.IsNullOrWhiteSpace(selectedFolder))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Example: Read template content (you need to implement GetTemplateContent)
                string templateContent = GetTemplateContent(selectedTemplate.Content.ToString());

                // Create the file in the selected folder
                string filePath = System.IO.Path.Combine(selectedFolder, fileName);
                System.IO.File.WriteAllText(filePath, templateContent);

                MessageBox.Show($"File created successfully at {filePath}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GetTemplateContent(string templateName)
        {
            // TODO: Implement logic to retrieve the template content based on the template name
            // This is just a placeholder example
            return $"// Template: {templateName}\n\npublic class {templateName} {{ }}";
        }
    }
}

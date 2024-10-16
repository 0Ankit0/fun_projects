using System.Windows.Controls;

namespace TemplateWizard.Windows
{
    public partial class MyInputWindow : UserControl
    {
        public MyInputWindow()
        {
            InitializeComponent();
            DataContext = new MyInputViewModel();
        }

        private void SubmitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is MyInputViewModel viewModel)
            {
                viewModel.SubmitCommand.Execute(null);
            }
        }
    }
}

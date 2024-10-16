using Microsoft.VisualStudio.Shell;
using System;
using System.Threading.Tasks;

namespace TemplateWizard
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            ToolWindowPane window = await this.Package.ShowToolWindowAsync(
                typeof(Windows.MyToolWindow), 0, true, this.Package.DisposalToken);
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException("Cannot create tool window");
            }
        }
    }
}

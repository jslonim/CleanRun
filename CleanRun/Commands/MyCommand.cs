using Microsoft.VisualStudio.Shell.Interop;

namespace CleanRun
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            await VS.Build.BuildSolutionAsync(BuildAction.Clean);
            (await VS.Services.GetSolutionBuildManagerAsync()).DebugLaunch((uint)VSSOLNBUILDUPDATEFLAGS.SBF_OPERATION_LAUNCHDEBUG);
        }
    }
}

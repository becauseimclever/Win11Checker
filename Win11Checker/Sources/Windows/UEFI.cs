using System.Linq;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;

namespace Win11Checker.Sources.Windows
{
    public class UEFI
    {
        public static async Task<Models.UEFI> GetUEFIAsync()
        {
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var SecureBootCmd = new Command("Confirm-SecureBootUEFI");
            pipeline.Commands.Add(SecureBootCmd);
            var SbOutput = pipeline.Invoke();

            return await Task.FromResult(new Models.UEFI { SecureBoot = bool.Parse(SbOutput.First().ToString()) });
        }
    }
}
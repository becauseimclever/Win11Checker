using System.Linq;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;

namespace Win11Checker.Sources.Windows
{
    public class TPM
    {
        public static async Task<Models.TPM> GetTPM()
        {
            var runSpace = RunspaceFactory.CreateRunspace();
            runSpace.Open();
            var pipeline = runSpace.CreatePipeline();
            var tpmCmd = new Command("Get-TPM");
            pipeline.Commands.Add(tpmCmd);
            var tpmOutput = pipeline.Invoke();
            return await Task.FromResult(new Models.TPM { IsPresent= bool.Parse(tpmOutput.First().Properties["TpmPresent"].Value.ToString()) });
        }
    }
}

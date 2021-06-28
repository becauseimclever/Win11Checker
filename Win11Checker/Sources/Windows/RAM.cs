using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win11Checker.Sources.Windows
{
	public class RAM
	{
		public async static Task<Models.RAM> GetRAMAsync()
		{
			return await Task.FromResult(new Models.RAM());
		}
	}
}

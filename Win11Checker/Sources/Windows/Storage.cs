using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win11Checker.Sources.Windows
{
	public class Storage
	{
		public static async Task<Models.Storage> GetStorageAsync()
		{
			return await Task.FromResult(new Models.Storage());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Homework12
{
	delegate void RecyclingFileHandler(Product product);
	class Writer
	{
		private string filePath;

		public Writer(string filePath)
		{
			this.filePath = filePath;
		}

		public Writer() : this("../../../Recycling.txt") { }

		public void WriteToFile(Product product)
		{
			using (StreamWriter writer = new StreamWriter(filePath, true))
			{
				writer.WriteLine(product);
				writer.Close();
			}
		}

		public void ClearFile()
        {
			File.WriteAllText(filePath, String.Empty);
        }
	}
}

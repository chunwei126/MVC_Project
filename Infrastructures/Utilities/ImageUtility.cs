using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Utilities
{
	public class ImageUtility
	{
		public static bool IsImage(string fileName)
		{
			if (fileName == null) return false;

			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			string[] imageExts = new string[] { ".gif", ".bmp", ".png", ".jpg", ".jpeg" };

			return imageExts.Contains(ext);
		}
	}
}

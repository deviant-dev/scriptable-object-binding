using System.IO;
using UnityEngine;

namespace Deviant.Utils {
	public static class FileUtils {
		public static void WriteAllText(string path, string contents) {
			CreateFoldersFor(path);
			File.WriteAllText(path, contents);
		}

		public static void CreateFoldersFor(string path) {
			if (path.IsNullorEmpty()) {
				Debug.LogWarning("Can't make a directory for an empty path.");
				return;
			}

			string folder = Path.GetDirectoryName(path);

			if (folder.IsNullorEmpty() || Directory.Exists(folder)) { return; }

			Directory.CreateDirectory(folder);
		}
	}
}
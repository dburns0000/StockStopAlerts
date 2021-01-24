using System;
using Microsoft.Win32;		// for Registry classes

namespace StockStopAlerts
{
	/// <summary>
	/// Manages user settings and saved folder locations via the Windows registry.
	/// </summary>
	public static class Settings
	{
		const string appRegKey = "StockStopAlerts";
		const string foldersKey = "Folders";
		const string filesKey = "Files";
		
		/// <summary>
		/// Given a full pathname, extracts the parent folder and saves it the registry in the 'name' key.
		/// Typically called after the user selects a file with the Open/SaveFileDialog.
		/// </summary>
		/// <param name="name">Registry value to store folder derived from pathName into.</param>
		/// <param name="pathName">Full pathname of a file.</param>
		public static void SaveInitialFolder(string name, string pathName)
		{
            if (name == null || pathName == null)
                return;
			int pos = pathName.LastIndexOf('\\');
			if (pos == -1)
				return;
			string folder = pathName.Substring(0, pos);
            string regKey = appRegKey + "\\" + filesKey;
            RegistryKey reg = Registry.CurrentUser.OpenSubKey(regKey, true);
            if (reg == null)
                reg = Registry.CurrentUser.CreateSubKey(regKey);
            reg.SetValue(name, folder);
        }

		/// <summary>
		/// Saves a file name in the registry in the 'name' key.
		/// Typically called after the user selects a file with the FileBrowser.
		/// </summary>
		/// <param name="name">Registry value to store file name into.</param>
		/// <param name="file">Name of file</param>
		public static void SaveSelectedFile(string name, string file)
		{
            if (name == null || file == null)
                return;
            string regKey = appRegKey + "\\" + filesKey;
			RegistryKey reg = Registry.CurrentUser.OpenSubKey(regKey, true);
			if (reg == null)
				reg = Registry.CurrentUser.CreateSubKey(regKey);
			reg.SetValue(name, file);
		}

		/// <summary>
		/// Retrieves a folder name from the registry previously saved by a call to SetInitialFolder.
		/// Typically called prior to invoking an Open/SaveFileDialog to set its InitialDirectory property.
		/// </summary>
		/// <param name="name">Registry value to get folder from</param>
		/// <returns></returns>
		public static string GetInitialFolder(string name)
		{
            if (name == null)
                return "";
			string regKey = appRegKey + "\\" + foldersKey;
			RegistryKey reg = Registry.CurrentUser.OpenSubKey(regKey);
			if (reg != null)
				return (string)reg.GetValue(name, "");
			else
				return "";
		}

		/// <summary>
		/// Retrieves a file name from the registry previously saved by a call to SaveSelectedFile.
		/// </summary>
		/// <param name="name">Registry value to get the file name from</param>
		/// <returns>File name</returns>
		public static string GetSelectedFile(string name)
		{
            if (name == null)
                return "";
            string regKey = appRegKey + "\\" + filesKey;
			RegistryKey reg = Registry.CurrentUser.OpenSubKey(regKey, true);
			if (reg != null)
				return (string)reg.GetValue(name, "");
			else
				return "";
		}
		
	}

}   // namespace

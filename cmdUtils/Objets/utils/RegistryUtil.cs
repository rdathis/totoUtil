/*
 * Utilisateur: Renaud
 * Date: 03/04/2017
 * Heure: 13:45:53
 * 
 */
using System;

namespace cmdUtils.Objets.utils
{
	/// <summary>
	/// Description of RegistryUtil.
	/// </summary>
	public class RegistryUtil
	{
		public const String mouliUtilPath="Software\\Rfx\\MeoMillser";
		public const String key="path";
		public RegistryUtil()
		{
		}
		
		public void setHKCUString(String subKey, String name, String value) {
			Microsoft.Win32.RegistryKey key;
			key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(subKey);
			key.SetValue(name, value);
			key.Close();
		}
		public String getHKCUString(String subKey, String name) {
			//try {..} outside
			return (string)Microsoft.Win32.Registry.CurrentUser.GetValue(name);
		}
	}
}

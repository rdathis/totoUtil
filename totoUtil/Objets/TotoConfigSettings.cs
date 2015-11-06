/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 27/04/2015
 * Time: 08:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;   
using System.Configuration;

namespace totoUtil.Objets
{
	/// <summary>
	/// Configuration section &lt;TotoConfig&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute 
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class TotoConfigSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;
		const String mcExePath_="mcExePath";
		const String mcExePath_Default_=@"C:/Program Files (x86)/Minecraft/MinecraftLauncher.exe";
		const String mcProfilePath_="mcProfilePath";
		const String cygwinPath_="cygwinPath_";
		const String regexDefault_="regexDefault";
		const String user_="user";

		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection 
		 *  from the with the file named TotoConfig.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public TotoConfigCollection TotoConfig
		// {
		// 	get { return (TotoConfigCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Collection of <c>TotoConfigElement(s)</c> 
		/// A custom XML section for an applications configuration file.
		/// </summary>
		[ConfigurationProperty(mcExePath_, DefaultValue=mcExePath_Default_)]
		public string mcExePath {
			get { return (string) this[mcExePath_]; }
			set { this[mcExePath_] = value; }
		}

		[ConfigurationProperty(user_, DefaultValue="user")]
		public string user {
			get { return (string) this[user_]; }
			set { this[user_] = value; }
		}
		
		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private TotoConfigSettings () : base () {
			// Allow this section to be stored in user.app. By default this is forbidden.
			this.SectionInformation.AllowExeDefinition =
				ConfigurationAllowExeDefinition.MachineToLocalUser;
		}

		#region Public Methods
		
		/// <summary>
		/// Saves the configuration to the config file.
		/// </summary>
		public void Save() {
			_Config.Save();
		}
		
		#endregion
		
		#region Static Members
		
		/// <summary>
		/// Gets the current applications &lt;TotoConfig&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;TotoConfig&gt; section.
		/// </returns>
		public static TotoConfigSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;TotoConfig&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */ 
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			TotoConfigSettings config;
			
			config =(TotoConfigSettings)Config.GetSection("TotoConfigSettings");
			if (config == null) {
				config = new TotoConfigSettings();
				Config.Sections.Add("TotoConfigSettings", config);
			}
			config._Config = Config;
			
			return config;
		}
		
		#endregion
	}
}


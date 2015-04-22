/*
 * Created by SharpDevelop.
 * User: athis_000
 * Date: 20/04/2015
 * Time: 20:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.IO;

namespace cmdUtils
{
	/// <summary>
	/// Configuration section &lt;ConfigSection&gt;
	/// </summary>
	/// <remarks>
	/// Assign properties to your child class that has the attribute
	/// <c>[ConfigurationProperty]</c> to store said properties in the xml.
	/// </remarks>
	public sealed class ConfigSectionSettings : ConfigurationSection
	{
		System.Configuration.Configuration _Config;
		
		const String mysqlExePath_="mysqlExePath";
		const String gunzipExePath_="gunzipExePath";
		const String scriptsPath_ ="scriptsPath";
		const String cygwinPath_="cygwinPath";
		const String cygwinGzip_="cygwinGzip";

		#region ConfigurationProperties
		
		/*
		 *  Uncomment the following section and add a Configuration Collection
		 *  from the with the file named ConfigSection.cs
		 */
		// /// <summary>
		// /// A custom XML section for an application's configuration file.
		// /// </summary>
		// [ConfigurationProperty("customSection", IsDefaultCollection = true)]
		// public ConfigSectionCollection ConfigSection
		// {
		// 	get { return (ConfigSectionCollection) base["customSection"]; }
		// }

		/// <summary>
		/// Collection of <c>ConfigSectionElement(s)</c>
		/// A custom XML section for an applications configuration file.
		/// </summary>
		[ConfigurationProperty("exampleAttribute", DefaultValue="exampleValue")]
		public string ExampleAttribute {
			get { return (string) this["exampleAttribute"]; }
			set { this["exampleAttribute"] = value; }
		}
		[ConfigurationProperty(mysqlExePath_, DefaultValue="m:/wamp/bin/mysql/mysql5.6.17/bin/mysql.exe")]
		public string mysqlExePath {
			get { return (string) this[mysqlExePath_]; }
			set { this[mysqlExePath_] = value; }
		}
		[ConfigurationProperty(cygwinPath_, DefaultValue="zm:/cygwin64/bin/")]
		public string cygwinPath {
			get { return (string) this[cygwinPath_]; }
			set { this[cygwinPath_] = value; }
		}

		[ConfigurationProperty(cygwinGzip_, DefaultValue="gzip.exe")]
		public string cygwinGzip {
			get { return (string) this[cygwinGzip_]; }
			set { this[cygwinGzip_] = value; }
		}
		[ConfigurationProperty(scriptsPath_, DefaultValue="m:/data/...")]
		public string scriptsPath {
			get { return (string) this[scriptsPath_]; }
			set { this[scriptsPath_] = value; }
		}
		
		#endregion

		/// <summary>
		/// Private Constructor used by our factory method.
		/// </summary>
		private ConfigSectionSettings () : base () {
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
		
		public Configuration getConfiguration() {
			return _Config;
		}
		#endregion
		
		#region Static Members
		
		/// <summary>
		/// Gets the current applications &lt;ConfigSection&gt; section.
		/// </summary>
		/// <param name="ConfigLevel">
		/// The &lt;ConfigurationUserLevel&gt; that the config file
		/// is retrieved from.
		/// </param>
		/// <returns>
		/// The configuration file's &lt;ConfigSection&gt; section.
		/// </returns>
		public static ConfigSectionSettings GetSection (ConfigurationUserLevel ConfigLevel) {
			/* 
			 * This class is setup using a factory pattern that forces you to
			 * name the section &lt;ConfigSection&gt; in the config file.
			 * If you would prefer to be able to specify the name of the section,
			 * then remove this method and mark the constructor public.
			 */
			System.Configuration.Configuration Config = ConfigurationManager.OpenExeConfiguration
				(ConfigLevel);
			ConfigSectionSettings oConfigSectionSettings;
			
			oConfigSectionSettings =
				(ConfigSectionSettings)Config.GetSection("ConfigSectionSettings");
			if (oConfigSectionSettings == null) {
				oConfigSectionSettings = new ConfigSectionSettings();
				Config.Sections.Add("ConfigSectionSettings", oConfigSectionSettings);
			}
			oConfigSectionSettings._Config = Config;
			
			return oConfigSectionSettings;
		}
		
		#endregion
	}
}


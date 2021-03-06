﻿/*
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
using System.Net.Mime;

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
		
		const String cygwinPath_="cygwinPath";
		const String cygwinTerm_="cygwinTerm";
		const String cygwinGzip_="cygwinGzip";
		
		const String mysqlUser_="mysqlUser";
		const String mysqlPassword_="mysqlPassword";
		
		const String dumpsPath_="dumpPath";

		/** scripts sections */
		const String scriptsPath_ ="scriptsPath";
		const String scriptCreate_="scriptCreate";
		const String scriptFileDb_="scriptCreateFileDb";
		/** moulinettes**/
		const String moulSrcPath_="moulSrcPath";
		const String moulDstPath_="moulDstPath";
		const String moulUploadS1_="moulUploadS1";
		const String moulUploadS2_="moulUploadS2";
		const String moulFichiers_="moulFichiers";
		
		
		
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
		/*
		[ConfigurationProperty("exampleAttribute", DefaultValue="exampleValue")]
		public string ExampleAttribute {
			get { return (string) this["exampleAttribute"]; }
			set { this["exampleAttribute"] = value; }
		}
		 */
		[ConfigurationProperty(mysqlExePath_, DefaultValue="m:/wamp/bin/mysql/mysql5.6.17/bin/mysql.exe")]
		public string mysqlExePath {
			get { return (string) this[mysqlExePath_]; }
			set { this[mysqlExePath_] = value; }
		}
		[ConfigurationProperty(cygwinPath_, DefaultValue="m:/cygwin64/bin/")]
		public string cygwinPath {
			get { return (string) this[cygwinPath_]; }
			set { this[cygwinPath_] = value; }
		}
		[ConfigurationProperty(cygwinTerm_, DefaultValue=" -i /Cygwin-Terminal.ico -")]
		public string cygwinTerm {
			get { return (string) this[cygwinTerm_]; }
			set { this[cygwinTerm_] = value; }
		}
		[ConfigurationProperty(cygwinGzip_, DefaultValue="gzip.exe")]
		public string cygwinGzip {
			get { return (string) this[cygwinGzip_]; }
			set { this[cygwinGzip_] = value; }
		}
		[ConfigurationProperty(scriptsPath_, DefaultValue="X:/data/...")]
		public string scriptsPath {
			get { return (string) this[scriptsPath_]; }
			set { this[scriptsPath_] = value; }
		}

		[ConfigurationProperty(mysqlUser_, DefaultValue="user")]
		public string mysqlUser {
			get { return (string) this[mysqlUser_]; }
			set { this[mysqlUser_] = value; }
		}
		
		[ConfigurationProperty(mysqlPassword_, DefaultValue="pwd")]
		public string mysqlPassword {
			get { return (string) this[mysqlPassword_]; }
			set { this[mysqlPassword_] = value; }
		}

		[ConfigurationProperty(dumpsPath_, DefaultValue="dump196")]
		public string dumpsPath {
			get { return (string) this[dumpsPath_]; }
			set { this[dumpsPath_] = value; }
		}


		[ConfigurationProperty(scriptCreate_, DefaultValue="createdatabase.sql")]
		public string scriptCreate {
			get { return (string) this[scriptCreate_]; }
			set { this[scriptCreate_] = value; }
		}
		[ConfigurationProperty(scriptFileDb_, DefaultValue="createFileDb.sql")]
		public string scriptFileDb {
			get { return (string) this[scriptFileDb_]; }
			set { this[scriptFileDb_] = value; }
		}

		[ConfigurationProperty(moulSrcPath_, DefaultValue="//192.168.1.200/echange/moulinette_meo/")]
		public string moulSrcPath {
			get { return (string) this[moulSrcPath_]; }
			set { this[moulSrcPath_] = value; }
		}
		[ConfigurationProperty(moulDstPath_, DefaultValue="W:/meo-moulinettes/")]
		public string moulDstPath {
			get { return (string) this[moulDstPath_]; }
			set { this[moulDstPath_] = value; }
		}

		[ConfigurationProperty(moulUploadS1_, DefaultValue="pscp s1")]
		public string moulUploadS1 {
			get { return (string) this[moulUploadS1_]; }
			set { this[moulUploadS1_] = value; }
		}
		[ConfigurationProperty(moulUploadS2_, DefaultValue="pscp s2")]
		public string moulUploadS2 {
			get { return (string) this[moulUploadS2_]; }
			set { this[moulUploadS2_] = value; }
		}
		[ConfigurationProperty(moulFichiers_, DefaultValue="ytoptic*.d ")]
		public string moulFichiers {
			get { return (string) this[moulFichiers_]; }
			set { this[moulFichiers_] = value; }
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
			const String configMainKey="ConfigSectionSettings";
			String file=getConfigFileName();
			String exePath = System.IO.Path.Combine(Environment.CurrentDirectory, file);
			
			//params xml node
			
			ConfigSectionSettings oConfigSectionSettings;

			//create precise config file
			if (!File.Exists(exePath)) {
				
				//lambda config
				Configuration tmpConfig = ConfigurationManager.OpenExeConfiguration
					(ConfigurationUserLevel.None);
				oConfigSectionSettings = new ConfigSectionSettings();
				tmpConfig.Sections.Add(configMainKey, oConfigSectionSettings);
				tmpConfig.SaveAs(exePath);
			}
			
			//loading config
			Configuration Config = ConfigurationManager.OpenExeConfiguration(exePath);
			

			//buildings objects
			oConfigSectionSettings =(ConfigSectionSettings)Config.GetSection(configMainKey);
			if (oConfigSectionSettings == null) {
				oConfigSectionSettings = new ConfigSectionSettings();
				Config.Sections.Add(configMainKey, oConfigSectionSettings);
			}
			oConfigSectionSettings._Config = Config;
			
			return oConfigSectionSettings;
		}
		public static String getConfigFileName() {
			return "totoConfig.cfg";
		}
		public static String getFullConfigFileName() {
			return getConfigFileName()+".config";
		}
		
		//TODO:try to make it better
		public void setSpecialValue(String key, String value) {
			
			if (key.Equals(mysqlExePath_)) {
				mysqlExePath=value;
			} else if (key.Equals(cygwinGzip_)) {
				cygwinGzip=value;
			} else if (key.Equals(cygwinPath_)) {
				cygwinPath=value;
			} else if (key.Equals(cygwinTerm_)) {
				cygwinTerm=value;
			} else if (key.Equals(mysqlUser_)) {
				mysqlUser=value;
			} else if (key.Equals(mysqlPassword_)) {
				mysqlPassword=value;
			} else if (key.Equals(mysqlExePath_)) {
				mysqlExePath=value;
			} else if (key.Equals(dumpsPath_)) {
				dumpsPath=value;
			} else if (key.Equals(scriptsPath_)) {
				scriptsPath=value;
			} else if (key.Equals(scriptCreate_)) {
				scriptCreate=value;
			} else if (key.Equals(scriptFileDb_)) {
				scriptFileDb=value;
			} else if (key.Equals(moulDstPath_)) {
				moulDstPath=value;
			} else if (key.Equals(moulSrcPath_)) {
				moulSrcPath=value;
			} else if (key.Equals(moulUploadS1_)) {
				moulUploadS1=value;
			} else if (key.Equals(moulUploadS2_)) {
				moulUploadS2=value;
			} else if (key.Equals(moulFichiers_)) {
				moulFichiers=value;
			}
		}
		
		

		#endregion
	}
}


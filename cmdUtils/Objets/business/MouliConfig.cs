/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 07/09/2016
 * Heure: 18:28:32
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */

using System;
using System.ComponentModel;
using System.IO;
namespace cmdUtils.Objets {
	
	// disable once ConvertToStaticType
	public class MouliConfig {
		
		// public const String serversConfigFile="conf/serveurs.xml";
		//public const String instancesConfigFile="conf/instances.xml";
		public const String commonConfigFile="conf/common.xml";
		public const String commonLoggingConfigFile="conf/logger.config.xml";
		public const String commonPersoConfigFile="conf/common.perso.xml";

		public enum MouliPrograms {
			puttyPath, pscpPath, plinkPath, unzipPath
		}
		public const String puttyPath="bin/putty.exe";
		public const String pscpPath="bin/pscp.exe";
		public const String plinkPath="bin/plink.exe";
		public const String unzipPath="bin/unzip.exe";
		public String getProgramPath(MouliPrograms program) {
			if(MouliPrograms.puttyPath.Equals(program)) {
				return puttyPath;
			} else if(MouliPrograms.pscpPath.Equals(program)) {
				return pscpPath;
			} else if(MouliPrograms.plinkPath.Equals(program)) {
				return plinkPath;
			} else if (MouliPrograms.unzipPath.Equals(program)) {
				return unzipPath;
			}
			return null;
		}
		public String getFullPath(ConfigDto configDto, MouliPrograms program) {
			String path=getProgramPath(program);
			if(path!=null) {
				FileInfo fi = new FileInfo(path+"/"+program);
				path=fi.FullName;
				return path;
			}
			return "";
		}
	}
	
}
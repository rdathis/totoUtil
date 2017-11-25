/*
 * Utilisateur: Renaud
 * Date: 21/10/2016
 * Heure: 12:57:22
 * 
 */
using System;
using System.Collections.Generic;
using System.Xml;
using cmdUtils.Objets.business;

namespace cmdUtils.Objets
{
	/// <summary>
	/// </summary>
	public partial class ConfigDto
	{
		
		//volatile
		public string assemblyName {
			get;
			set;
		}
		//volatile
		public string versionInfo {
			get;
			set;
		}
		//volatile
		public string buildDateTime {
			get;
			set;
		}

		// !! no //[XmlAttribute], volatile
		private String programPath =null;
		//[XmlAttribute]
		public List<MeoServeur> serveurs;
		//[XmlAttribute]
		public List<MeoInstance> instances;

		//[XmlAttribute]
		public List <MeoSql> sqlcommands;
		
		public List<ConfigParam> configParams;
		
		public void setProgramPath(String value) {
			programPath=value;
		}
		public String getProgramPath() {
			return programPath;
		}
		public String basePath { get; set ;}
		public ConfigDto()
		{

		}
		
		public List <MeoSql> getSqlCommands () {
			return sqlcommands;
		}
		public MeoSql getSql(SqlCommandsType commande) {
			foreach(MeoSql meoSql in sqlcommands) {
				if(meoSql.nom.Equals(commande.ToString())) {
					return meoSql;
				}
			}
			return null;
		}
		public Object getSql(String nom) {
			foreach(SqlCommandsType commands in Enum.GetValues(typeof(SqlCommandsType))) {
				if(commands.ToString().Equals(nom) ) {
					return commands;
				}
			}
			return null;
		}
		public void setSql(SqlCommandsType commande, String value) {
			MeoSql meoSql = getSql(commande);
			if(meoSql!=null) {
				meoSql.Value=value;
			}

		}

		public String getSqlCommand(SqlCommandsType commande) {
			MeoSql meoSql = getSql(commande);
			if(meoSql!=null) {
				return meoSql.Value;
			}
			return null;
		}
		
		
		public List<MeoServeur> getServeurs()
		{
			return serveurs;
		}
		public List<MeoInstance> getInstances()
		{
			return  instances;
		}
		
		public  void setServeurs(List<MeoServeur> value)
		{
			serveurs = value;
		}
		public void setInstances(List<MeoInstance> value)
		{
			instances = value;
		}
		public void setTargetSvgPath(String value)
		{
			setConfigParamValueByName(ConfigParam.ParamNamesType.targetSvgPath, value);
		}
		public String getTargetSvgPath()
		{
			return getConfigParamValueByName(ConfigParam.ParamNamesType.targetSvgPath);
		}

		public string getDatabaseAdminUser()
		{
			return getConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminUser);
		}
		public string getDatabaseAdminPwd()
		{
			return getConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminPwd);
		}
		public string getDatabaseAdminName()
		{
			return getConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminName);
		}
		//
		public void setDatabaseAdminUser(String value)
		{
			setConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminUser, value);
		}
		public void setDatabaseAdminPwd(String value) {
			setConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminPwd, value);
		}
		public void setDatabaseAdminName(String value){
			setConfigParamValueByName(ConfigParam.ParamNamesType.databaseAdminName, value);
		}
		public String getDefaultPassword() {
			return getConfigParamValueByName(ConfigParam.ParamNamesType.defaultPassword);
		}
		public void setDefaultPassword(String value) {
			setConfigParamValueByName(ConfigParam.ParamNamesType.defaultPassword, value);
		}
//		public String getAppPlink() {
//			return getConfigParamValueByName(ConfigParam.ParamNamesType.appPlink);
//		}
//		public void setAppPlink(String value) {
//			setConfigParamValueByName(ConfigParam.ParamNamesType.appPlink, value);
//		}
		public void setDefaultEmail(String value) {
			setConfigParamValueByName(ConfigParam.ParamNamesType.defaultEmail, value);
		}
		public String getDefaultEmail() {
			return getConfigParamValueByName(ConfigParam.ParamNamesType.defaultEmail);
		}
		public void setWorkingDir(String value) {
			setConfigParamValueByName(ConfigParam.ParamNamesType.workingDir, value);
		}
		public String getWorkingDir() {
			return getConfigParamValueByName(ConfigParam.ParamNamesType.workingDir);
		}

		public String getConfigParamValueByName(ConfigParam.ParamNamesType paramName) {
			String str="";
			ConfigParam param =getConfigParamByName(paramName);
			if(param!=null) {
				str=param.Value;
			}
			return str;
		}
		public void setConfigParamValueByName(ConfigParam.ParamNamesType paramName, String value) {
			ConfigParam param =getConfigParamByName(paramName);
			if(param!=null) {
				param.Value=value;;
			}
		}
		
		public ConfigParam getConfigParamByName(ConfigParam.ParamNamesType paramName) {
			return getConfigParamByName(paramName.ToString());
		}
		public ConfigParam getConfigParamByName(String nom) {
			if(configParams!=null) {
				foreach(ConfigParam configParam in configParams) {
					
					//dont work because serilization of enum
					if(configParam.nom.Equals(nom)) {
						return configParam;
					}
					//work.
					String tmp=configParam.nom.ToString();
					if(tmp.Equals(nom)) {
						return configParam;
					}
				}
			}
			return null;
		}

	}
}

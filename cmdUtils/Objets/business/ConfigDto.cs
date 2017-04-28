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
		//[XmlAttribute]
		public List<MeoServeur> serveurs;
		//[XmlAttribute]
		public List<MeoInstance> instances;

		//[XmlAttribute]
		public List <MeoSql> sqlcommands;
		
		public List<ConfigParam> configParams;
		
		public String targetSvgPath;
		public String databaseAdminUser;
		public String databaseAdminPwd;
		public String databaseAdminName;
		public String defaultPassword;
		public String appPlink;
		public String defaultEmail;
		public String workingDir;
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
			targetSvgPath = value;
		}
		public String getTargetSvgPath()
		{
			return targetSvgPath;
		}

		public string getDatabaseAdminUser()
		{
			return databaseAdminUser;
		}
		public string getDatabaseAdminPwd()
		{
			return databaseAdminPwd;
		}
		public string getDatabaseAdminName()
		{
			return databaseAdminName;
		}
		//
		public void setDatabaseAdminUser(String value)
		{
			databaseAdminUser = value;
		}
		public void setDatabaseAdminPwd(String value) {
			databaseAdminPwd = value;
		}
		public void setDatabaseAdminName(String value){
			databaseAdminName = value;
		}
		public String getDefaultPassword() {
			return defaultPassword;
		}
		public void setDefaultPassword(String value) {
			defaultPassword=value;
		}
		public String getAppPlink() {
			return appPlink;
		}
		public void setAppPlink(String value) {
			appPlink=value;
		}
		public void setDefaultEmail(String value) {
			defaultEmail=value;
		}
		public String getDefaultEmail() {
			return defaultEmail;
		}
		public void setWorkingDir(String value) {
			workingDir=value;
		}
		public String getWorkingDir() {
			if(workingDir==null) workingDir="";
			return workingDir;
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

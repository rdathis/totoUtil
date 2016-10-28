/*
 * Utilisateur: Renaud
 * Date: 21/10/2016
 * Heure: 12:57:22
 * 
 */
using System;
using System.Collections.Generic;
using System.Xml;

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

		public String targetSvgPath;
		public String databaseAdminUser;
		public String databaseAdminPwd;
		public String sql01;
		public String databaseAdminName;
		public String defaultPassword;
		
		public ConfigDto()
		{

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
		
		public string getSQL01()
		{
			return sql01;
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
		public void setDatabaseAdminPwd(String value)
		{
			databaseAdminPwd = value;
		}
		
		public void setSQL01(String value)
		{
			sql01 = value;
		}

		public void setDatabaseAdminName(String value)
		{
			databaseAdminName = value;
		}

		public String getDefaultPassword() {
			return defaultPassword;
		}
	}
}

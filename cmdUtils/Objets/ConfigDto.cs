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
		public String sql02;
		public String sql03;
		public String sql04;
		public String sql05;
		public String databaseAdminName;
		public String defaultPassword;
		public String appPlink;
		public String defaultEmail;
		public String workingDir;
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
		
		public string getSQL01() {
			return sql01;
		}
		public string getSQL02() {
			return sql02;
		}
		public string getSQL03() {
			return sql03;
		}
		public string getSQL04() {
			return sql04;
		}
		public string getSQL05() {
			return sql05;
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
		
		public void setSQL01(String value) {
			sql01 = value;
		}
		public void setSQL02(String value){
			sql02 = value;
		}
		public void setSQL03(String value){
			sql03 = value;
		}
		public void setSQL04(String value){
			sql04 = value;
		}
		public void setSQL05(String value){
			sql05 = value;
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
		
	}
}

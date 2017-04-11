﻿using System;
using System.Drawing;
using System.Windows.Forms;
using cmdUtils.Objets;
using cmdUtils.Objets.utils;
namespace MoulUtil.Forms
{
	/// <summary>
	/// param edition.
	/// </summary>
	public partial class MouliEditForm : Form
	{
		private ConfigDto configDto=null;
		// disable once FieldCanBeMadeReadOnly.Local
		private ConfigUtil configUtil =null;
//
		MouliParamEditorForm serveursForm ;
		MouliParamEditorForm instancesForm ;
		MouliParamEditorForm paramForm ;
		MouliParamEditorForm configForm ;
		
		public MouliEditForm(ConfigDto configDto)
		{
			InitializeComponent();
			this.configDto = configDto;
			
			populate(configDto);
			configUtil = new ConfigUtil();
		}
		// disable once ParameterHidesMember
		private void populate(ConfigDto configDto) {
			populateSql(configDto);
			populateStrings(configDto);
			populateWorkspacePath();
		}
		private void populateWorkspacePath() {
			RegistryUtil registryUtil = new RegistryUtil();
			workspaceBasePath.Text=registryUtil.getHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key);
		}
		// disable once ParameterHidesMember
		private void populateSql(ConfigDto configDto) {
			sql01.Text=configDto.getSQL01();
			sql02.Text=configDto.getSQL02();
			sql03.Text=configDto.getSQL03();
			sql04.Text=configDto.getSQL04();
			sql05.Text=configDto.getSQL05();
			//sql06.Text=configDto.getSQL01;
			
		}
		// disable once ParameterHidesMember
		private void populateStrings(ConfigDto configDto) {
			targetSvgPathBox.Text=configDto.getTargetSvgPath();
			databaseAdminUserBox.Text=configDto.getDatabaseAdminUser();
			databaseAdminPwdBox.Text=configDto.getDatabaseAdminPwd();
			databaseAdminNameBox.Text=configDto.getDatabaseAdminName();
			defaultPasswordBox.Text=configDto.getDefaultPassword();
			defaultEmailBox.Text=configDto.getDefaultEmail();
			appPlinkBox.Text=configDto.getAppPlink();
			workingDirBox.Text=configDto.getWorkingDir();
		}
		// disable once ParameterHidesMember
		private void updateBusiness(ConfigDto configDto) {
			updateBusinessSql(configDto);
			updateBusinessStrings(configDto);
			updateBusinessWorkspacePath();
		}
		private void updateBusinessWorkspacePath() {
			RegistryUtil registryUtil = new RegistryUtil();
			registryUtil.setHKCUString(RegistryUtil.mouliUtilPath, RegistryUtil.key, workspaceBasePath.Text);
		}
		// disable once ParameterHidesMember
		private void updateBusinessSql(ConfigDto configDto) {
			configDto.setSQL01(sql01.Text);
			configDto.setSQL02(sql02.Text);
			configDto.setSQL03(sql03.Text);
			configDto.setSQL04(sql04.Text);
			configDto.setSQL05(sql05.Text);
		}
		
		// disable once ParameterHidesMember
		private void updateBusinessStrings(ConfigDto configDto) {
			configDto.setTargetSvgPath(targetSvgPathBox.Text);
			configDto.setDatabaseAdminUser(databaseAdminUserBox.Text);
			configDto.setDatabaseAdminPwd(databaseAdminPwdBox.Text);
			configDto.setDatabaseAdminName(databaseAdminNameBox.Text);
			configDto.setDefaultPassword(defaultPasswordBox.Text);
			configDto.setDefaultEmail(defaultEmailBox.Text);
			configDto.setAppPlink(appPlinkBox.Text);
			configDto.setWorkingDir(workingDirBox.Text);
		}
		void SaveBtnClick(object sender, EventArgs e)
		{
			updateBusiness(configDto);
			configUtil.saveOldConfig();
			configUtil.saveConfig(configDto);
		}
		void OpenBtnClick(object sender, EventArgs e)
		{
			configDto = configUtil.getConfig();
			populate(configDto);
		}
		void RazBtnClick(object sender, EventArgs e)
		{
			populate(configDto);
		}
		void ServeursButtonsClick(object sender, EventArgs e)
		{
			serveursForm = new MouliParamEditorForm(configDto.serveurs);
			serveursForm.Show();
		}
		void InstancesButtonClick(object sender, EventArgs e)
		{
			instancesForm = new MouliParamEditorForm(configDto.instances);
			instancesForm.Show();
		}
		void SqlButtonClick(object sender, EventArgs e)
		{
			paramForm = new MouliParamEditorForm(configDto.sqlcommands);
			paramForm.Show();
			
		}
		void ParamButtonClick(object sender, EventArgs e)
		{
//			configForm = new MouliParamEditorForm(configDto.configParams);
//			configForm.Show();
			
		}
	}
}

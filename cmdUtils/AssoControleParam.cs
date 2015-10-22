/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 09/10/2015
 * Heure: 16:01:06
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Windows.Forms;
using System.Configuration;

namespace cmdUtils
{
	/// <summary>
	/// Description of AssoControleParam.
	/// </summary>
	public class AssoControleParam
	{
		private TextBox textbox;
		private String clefConfig;
		//private ConfigurationProperty property;
		private ConfigSectionSettings cfg;
		
		//ConfigSectionSettings
		public AssoControleParam()
		{
		}
		public AssoControleParam (ConfigSectionSettings cfg, String clefConfig, TextBox texbox) {
			setTextBox(textbox);
			this.cfg=cfg;
			this.clefConfig=clefConfig;
			//this.property=property;
		}
		public void paramToTextbox() {
			//textbox.Text=cfg.g;
		}
		public void texboxToParam() {
			cfg.setSpecialValue(clefConfig, textbox.Text);
		}
		/*
		public AssoControleParam(ConfigSectionSettings cfg, TextBox textbox, String clefConfig) {
			setClefConfig(clefConfig);
			setTextBox(textbox);
			valueToTextBox(cfg);
		}

		private void valueToTextBox(ConfigSectionSettings cfg)
		{
			getTextBox().Text=cfg.getConfiguration().GetSection(getClefConfig()).ToString();
		}
		
		public void saveValue(ConfigSectionSettings cfg) {

			
		}
		public void setClefConfig(string clefConfig) {
			this.clefConfig=clefConfig;
		}
		public String getClefConfig() {
			return this.clefConfig;
		}
		*/
		public void setTextBox(TextBox texbox) {
			this.textbox=texbox;
		}
		
		public TextBox getTextBox() {
			return this.textbox;
		}
		
	}
}

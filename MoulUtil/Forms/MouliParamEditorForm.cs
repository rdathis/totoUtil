/*
 * Utilisateur: Renaud
 * Date: 20/02/2017
 * Heure: 13:41:17
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using cmdUtils.Objets;
class InstancesEditedType
{
	//
	private List<MeoInstance> instances = null;
	public List<MeoInstance> Instance {
		get { return instances; }
	}
	public InstancesEditedType(List <MeoInstance> liste)
	{
		this.instances = liste;
	}
}
class ServeursEditedType
{
	private List<MeoServeur> serveurs = null;
	public List<MeoServeur> Serveur {
		get { return serveurs; }
	}
	public ServeursEditedType(List <MeoServeur> liste)
	{
		this.serveurs = liste;
	}
}
class MeoSqlEditedType
{
	private List<MeoSql> sqls = null;
	public List<MeoSql> Sql {
		get { return sqls; }
	}
	public MeoSqlEditedType(List <MeoSql> liste)
	{
		this.sqls = liste;
	}
}

class ConfigParamEditedType
{
	private List<ConfigParam> liste = null;
	public List<ConfigParam> Valeurs {
		get { return liste; }
	}
	public ConfigParamEditedType(List <ConfigParam> liste)
	{
		this.liste = liste;
	}
}
class ConfigDtoEditedType
{
	private ConfigDto configDto = null;
	public ConfigDto Values {
		get { return configDto; }
	}
	public ConfigDtoEditedType(ConfigDto configDto)
	{
		this.configDto = configDto;
	}
}


[Editor(typeof(ParamEditorEditor), typeof(UITypeEditor))]
[TypeConverter(typeof(ExpandableObjectConverter))]
class ParamEditorEditor : UITypeEditor
{
	public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
	{
		return UITypeEditorEditStyle.Modal;
	}
	public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
	{
		IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
		/*
		Bidule bidule = value as Bidule;
		if (svc != null && bidule != null)
		{
			using (EditParamForm form = new EditParamForm())
			{
				form.Value = bidule.nom;
				if (svc.ShowDialog(form) == DialogResult.OK)
				{
					bidule.nom = form.Value; // update object
				}
			}
		}
		 */
		return value; // can also replace the wrapper object here
	}
}
class EditParamForm : Form
{
	private TextBox textbox;
	private Button okButton;
	public EditParamForm()
	{
		textbox = new TextBox();
		Controls.Add(textbox);
		okButton = new Button();
		okButton.Text = "OK";
		okButton.Dock = DockStyle.Bottom;
		okButton.DialogResult = DialogResult.OK;
		Controls.Add(okButton);
	}
	public string Value {
		get { return textbox.Text; }
		set { textbox.Text = value; }
	}
}

class MouliParamEditorForm : Form
{
	PropertyGrid grid = null;
	private void init()
	{
		Application.EnableVisualStyles();
		grid = new PropertyGrid();
		grid.Dock = DockStyle.Fill;
		this.Controls.Add(grid);
	}

	public MouliParamEditorForm(List<MeoInstance> liste)
	{
		init();
		grid.SelectedObject = new InstancesEditedType(liste);
	}

	public MouliParamEditorForm(List<MeoServeur> liste)
	{
		init();
		grid.SelectedObject = new ServeursEditedType(liste);
	}
	public MouliParamEditorForm(List<MeoSql> liste)
	{
		init();
		grid.SelectedObject = new  MeoSqlEditedType(liste);
	}
	
	public MouliParamEditorForm(List<ConfigParam> liste)
	{
		init();
		grid.SelectedObject = new  ConfigParamEditedType(liste);
	}
	
	public MouliParamEditorForm(ConfigDto config)
	{
		init();
		grid.SelectedObject = new  ConfigDtoEditedType(config);
	}
}
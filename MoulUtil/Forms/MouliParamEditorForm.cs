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
class EditedType
{
	//
	private List<MeoInstance> instances=null;
	public List<MeoInstance> Instance {
		get {return instances; }
	}
	//
	private List<MeoServeur> serveurs= null;
	public List<MeoServeur> Serveur  {
		get { return serveurs; }
	}
	//
	private List<MeoSql> sqls= null;
	public List<MeoSql> Sql  {
		get { return sqls; }
	}
	//
	public EditedType(List <MeoServeur> liste) {
		this.serveurs=liste;
	}
	public EditedType(List <MeoInstance> liste) {
		this.instances=liste;
	}
	public EditedType(List <MeoSql> liste) {
		this.sqls=liste;
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
	public EditParamForm() {
		textbox = new TextBox();
		Controls.Add(textbox);
		okButton = new Button();
		okButton.Text = "OK";
		okButton.Dock = DockStyle.Bottom;
		okButton.DialogResult = DialogResult.OK;
		Controls.Add(okButton);
	}
	public string Value
	{
		get { return textbox.Text; }
		set { textbox.Text = value; }
	}
}

class MouliParamEditorForm : Form {
	PropertyGrid grid=null;
	private void init() {
		Application.EnableVisualStyles();
		grid = new PropertyGrid();
		grid.Dock = DockStyle.Fill;
		this.Controls.Add(grid);
	}

	public MouliParamEditorForm (List<MeoInstance> liste) {
		init();
		grid.SelectedObject = new EditedType(liste);
	}

	public MouliParamEditorForm (List<MeoServeur> liste) {
		init();
		grid.SelectedObject = new EditedType(liste);
	}
	public MouliParamEditorForm (List<MeoSql> liste) {
		init();
		grid.SelectedObject = new EditedType(liste);
	}
	
	
}
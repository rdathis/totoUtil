using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using cmdUtils.Objets;
class EditedType
{
	private List<MeoInstance> instances=null;
	public List<MeoInstance> Instance {
		get {return instances; }
	}
	private List<Bidule> bidules= null;
	public List<Bidule> Bidule  {
		get { return bidules; }
	}
	public EditedType(List <Bidule> liste) {
		this.bidules=liste;
	}
	public EditedType(List <MeoInstance> liste) {
		this.instances=liste;
		//this.bidules=liste;
	}
	
}

[Editor(typeof(ParamEditorEditor), typeof(UITypeEditor))]
[TypeConverter(typeof(ExpandableObjectConverter))]
class Bidule
{
	//private string nom;
	//private int age;
	//private DateTime entree;
	public Bidule() {
	}
	public Bidule(int age) {
		this.age=age;
	}
	
	public string prenom {
		get;
		set;
	}
	public string nom     {
		get;
		set;
	}
	public int age     {
		get;
		set;
	}
	public DateTime entree {
		get;
		set;
	}
}
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

class ParamEditorForm : Form {
	PropertyGrid grid=null;
	private void init() {
		Application.EnableVisualStyles();
		grid = new PropertyGrid();
		grid.Dock = DockStyle.Fill;
		this.Controls.Add(grid);
	}

	public ParamEditorForm (List<MeoInstance> liste) {
		init();
		grid.SelectedObject = new EditedType(liste);
	}

	public ParamEditorForm (List<Bidule> liste) {
		init();
		grid.SelectedObject = new EditedType(liste);
	}
}
static class Program
{
	[STAThread]
	static void Main()
	{
		{
			List<MeoInstance> liste = new List<MeoInstance>();
			liste.Add(new MeoInstance("s1", "s1", "s1", "cli-s1", "http://s1.com"));
			liste.Add(new MeoInstance("s2", "s2", "s2", "cli-s2", "http://s2.com"));
			Application.Run(new ParamEditorForm(liste));
		}
		{
			List<Bidule> liste =new List<Bidule>();
			liste.Add(new Bidule(1));
			liste.Add(new Bidule(2));
			liste.Add(new Bidule(3));
			//
			Application.Run(new ParamEditorForm(liste));
		}
	}
}


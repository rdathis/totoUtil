﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
//using cmdUtils.Objets;
class EditedType
{
	private List<Bidule> bidules= null;
	public List<Bidule> Bidule  {
		get { return bidules; }
	}
	public EditedType(List <Bidule> liste) {
		this.bidules=liste;
	}
}

[Editor(typeof(ParamEditorEditor), typeof(UITypeEditor))]
[TypeConverter(typeof(ExpandableObjectConverter))]
class Bidule
{
	private string nom;
	private string prenom;
	private int age;
	private DateTime entree;
	public Bidule() {
	}
	public Bidule(int age) {
		this.age=age;
	}
	
	public string Prenom {
		get { return prenom; }
		set { prenom=value; }
	}
	public string Nom     {
		get { return nom; }
		set { nom = value; }
	}
	public int Age     {
		get { return age; }
		set { age = value; }
	}
	public DateTime Entree {
		get { return entree; }
		set { entree = value; }
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
		
		Bidule bidule = value as Bidule;
		if (svc != null && bidule != null)
		{
			using (EditParamForm form = new EditParamForm())
			{
				form.Value = bidule.Nom;
				if (svc.ShowDialog(form) == DialogResult.OK)
				{
					bidule.Nom = form.Value; // update object
				}
			}
		}
		
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
	/*
	public ParamEditorForm (List<MeoInstance> liste) {
		init();
		grid.SelectedObject = new MyType(liste);
	}
	*/
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
		/*
		List<MeoInstance> liste = new List<MeoInstance>();
		liste.Add(new MeoInstance("s1", "s1", "s1", "cli-s1", "http://s1.com"));
		liste.Add(new MeoInstance("s2", "s2", "s2", "cli-s2", "http://s2.com"));
		Application.Run(new ParamEditorForm(liste));
		*/
		List<Bidule> liste =new List<Bidule>();
		liste.Add(new Bidule(1));
		liste.Add(new Bidule(2));
		liste.Add(new Bidule(3));
		//
		Application.Run(new ParamEditorForm(liste));
	}
}


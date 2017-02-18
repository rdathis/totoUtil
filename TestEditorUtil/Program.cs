using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

class MyType
{
	//    private Bidule bidule = new Bidule();
	//    public Bidule Bidule { get { return bidule; } }
	
	private List<Bidule> bidules= null;
	public List<Bidule> Bidule  {
		get { return bidules; }
	}
	
	public MyType()	{
		bidules=new List<Bidule>();
		bidules.Add(new Bidule());
		bidules.Add(new Bidule());
	}
	//}
}

[Editor(typeof(BiduleEditor), typeof(UITypeEditor))]
[TypeConverter(typeof(ExpandableObjectConverter))]
class Bidule
{
	private string nom;
	private string prenom;
	private int age;
	private DateTime entree;
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
class BiduleEditor : UITypeEditor
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
			using (BiduleForm form = new BiduleForm())
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
class BiduleForm : Form
{
	private TextBox textbox;
	private Button okButton;
	public BiduleForm() {
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
static class Program
{
	[STAThread]
	static void Main()
	{
		Application.EnableVisualStyles();
		Form form = new Form();
		PropertyGrid grid = new PropertyGrid();
		grid.Dock = DockStyle.Fill;
		form.Controls.Add(grid);
		
		grid.SelectedObject = new MyType();
		Application.Run(form);
	}
}


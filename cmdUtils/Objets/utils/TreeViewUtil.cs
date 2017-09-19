/*
 * Utilisateur: Renaud
 * Date: 20/01/2017
 * Heure: 18:27:30
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of TreeViewUtil.
	/// </summary>
	public class TreeViewUtil
	{
		private List<MeoInstance> instances = null;
		private List<MeoServeur> serveurs = null;
		public TreeViewUtil(List<MeoInstance> instances, List<MeoServeur> serveurs)
		{
			this.instances=instances;
			this.serveurs=serveurs;
		}
		
		public void populateTargets(TreeView tv, String meoInstanceName=null)
		{
			if (serveurs != null) {
				foreach (MeoServeur serveur in serveurs) {
					TreeNode node = tv.Nodes.Add(serveur.getNom());
					if(serveur.test) {
						node.BackColor=Color.Orange;
						node.ToolTipText = "Serveur de TEST";
					} else {
						node.BackColor=Color.DarkRed;
						node.ForeColor = Color.Yellow;
						node.ToolTipText = "Serveur de Prod";
					}
					TreeNode selectedNode = completeInstances(node, serveur.getNom(), meoInstanceName);
					if(selectedNode!=null) {
						tv.SelectedNode = selectedNode;
					}
					node.ExpandAll();
				}
			}
		}
		private TreeNode completeInstances(TreeNode node, String serverName, String meoInstanceName)
		{
			TreeNode selectedNode = null;
			foreach (MeoInstance instance in instances) {
				if (instance.getServeur() == serverName) {
					TreeNode childNode = node.Nodes.Add(instance.getNom());
					if(instance.getNom()==meoInstanceName) {
						childNode.ForeColor = Color.DarkBlue;
						childNode.BackColor = Color.Yellow;
						childNode.ToolTipText = "Instance cible";
						selectedNode = childNode;
					}
				}
			}
			return selectedNode;
		}

	}
}

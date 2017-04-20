/*
 * Utilisateur: Renaud
 * Date: 20/01/2017
 * Heure: 18:27:30
 * 
 */
using System;
using System.Collections.Generic;
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
		
		public void populateTargets(TreeView tv)
		{
			if (serveurs != null) {
				foreach (MeoServeur serveur in serveurs) {
					TreeNode node = tv.Nodes.Add(serveur.getNom());
					completeInstances(node, serveur.getNom());
					node.ExpandAll();
				}
			}
		}
		private void completeInstances(TreeNode node, String serverName)
		{
			foreach (MeoInstance instance in instances) {
				if (instance.getServeur() == serverName) {
					TreeNode childNode = node.Nodes.Add(instance.getNom());
				}
			}
		}

	}
}

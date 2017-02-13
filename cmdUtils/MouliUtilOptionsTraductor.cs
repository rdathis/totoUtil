/*
 * Utilisateur: Renaud
 * Date: 13/02/2017
 * Heure: 13:50:36
 * 
 */
using System;
using cmdUtils.Objets;

namespace cmdUtils
{
	/// <summary>
	/// Description of MouliUtilOptionsTraductor.
	/// </summary>
	public class MouliUtilOptionsTraductor : MouliUtilOptions
	{
		public MouliUtilOptionsTraductor()
		{
		}
		
		string getPurgeArg(int nbAnnees)
		{
			DateTime date = DateTime.Now;
			return (date.Year - nbAnnees)+"";
		}

		public string traduitScript(string ligne)
		{
			String joint = "N";
			String lot = this.getLots();
			// disable once StringIndexOfIsCultureSpecific
			if(lot.IndexOf("D") >= 0) {
				lot=lot.Replace("D", "");
				joint = "D";
			}
			ligne = ligne.Replace("<%mailto%>", this.getDefaultEmail());
			ligne = ligne.Replace("<%magId%>", this.getMagId());
			ligne = ligne.Replace("<%magIRRIS%>", this.getNumeroMagasinIrris());
			ligne = ligne.Replace("<%ARG%>", lot);
			ligne = ligne.Replace("<%instanceName%>", this.getInstanceName());
			ligne = ligne.Replace("<%instanceCommande%>", this.getInstanceCommande());

			if (this.getIsJoint()) {
				joint = "O";
			}
			String purgeArg="";
			if(MoulinettePurgeOptionTypes.PURGE_DEMANDEE==this.getExtensionStock()) {
				purgeArg+="  -datartmin "+getPurgeArg(getAnneesConservationStockSiPurge());
			}
			if(MoulinettePurgeOptionTypes.PURGE_DEMANDEE==this.getExtensionClient()) {
				purgeArg+="  -datvismin "+getPurgeArg(getAnneesConservationVisiteSiPurge());
			}
			ligne=ligne.Replace("%purgeArg%", purgeArg);
			ligne = ligne.Replace("<%joint%>", joint);
			ligne = ligne.Replace("<%dateCrea%>", DateTime.Now.ToString());
			return ligne;
		}
	}
}

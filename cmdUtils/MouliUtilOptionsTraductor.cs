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
	public class MouliUtilOptionsTraductor 
	{
		public MouliUtilOptionsTraductor()
		{
		}
		
		private static string getPurgeArg(int nbAnnees)
		{
			DateTime date = DateTime.Now;
			return (date.Year - nbAnnees)+"";
		}

		
		public static string traduitScript(MouliUtilOptions options, string ligne)
		{
			
			String joint = "N";
			String lot = options.getLots();
			// disable  once StringIndexOfIsCultureSpecific
			if(lot.IndexOf("D") >= 0) {
				lot=lot.Replace("D", "");
				joint = "D";
			}
			// disable  once StringIndexOfIsCultureSpecific
			if(lot.IndexOf("J") >=0) {
				lot=lot.Replace("J", "");
				joint="O";
			}
			ligne = ligne.Replace("<%mailto%>", options.getDefaultEmail());
			ligne = ligne.Replace("<%magId%>", options.getMagId());
			ligne = ligne.Replace("<%magIRRIS%>", options.getNumeroMagasinIrris());
			ligne = ligne.Replace("<%ARG%>", lot);
			ligne = ligne.Replace("<%instanceName%>", options.getInstanceName());
			ligne = ligne.Replace("<%instanceCommande%>", options.getInstanceCommande());

			if (options.getIsJoint()) {
				joint = "O";
			}
			String purgeArg="";
			if(MoulinettePurgeOptionTypes.PURGE_DEMANDEE==options.getExtensionStock()) {
				purgeArg+="  -datartmin "+getPurgeArg(options.getAnneesConservationStockSiPurge());
			}
			if(MoulinettePurgeOptionTypes.PURGE_DEMANDEE==options.getExtensionClient()) {
				purgeArg+="  -datvismin "+getPurgeArg(options.getAnneesConservationVisiteSiPurge());
			}
			ligne=ligne.Replace("%purgeArg%", purgeArg);
			ligne = ligne.Replace("<%joint%>", joint);
			ligne = ligne.Replace("<%dateCrea%>", DateTime.Now.ToString());
			return ligne;
		}
	}
}

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
			return (date.Year - nbAnnees) + "0101";
		}

		static int toInt(string str)
		{
			int r = 0;
			try {
				r = int.Parse(str);
				// disable once EmptyGeneralCatchClause
			} catch (Exception ex) {
				//osef.
			}
			return r;
		}
		
		public static string traduitScript(MouliUtilOptions options, string ligne)
		{
			
			String joint = "N";
			String lot = options.getLots();
			String userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("\\", "/");
			// disable  once StringIndexOfIsCultureSpecific
			if (lot.IndexOf("D") >= 0) {
				lot = lot.Replace("D", "");
				joint = "D";
			}
			// disable  once StringIndexOfIsCultureSpecific
			if (lot.IndexOf("J") >= 0) {
				lot = lot.Replace("J", "");
				joint = "O";
			}
			ligne = ligne.Replace("<%mailto%>", options.getDefaultEmail());
			ligne = ligne.Replace("<%magId%>", options.getMagId());
			ligne = ligne.Replace("<%magIRRIS%>", options.getNumeroMagasinIrris());
			ligne = ligne.Replace("<%ARG%>", lot);
			ligne = ligne.Replace("<%instanceName%>", options.getInstanceName());
			ligne = ligne.Replace("<%meoPath%>", options.getInstancePath());
			ligne = ligne.Replace("<%tomcatPath%>", options.getTomcatPath());
			ligne = ligne.Replace("<%javaCmd%>", options.getJavaCmd());
			ligne = ligne.Replace("<%userName%>", userName);
			ligne = ligne.Replace("<%instanceCommande%>", options.getInstanceCommande());

			if (options.getIsJoint()) {
				joint = "O";
			}
			String purgeArg = "";
			if (MoulinettePurgeOptionTypes.PURGE_DEMANDEE == options.getExtensionStock()) {
				purgeArg += "  -datartmin " + getPurgeArg(options.getAnneesConservationStockSiPurge());
			}
			if (MoulinettePurgeOptionTypes.PURGE_DEMANDEE == options.getExtensionClient()) {
				purgeArg += "  -datvismin " + getPurgeArg(options.getAnneesConservationVisiteSiPurge());
			}
			if (purgeArg == "") {
				int tmp = toInt(options.getLimiteYearVisites());
				if (tmp > 0 && tmp < 99) {
					purgeArg += "  -datvismin " + getPurgeArg(tmp);
				}
				tmp = toInt(options.getLimiteYearStock());
				if (tmp > 0 && tmp < 99) {
					purgeArg += "  -datartmin " + getPurgeArg(tmp);
				}
				
			}
			ligne = ligne.Replace("<%purgeArg%>", purgeArg);
			ligne = ligne.Replace("<%joint%>", joint);
			ligne = ligne.Replace("<%dateCrea%>", DateTime.Now.ToString());
			return ligne;
		}
	}
}

/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 10/06/2016
 * Heure: 17:44:49
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using cmdUtils.Objets;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of YFiles.
	/// </summary>
	/// 
	public static class YFILES
	{
		public enum YFiles
		{
			YCLIENTS,
			YFOURNI,
			YMARQUE,
			YFORMULE,
			YSTOCAT,
			YSTOCK,
			//		YHISTO, // not ready yet
			YVITALE,
			YTOPTIC,
			YTOPSUIT,
			YTLENTI,
			YTDIVERS,
			YOBSERV,
			YTOBSERV,
			YTPL,
			YTPE,
			YTFACTUR,
			YCODLIB,
			YREMISE,
			YOPHTAL,
			YDOCUMENT
			
		}
		public static Boolean isStock(YFiles yfile)
		{
			return (YFiles.YFORMULE == yfile || YFiles.YFOURNI == yfile || YFiles.YMARQUE == yfile || YFiles.YSTOCAT == yfile || YFiles.YSTOCK == yfile);
		}
		public static Boolean isClient(YFiles yfile)
		{
			return !isStock(yfile); //shortcut.
		}
		//TODO:add lengths & positions
	}
}

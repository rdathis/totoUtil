/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 01/09/2016
 * Heure: 13:33:49
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MouliUtilOptions.
	/// </summary>
	public class MouliUtilOptions
	{
		private String magId;
		private String instanceName;
		private String instanceCommande;
		private String lots;
		private Boolean isDoc01;
		private Boolean isJoint;
		private DateTime dateJob;
		public MouliUtilOptions()
		{
			//
		}
		public String getMagId()
		{
			return magId;
		}
		public String getInstanceName()
		{
			return instanceName;
		}
		public String getLots()
		{
			return lots;
		}
		public Boolean getIsDoc01()
		{
			return isDoc01;
		}
		public Boolean getIsJoint()
		{
			return isJoint;
		}
		public void setMagId(String value)
		{
			magId = value;
		}
		public void setInstanceName(String value)
		{
			instanceName = value;
		}
		public void  setLots(String value)
		{
			lots = value;
		}
		public void  setIsDoc01(Boolean value)
		{
			isDoc01 = value;
		}
		public void setIsJoint(Boolean value)
		{
			isJoint = value;
		}
		public DateTime getDateJob() {
				return dateJob;
		}
		public void setDateJob (DateTime value) {
				dateJob=value;
		}
		public String getInstanceCommande()
		{
			return instanceCommande;
		}
		public void setInstanceCommande(String value)
		{
			instanceCommande=value;;
		}
	}
}

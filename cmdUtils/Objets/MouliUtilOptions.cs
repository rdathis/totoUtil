/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 01/09/2016
 * Heure: 13:33:49
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;

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
		private List<String> doc01;
		private List<String> ord01;
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
		public List<String>  getDoc01()
		{
			return doc01;
		}
		public List<String> getOrd01()
		{
			return ord01;
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
		public void  setDoc01(List<String>  value)
		{
			doc01 = value;
		}
		public void  setOrd01(List<String> value)
		{
			ord01 = value;
		}
		public void setIsJoint(Boolean value)
		{
			isJoint = value;
		}
		public DateTime getDateJob()
		{
			return dateJob;
		}
		public void setDateJob(DateTime value)
		{
			dateJob = value;
		}
		public String getInstanceCommande()
		{
			return instanceCommande;
		}
		public void setInstanceCommande(String value)
		{
			instanceCommande = value;
		}
	}
}

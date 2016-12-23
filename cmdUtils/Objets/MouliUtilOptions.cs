﻿/*
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
		private String defaultEmail;
		private String numeroMagasinIrris;
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
		public void setDefaultEmail(String value) {
			defaultEmail=value;
		}
		public String getDefaultEmail() {
			return defaultEmail;
		}
		public void setNumeroMagasinIrris(String v) {
			numeroMagasinIrris=v;
		}
		public String getNumeroMagasinIrris() {
			return numeroMagasinIrris;
		}

		public Boolean isCommentaire(String ligne) {
			return ligne.StartsWith("#DoNotTranslate:");
		}
		public string traduitScript(string ligne)
		{
			ligne = ligne.Replace("<%mailto%>", this.getDefaultEmail());
			ligne = ligne.Replace("<%magId%>", this.getMagId());
			ligne = ligne.Replace("<%magIRRIS%>", this.getNumeroMagasinIrris());
			ligne = ligne.Replace("<%ARG%>", this.getLots());
			ligne = ligne.Replace("<%instanceName%>", this.getInstanceName());
			ligne = ligne.Replace("<%instanceCommande%>", this.getInstanceCommande());
			String joint = "N";
			if (this.getIsJoint()) {
				joint = "O";
			}
			ligne = ligne.Replace("<%joint%>", joint);
			ligne = ligne.Replace("<%dateCrea%>", new DateTime().Date.ToString());
			return ligne;
		}
	}
}

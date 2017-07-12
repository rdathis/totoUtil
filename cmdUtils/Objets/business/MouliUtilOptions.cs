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

		private const int anneesConservationStockSiPurge = 2;
		private const int anneesConservationVisiteSiPurge = 10;
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
		private String limiteVisite;
		private String limiteStock;
		private String archiveName;
		//
		private MoulinettePurgeOptionTypes extensionClient = MoulinettePurgeOptionTypes.INCONNU;
		private MoulinettePurgeOptionTypes extensionStock = MoulinettePurgeOptionTypes.INCONNU;
		//
		private String jobFileName;
		private String scriptFileName;
		private String jobContent;
		private String scriptContent;
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
		public void setDefaultEmail(String value)
		{
			defaultEmail = value;
		}
		public String getDefaultEmail()
		{
			return defaultEmail;
		}
		public void setNumeroMagasinIrris(String v)
		{
			numeroMagasinIrris = v;
		}
		public String getNumeroMagasinIrris()
		{
			return numeroMagasinIrris;
		}

		public Boolean isCommentaire(String ligne)
		{
			return ligne.StartsWith("#DoNotTranslate:");
		}
		public MoulinettePurgeOptionTypes getExtensionClient()
		{
			return extensionClient;
		}
		public void setExtensionClient(MoulinettePurgeOptionTypes value)
		{
			this.extensionClient = value;
		}
		public MoulinettePurgeOptionTypes getExtensionStock()
		{
			return extensionStock;
		}
		public void setExtensionStock(MoulinettePurgeOptionTypes value)
		{
			this.extensionStock = value;
		}

		public int getAnneesConservationStockSiPurge()
		{
			return anneesConservationStockSiPurge;
		}

		public void setLimiteStock(string str)
		{
			limiteStock = str;
		}
		public void setLimiteVisite(string str)
		{
			limiteVisite = str;
		}
		public string getLimiteStock()
		{
			return limiteStock;
		}
		public string getLimiteVisite()
		{
			return limiteVisite;
		}
		public int getAnneesConservationVisiteSiPurge()
		{
			return (anneesConservationVisiteSiPurge);
		}
		public String getarchiveName() {
			return archiveName;
		}
		public void setArchiveName(String value) {
			archiveName=value;
		}
		
		public void setJobFileName(String value) {
			jobFileName=value;
		}
		public String getJobFileName() {
			return jobFileName;
		}
		public void setScriptFileName(String value) {
			scriptFileName=value;
		}
		public String getScriptFileName() {
			return scriptFileName;
		}
		public void setJobContent(String value) {
			jobContent=value;
		}
		public String getJobContent() {
			return jobContent;
		}
		public void setScriptContent(String value) {
			scriptContent=value;
		}
		public String getScriptContent() {
			return scriptContent;
		}
	}
}

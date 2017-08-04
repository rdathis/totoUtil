/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 15/10/2015
 * Heure: 13:07:31
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using MoulUtil.Forms.utils;
namespace cmdUtils.Objets
{
	/// <summary>
	/// class utilitaire d'acces aux fichiers zip
	/// </summary>
	public class ZipUtil
	{

		public static int compressionMaximum=9;
		public static int compressionStandard=5;
		public static int compressionMinimum=0;
		
		private readonly log4net.ILog  LOGGER=null;
		public ZipUtil(log4net.ILog  LOGGER)
		{
			this.LOGGER=LOGGER;
		}
		
		private Boolean testDir(string directory, Boolean allowEmptyString=false) {
			if (directory!=null) {
				if (directory.Trim().Length>0) {
					if (!Directory.Exists(directory)) {
						LOGGER.Error("chemin archive inexistant : '"+directory+"'");
						throw new Exception("chemin archive inexistant : '"+directory+"'");
					}
					return true;
				} else  {
					return allowEmptyString;
				}
			} else {
				return allowEmptyString;
			}
		}
		public void createArchive(ZipUtilOptions options)/**/ {
			if (options==null) {
				LOGGER.Error("options non renseignees");
				throw new Exception("options non renseignees");
			}
			if (!testDir(options.getArchiveDir())) {
				if ((options.getArchiveDir()==null)|| (options.getArchiveDir().Length<1)) {
					LOGGER.Error("archive non renseignee ");
					throw new Exception("archive non renseignee ");
				} else {
					LOGGER.Error("chemin inexistant : '"+options.getArchiveDir()+"'");
					throw new Exception("chemin inexistant : '"+options.getArchiveDir()+"'");
				}
			}
			
			List<FileInfo> fileInfos = new List<FileInfo>();
			complete(fileInfos, options.getSourceBaseDir(), options.getSourceSelection());
			
			List<String> fichiers = new List<string>();
			foreach(FileInfo fileInfo in fileInfos) {
				fichiers.Add(fileInfo.Name);
			}
			
			//TODO:add taux in ZipUtilOptions
			int taux = (int) ZipUtilOptions.TauxCompression.maxi;
			createSimpleArchive(taux, options.getArchiveDir()+options.getArchiveName(), fichiers, options.getBackgroundWorker());
			return;
			
		}
		public void complete(List<FileInfo> fichiers, string baseDir, string[] selection)
		{
			String pattrn=null;
			try {
				DirectoryInfo di = new DirectoryInfo(baseDir);
				foreach(string pattern in selection) {
					if(pattern!=null) {
						Console.WriteLine("Pattern  "+pattern);
						pattrn=pattern;
						foreach (FileInfo fi in di.GetFiles(pattern)) {
							fichiers.Add(fi);
						}
					}
				}
			} catch (Exception ex) {
				System.Windows.Forms.MessageBox.Show("Erreur acces : "+baseDir+" : "+"\npattern : "+pattrn+"\n"+ex.Message);
			}
			
		}
		
		public void createSimpleArchive(int compressionLevel,  string archiveName, List<String>fichiers, MouliProgressWorker backgroundWorker)
		{
			if ( archiveName.Length < 2 ) {
				Console.WriteLine("Usage: CreateZipFile Path ZipFile");
				return;
			}
			if ((compressionLevel<compressionMinimum) || (compressionLevel > compressionMaximum) ) {
				compressionLevel=compressionStandard;
			}

			LOGGER.Info(" Taux de compression : "+compressionLevel);
			try
			{
				using (ZipOutputStream zip = new ZipOutputStream(File.Create(archiveName))) {
					
					// 0 - store only to 9 - means best compression
					zip.SetLevel(compressionLevel);
					
					byte[] buffer = new byte[4096];
					int nb=0;
					if(backgroundWorker!=null) {
						backgroundWorker.setNbOperation(fichiers.Count);
						
					}
					foreach (String fichier in fichiers) {
						FileInfo file = new FileInfo(fichier);
						
						ZipEntry entry = new ZipEntry(fichier);
						LOGGER.Info(" ZipUtil - ajout "+fichier + " ("+entry.Size+")");

						entry.DateTime = DateTime.Now;
						zip.PutNextEntry(entry);
						
						using ( FileStream fileStream = file.OpenRead() ) {
							int sourceBytes;
							do {
								sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
								zip.Write(buffer, 0, sourceBytes);
							} while ( sourceBytes > 0 );
						}
						if(backgroundWorker!=null) {
							backgroundWorker.ReportProgress(nb++);
						}
					}
					zip.Finish();
					zip.Close();
				}
			}
			catch(Exception ex)
			{
				LOGGER.Error(ex.Message + "\n" + ex.Source + "\n"+ ex.StackTrace);
			}
		}
	}
}
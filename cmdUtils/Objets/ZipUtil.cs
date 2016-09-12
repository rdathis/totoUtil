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
		
		//TODO:faire une class ZipUtilOption, plus facile a manipuler
		public ZipUtil()
		{
		}
		private Boolean testDir(string directory, Boolean allowEmptyString=false) {
			if (directory!=null) {
				if (directory.Trim().Length>0) {
					if (!Directory.Exists(directory)) {
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
		public void createArchive(ZipUtilOptions options) {
			if (options==null) {
				throw new Exception("options non renseignees");
			}
			if (!testDir(options.getArchiveDir())) {
				if ((options.getArchiveDir()==null)|| (options.getArchiveDir().Length<1)) {
					throw new Exception("archive non renseignee ");
				} else {
					throw new Exception("chemin inexistant : '"+options.getArchiveDir()+"'");
				}
				
			}
			
			List<FileInfo> fichiers = new List<FileInfo>();
			complete(fichiers, options.getSourceBaseDir(), options.getSourceSelection());
			
			createSimpleArchive( options.getArchiveDir()+options.getArchiveName(), fichiers);
			return;
			
		}
		public void createArchive(string archiveName, string sourceBaseDir, string[] sourceSelection, string datamag, string archiveDir)
		{
			if (!testDir(archiveDir, true)) {
				throw new Exception("chemin archive inexistant : '"+archiveDir+"'");
			}
			if ((archiveName==null) || (archiveName.Trim().Length<1)) {
				throw new Exception("nom  d'archive manquant ");
			}
			
			List<FileInfo> fichiers = new List<FileInfo>();
			
			complete(fichiers, sourceBaseDir, sourceSelection);
			createSimpleArchive(archiveDir+archiveName, fichiers);
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
		
		public void createSimpleArchive(int compressionLevel,  string archiveName, List<String>fichiers)
		{
			if ( archiveName.Length < 2 ) {
				Console.WriteLine("Usage: CreateZipFile Path ZipFile");
				return;
			}
			if ((compressionLevel<compressionMinimum) || (compressionLevel > compressionMaximum) ) {
				compressionLevel=compressionStandard;
			}
			Console.WriteLine(" Taux de compression : "+compressionLevel);
			try
			{
				// Depending on the directory this could be very large and would require more attention
				// in a commercial package.
				//string[] filenames = Directory.GetFiles(args[0]);
				
				// 'using' statements guarantee the stream is closed properly which is a big source
				// of problems otherwise.  Its exception safe as well which is great.
				using (ZipOutputStream zip = new ZipOutputStream(File.Create(archiveName))) {
					
					// 0 - store only to 9 - means best compression
					zip.SetLevel(compressionLevel);
					
					byte[] buffer = new byte[4096];
					
					foreach (String fichier in fichiers) {
						FileInfo file = new FileInfo(fichier);
						
						// Using GetFileName makes the result compatible with XP
						// as the resulting path is not absolute.
						ZipEntry entry = new ZipEntry(fichier);
						Console.WriteLine (" ZipUtil - ajout "+fichier	);
						// Setup the entry data as required.
						
						// Crc and size are handled by the library for seakable streams
						// so no need to do them here.

						// Could also use the last write time or similar for the file.
						entry.DateTime = DateTime.Now;
						zip.PutNextEntry(entry);
						
						using ( FileStream fileStream = file.OpenRead() ) {
							
							// Using a fixed size buffer here makes no noticeable difference for output
							// but keeps a lid on memory usage.
							int sourceBytes;
							do {
								sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
								zip.Write(buffer, 0, sourceBytes);
							} while ( sourceBytes > 0 );
						}
					}
					
					zip.Finish();
					zip.Close();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception during processing {0}", ex);
			}
			
		}
		
		public void createSimpleArchive(string archiveName, List<FileInfo>fichiers)
		{
			// Perform some simple parameter checking.  More could be done
			// like checking the target file name is ok, disk space, and lots
			// of other things, but for a demo this covers some obvious traps.
			if ( archiveName.Length < 2 ) {
				Console.WriteLine("Usage: CreateZipFile Path ZipFile");
				return;
			}

//			if ( !Directory.Exists(args[0]) ) {
//				Console.WriteLine("Cannot find directory '{0}'", args[0]);
//				return;
//			}

			try
			{
				// Depending on the directory this could be very large and would require more attention
				// in a commercial package.
				//string[] filenames = Directory.GetFiles(args[0]);
				
				// 'using' statements guarantee the stream is closed properly which is a big source
				// of problems otherwise.  Its exception safe as well which is great.
				using (ZipOutputStream zip = new ZipOutputStream(File.Create(archiveName))) {
					
					zip.SetLevel(9); // 0 - store only to 9 - means best compression
					
					byte[] buffer = new byte[4096];
					
					foreach (FileInfo file in fichiers) {
						
						// Using GetFileName makes the result compatible with XP
						// as the resulting path is not absolute.
						ZipEntry entry = new ZipEntry(file.Name);
						Console.WriteLine (" ZipUtil - ajout "+file.Name);
						// Setup the entry data as required.
						
						// Crc and size are handled by the library for seakable streams
						// so no need to do them here.

						// Could also use the last write time or similar for the file.
						entry.DateTime = DateTime.Now;
						zip.PutNextEntry(entry);
						
						using ( FileStream fileStream = file.OpenRead() ) {
							
							// Using a fixed size buffer here makes no noticeable difference for output
							// but keeps a lid on memory usage.
							int sourceBytes;
							do {
								sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
								zip.Write(buffer, 0, sourceBytes);
							} while ( sourceBytes > 0 );
						}
					}
					
					// Finish/Close arent needed strictly as the using statement does this automatically
					
					// Finish is important to ensure trailing information for a Zip file is appended.  Without this
					// the created file would be invalid.
					zip.Finish();
					
					// Close is important to wrap things up and unlock the file.
					zip.Close();
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Exception during processing {0}", ex);
				
				// No need to rethrow the exception as for our purposes its handled.
			}
			
		}
	}
}
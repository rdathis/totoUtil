﻿/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/02/2015
 * Heure: 18:25:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using totoUtil.Objets;
using totoUtil.Utils;
namespace totoUtil
{
	/*
	/// <summary>
	/// Description of Greper.
	/// </summary>
	public class Greper
	{
		public Greper()
		{
		}
		
//type file.txt | grep "(?<=h)e(?=llo)" -r a

//will replace all “hello”’s with “hallo”’s.
		//http://blogs.msdn.com/b/davethompson/archive/2011/06/15/simple-grep-in-net.aspx
		//sinon  : http://www.codeproject.com/Articles/1485/A-C-Grep-Application
		//et http://www.codeproject.com/Articles/53301/GrepWrap-A-Windows-Wrapper-for-GNU-Grep
		//fait exactement le travail d'un grep. mais sur un programme
static void Main(string[] args)
           {
               if (args.Count() < 1)
               {
                   Console.WriteLine("You should consider giving me a regex to work on, or a pattern and a replacement to replace stuff with the -r switch");
                   return;
               }
    
               string pattern = args[0];
    
               string replace = null;
    
               if (args.Count() > 1 && args[1].StartsWith("-r"))
               {
                   if (args.Count() == 2)
                   {
                       replace = String.Empty;
                   }
                   else
                   {
                      replace = args[2];
                  }
              }
   
              string line = null;
   
              try
              {
                  while ((line = Console.ReadLine()) != null)
                  {
                      if (replace == null)
                      {
                          // do a find
                          if (Regex.IsMatch(line, pattern))
                          {
                              Console.WriteLine(
                                  line
                                  );
                          }
                      }
                      else
                      {
                          // do a replace
                          Console.WriteLine(
                              Regex.Replace(line, pattern, replace)
                              );
                      }
                  }
              }
              catch (ArgumentException ex)
              {
                  Console.WriteLine("You should meditate on the regex, because {0}", ex.Message);
              }
              catch (Exception ex)
              {
                  Console.WriteLine("You should meditate on this error: {0}", ex.Message);
              }
          }
      }
	}
	 */
	
	public class Greper {
		/** */
		
		/** grep a single file (existing) */
		public List <String> grepFile(String files, List <Regex> regX) {
			List <String> fichiersList = MainUtils.getFiles(files, "");
			
			List <String> strResult=new List<String> ();
			
			foreach	(String fichier in fichiersList) {
				//recherche
				GrepResult results = grepFileAsResults(fichier, regX);
				
				
				foreach(GrepLignes founded in results.getResults()) {
					strResult.Add(simpleFormateResult(founded, results.getFilename(), true));
				}

				
			}
			return strResult;
		}
		
		
		private GrepResult grepFileAsResults(String file, List <Regex> regX) {
			if ((regX ==null) || (regX.Count <1)) return null;
			if (!File.Exists(file)) return null;
			
			GrepResult result = new GrepResult(file, null);
			List <GrepLignes> results = new List<GrepLignes>();
			result.setResults(results);
			
			
			//IMPORTANT:ouverture en lecture d'un fichier déja ouvert
			Stream stream= File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			
			
			StreamReader sr = new  StreamReader(stream) ;
			
			
			String ligne=null;
			long cptL = 0;
			while (  (ligne=sr.ReadLine()) !=null) {
				cptL++;
				if (ligne.Length > 0) {
					//System.Diagnostics.Debug.Print("ligne  ("+cptL+")"+ligne);
					for(int i =0;i<regX.Count;i++) {
						if (regX[i].IsMatch(ligne)) {
							GrepLignes ok = new GrepLignes();
							ok.setIndexMatcher(i);
							ok.setLigneContent(ligne);
							ok.setLigneNumber(cptL);
							ok.setPositionMatched(-1); //TODO:calculate this
							results.Add(ok);
							
							break;
						}
					}
				}
			}
			//String flux = sr.ReadToEnd();
			sr.Close();
			return result;
		}

		string simpleFormateResult(GrepLignes founded, String filename="", bool line=false)
		{
			String str =founded.getLigneContent();
			if (line) {
				str=founded.getLigneNumber()+":"+str;
			}
			if (filename.Length>0) {
				str=filename+" "+str;
			}
			return str;
		}
	}
}
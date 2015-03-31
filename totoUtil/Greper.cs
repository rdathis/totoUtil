/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 20/02/2015
 * Heure: 18:25:59
 * 
 * Pour changer ce modèle utiliser Outils | Options | Codage | Editer les en-têtes standards.
 */
using System;

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
}
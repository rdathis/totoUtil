/*
 * Utilisateur: Renaud
 * Date: 09/02/2017
 * Heure: 13:39:25
 * 
 */
using System;
using System.Collections.Generic;
namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MySQLDico.
	/// </summary>
	// disable once ConvertToStaticType
	public  class MySQLDico : Dictionary<String, String>
	{
		
		
		
		private static Dictionary<string, string> _dico = new Dictionary<string, string>
		{
		//	{"entry", "entries"},
{"ALTER", "ALTER"},
{"AND", "AND"},
{"CASE", "CASE"},
{"DATABASE", "DATABASE"},
{"DROP", "DROP"},
{"ELSE", "ELSE"},
{"END", "END"},
{"EVENT", "EVENT"},
{"FUNCTION", "FUNCTION"},
//{"GROUP", "GROUP"},
{"GROUP BY", "GROUP BY"},
{"HAVING", "HAVING"},
{"IN", "IN"},
{"INDEX", "INDEX"},
{"INNER", "INNER"},
{"INSTANCE", "INSTANCE"},
{"LEFT", "LEFT"},
{"LIMIT", "LIMIT"},
{"LOGFILE", "LOGFILE"},
{"OR", "OR"},
{"ORDER BY", "ORDER BY"},
{"OUTER", "OUTER"},
{"PROCEDURE", "PROCEDURE"},
{"RENAME", "RENAME"},
{"RIGHT", "RIGHT"},
{"TRUNCATE", "TRUNCATE"},
{"SELECT", "SELECT"},
{"SERVER", "SERVER"},
{"TABLE", "TABLE"},
{"TABLESPACE", "TABLESPACE"},
{"TRIGGER", "TRIGGER"},
{"VIEW", "VIEW"},
{"WHERE", "WHERE"},
//end
{"-- ", "-- " }

		};

		/// <summary>
		/// Access the Dictionary from external sources
		/// </summary>
		public static string GetWord(string word)
		{
			// Try to get the result in the static Dictionary
			string result;
			if (_dico.TryGetValue(word, out result))
			{
				//return result.toUpper();
				return word.ToUpper(); //word to upper : more secure for errors
			}
			else
			{
				return word;
			}
			
		}
	}
}
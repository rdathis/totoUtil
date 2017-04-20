/*
 * Utilisateur: Renaud
 * Date: 08/02/2017
 * Heure: 16:48:57
 * 
 */
using System;
using System.Text.RegularExpressions;
namespace cmdUtils.Objets
{
	/// <summary>
	/// Description of MeoSavUtil.
	/// </summary>
	public class MeoSavUtil
	{
		public MeoSavUtil()
		{
		}
		
		public String convertiSql(String sql) {
			String sqlBegin="";
			String sqlTmp=sql;
			//http://lgmorand.developpez.com/dotnet/regex/
			sqlTmp=sqlTmp.Replace("Hibernate:", "");
			sqlTmp=sqlTmp.Replace(" client ", " `client` "); //todo, change for regexp, funny
			sqlTmp=sqlTmp.Replace(" client.", " `client`.");
			sqlTmp=sqlTmp.Replace(" user ", " `user` ");
			sqlTmp=sqlTmp.Replace(" user.", " `user`.");
			//
			//$texte = preg_replace('#<!--.*?-->#s', '', $texte);
			//https://www.developpez.net/forums/d391114/autres-langages/perl/langage/expression-reguliere-commentaire-comptenu-commentaire/
			
			Regex myRegex = new Regex("(/\\*).+?(\\*/)");
			sqlTmp= myRegex.Replace(sqlTmp, "/* ... */\n"); 
		
			//next step : go for '?' et '*** not specified ***'
			// format code
			
//			sqlTmp=sqlTmp.Replace(" inner join ", "\n inner join ");
//			sqlTmp=sqlTmp.Replace(" left join ", "\n left join ");
//			sqlTmp=sqlTmp.Replace(" left outer join ", "\n left outer join ");
//			sqlTmp=sqlTmp.Replace(" right join ", "\n right join ");
//			sqlTmp=sqlTmp.Replace(" right outer join ", "\n right outer join ");
//			sqlTmp=sqlTmp.Replace(" WHERE ", "\nWHERE ");
//			sqlTmp=sqlTmp.Replace(" FROM ", "\nFROM ");
//			sqlTmp=sqlTmp.Replace(" LIMIT ", "\nLIMIT ");
//			sqlTmp=sqlTmp.Replace(" ORDER ", "\nORDER ");
//			sqlTmp=sqlTmp.Replace(" HAVING ", "\nHAVING ");

			sqlTmp=sqlTmp.Trim();
			if(!sqlTmp.EndsWith(";")) {
				sqlTmp+=" ; -- end \n";
			}
			return (sqlBegin + sqlTmp);
	}
}
}

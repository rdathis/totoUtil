/*
 * Utilisateur: Renaud
 * Date: 20/10/2017
 * Heure: 11:57:44
 * 
 */
using System;

namespace cmdUtils.Objets.utils
{
	/// <summary>
	/// lecture des valeurs
	/// </summary>
	public class BcdUtil
	{
		readonly log4net.ILog LOGGER;
		String sepD = null;
		public BcdUtil(log4net.ILog  LOGGER)
		{
			this.LOGGER = LOGGER;			
			this.sepD = getSepD();
		}
		private String getSepD()
		{
			//bricolage.
			String s = Math.PI.ToString().Substring(1, 1);
			return s;
		}
		public  Double getDoubleBcd(byte[] buffer, int start, int lg)
		{
			byte[] bcd = new byte[lg];
			for (int i = 0; i < lg; i++) {
				bcd[i] = buffer[start + i];
			}
			
			long valeur;
			String str = "";
			/*
valeur [0] : 192
valeur [1] : 0
valeur [2] : 0
valeur [3] : 0
valeur [4] : 0
valeur [5] : 0
valeur [6] : 10
valeur [7] : 0
-> 0

c000000000004a00 -> 4.00
c000000000006a00 -> 6.00
[79, -1, -1, -1, -1, -1, -27, -1] 'b000000000001a00' ->-1
[-64, 0, 0, 0, 0, 0, 26, 0] -> 'c000000000001a00' -> 1
s			 */
			Boolean negatif = false;
			if ((bcd.Length > 0) && (Convert.ToInt16(bcd[0]) == 79)) {
				negatif = true;
//			} else if((bcd.Length > 0) && (Convert.ToInt16(bcd[0]) != 192)) {
//				negatif=negatif;
			}

			for (int i = 0; i < bcd.Length; i++) {
				if (negatif) {
					valeur = 255 - ((long)bcd[i] & 0xff); // 0xff pour travailler en non signé
				} else {
					valeur = ((long)bcd[i] & 0xff); // 0xff pour travailler en non signé
				}
				String strTemp = Convert.ToString(valeur, 16);
				for (int j = strTemp.Length; j < 2; j++) {
					str += "0";
				}
				str += strTemp;
			}
			// traitement des quartets spéciaux
			str = str.Replace("a", sepD); // séparateur décimal
			str = str.Replace('b', '-'); // signe négatif
			str = str.Replace('c', ' '); // signe positif
			str = str.Replace('f', ' '); // non significatif
			str = str.Replace('.', ',');//important en dotnet fr
			Double valeurDouble = 0d;
			try {
				str = str.Trim();
				if (str.Length > 0) {
					valeurDouble = Convert.ToDouble(str);
				}
			} catch (Exception e) {
				LOGGER.Warn("Erreur bcd2double : " + str + " " + e.Message);
			}
			return valeurDouble;
		}

	}
}

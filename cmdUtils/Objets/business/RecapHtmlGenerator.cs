/*
 * Utilisateur: Renaud
 * Date: 21/11/2017
 * Heure: 16:44:23
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using NVelocity;
using NVelocity.App;

namespace cmdUtils.Objets.business
{
	/// <summary>
	/// Description of RecapHtmlGenerator.
	/// </summary>
	public class RecapHtmlGenerator
	{
		private List<MouliAnneeRecap> liste;
		private MouliUtilOptions options;
		public RecapHtmlGenerator(List<MouliAnneeRecap> liste, MouliUtilOptions options)
		{
			this.liste = liste;
			this.options = options;
		}
		
		public String generate()
		{
			int limiteStock = int.Parse(options.getLimiteStock());
			int limiteVisite = int.Parse(options.getLimiteVisite());
			int limiteYearVisite = int.Parse(options.getLimiteYearVisites());
			int tmpTotStock=0;
			int tmpTotVisit=0;
			int tmpTotStockNul=0;
			int visiteExcedent =0;
			int stockExcedent =0;
			String actionPurgeStock="";
			//Passe 1 : limites
			foreach (MouliAnneeRecap recap in liste) {
				tmpTotStock+=recap.getNbStNul() + recap.getNbStNeg() + recap.getNbStPos();
				tmpTotVisit+=recap.getNbVisO() + recap.getNbVisL();
				tmpTotStockNul+=recap.getNbStNul();
			}
			if(tmpTotStock>= limiteStock) {
				stockExcedent = tmpTotStock - limiteStock;
				if(stockExcedent <= tmpTotStockNul) {
					actionPurgeStock = "Action : Purge des négatifs stock";
				}
			}
			
			if(tmpTotVisit>= limiteVisite) {
				visiteExcedent = tmpTotVisit - limiteVisite;
				if(liste.Count > limiteYearVisite) {
				//Faux:il faut reprendre a la date du jour
					List<MouliAnneeRecap> subListe= liste.GetRange(liste.Count -limiteYearVisite, limiteYearVisite);
					//
				}
			}
			//
			var tablo = new Object [liste.Count];
			int i = 0;
			int cumVis = 0;
			int cumSto = 0;
			int tnVO = 0;
			int tnVL = 0;
			int tsNe = 0;
			int tsNu = 0;
			int tsPo = 0;
			foreach (MouliAnneeRecap recap in liste) {
				int totVis = recap.getNbVisO() + recap.getNbVisL();
				tnVO += recap.getNbVisO();
				tnVL += recap.getNbVisL();
				//
				int totSto = recap.getNbStNul() + recap.getNbStNeg() + recap.getNbStPos();
				cumVis += totVis;
				cumSto = totSto;
				tsNe += recap.getNbStNeg();
				tsNu += recap.getNbStNul();
				tsPo += recap.getNbStPos();
				//
				tablo[i] = new { ID = i, year = recap.getYear(), Bold = false, // 
					nVO = recap.getNbVisO(), nVL = recap.getNbVisL(), nVT = totVis,
					sNu = recap.getNbStNul(), sNe = recap.getNbStNeg(), sPo = recap.getNbStPos(), sTo = totSto,
					tnVT = cumVis, tsTo = cumSto
				};
				i++;
			}
			var model = new {
				title = "Titre du bidule",
				magId = options.getMagId(),
				magIrris = options.getNumeroMagasinIrris(),
				//
				dateGeneration = (DateTime.Now.ToString()),
				Items = tablo,
				//totaux
				tnVO, tnVL, tsNe, tsNu, tsPo, tnVT = (tnVO + tnVL), tsTo = (tsNe + tsNu + tsPo),
				listeCount = liste.Count,
				rowSpan = liste.Count +2,
				stockExcedent, visiteExcedent, limiteStock, limiteVisite, actionPurgeStock
			};

			Velocity.Init();
			String template = getRecapTemplate();
			StringBuilder sb = new StringBuilder();
			VelocityContext velocityContext = new VelocityContext();
			velocityContext.Put("model", model);
			Velocity.Evaluate(
				velocityContext,
				new StringWriter(sb),
				"html recap template",
				new StringReader(template));
			return sb.ToString();

		}
		
		private String getRecapTemplate()
		{
			string template = string.Join(Environment.NewLine, new [] {
			                              	"<html>",
			                              	"<head>",
			                              	"<title>", "$model.title", "</title>",
			                              	"<style>",
			                              	"tr:nth-child(even) {background: #CCC} ",
			                              	"tr:nth-child(odd) {background: #FFF} ",

			                              	".separator { background: pink } ",
			                              	".lyear { background: lightgrey } ",
			                              	".hyear, .hvis, .hstk, .hcumul, .htotal{ width: 80px ; background: lightgrey} ",
			                              	".lvis, .lstk, .ltotal, .lcumul { text-align:right } ",
			                              	".lvis { background: lightblue } ",
			                              	".lstk { background: lightgreen } ",
			                              	".ltotal, .lcumul { font-weight: bold } ",
			                              	".ttyear, .ttvis, .ttstk, .tttotal { font-weight: bold; text-align:right } ",
			                              	".tttotal { font-weight: bold; text-align:center ; background: lightgrey} ",
			                              	".ttvis {font: blue; text-align:right; background: lightgrey} ",
			                              	".ttstk {font: green; text-align:right; background: lightgrey} ",
			                              	".ttyear {background: lightgrey} ",
			                              	"</style>",
			                              	"</head>",
			                              	//
			                              	"<body>",
			                              	"<h1>$model.title</h1>",
			                              	
			                              	"<ul><li>Magasin Num:", "$model.magId",	"</li></ul>",
			                              	
			                              	"<table id='recap'>",
			                              	"<tr>",
			                              	" <th class='hyear'>Annee</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	" <th class='hvis'>V. OPT</th>",
			                              	" <th class='hvis'>V. LEN</th>",
			                              	" <th class='htotal'>TOTAL</th>",
			                              	" <th class='hcumul'>Cumul V</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	" <th class='hstk'>Stock NEG</th>",
			                              	" <th class='hstk'>Stock NUL</th>",
			                              	" <th class='hstk'>Stock Pos</th>",
			                              	" <th  class='htotal'>TOTAL</th>",
			                              	" <th class='hcumul'>Cumul S</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	"</tr>",
			                              	/**/
			                              	"#foreach($item in $model.Items)",
			                              	" <tr>",
			                              	" <td class='lyear'>$item.year</td>",
			                              	" <td class='lvis'>$item.nVO</td>", " <td class='lvis'>$item.nVL</td>", " <td class='ltotal'>$item.nVT</td>",
			                              	" <td class='lcumul'>$item.tnVT</td>",
			                              	" <td class='lstk'>$item.sNe</td>", " <td class='lstk'>$item.sNu</td>", " <td class='lstk'>$item.sPo</td>", " <td  class='ltotal'>$item.sTo</td>",
			                              	" <td  class='lcumul'>$item.tsTo</td>",
			                              	" </tr>\n",
			                              	"#end",
			                              	/**/
			                              	" <tr>",
			                              	" <td class='ttyear'>$model.listeCount annees</td>",
			                              	" <td class='ttvis'>$model.tnVO </td>", " <td class='ttvis'>$model.tnVL </td>", " <td class='tttotal' colspan='2'>$model.tnVT </td>",
			                              	" <td class='ttstk'>$model.tsNe</td>", " <td class='ttstk'>$model.tsNu</td>", " <td class='ttstk'>$model.tsPo</td>",
			                              	" <td class='tttotal' colspan='2'>$model.tsTo</td>",
			                              	"</tr>\n",
			                              	// Repetition du titre en bas pour lisibilite
			                              	"<tr>",
			                              	" <th class='hyear'>Annee</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	" <th class='hvis'>V. OPT</th>",
			                              	" <th class='hvis'>V. LEN</th>",
			                              	" <th class='htotal'>TOTAL</th>",
			                              	" <th class='hcumul'>Cumul V</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	" <th class='hstk'>Stock NEG</th>",
			                              	" <th class='hstk'>Stock NUL</th>",
			                              	" <th class='hstk'>Stock Pos</th>",
			                              	" <th  class='htotal'>TOTAL</th>",
			                              	" <th class='hcumul'>Cumul S</th>",
			                              	" <td class='separator' rowspan='$model.rowSpan'>&nbsp</td>",
			                              	"</tr>",
			                              	//end of table
			                              	"</table>",
			                              	
			                              	"<P align='center'><i>G&eacute;n&eacute;r&eacute; le $model.dateGeneration",
			                              	"</i></P>",
			                              	"</body>",
			                              	"</html>"
			                              });
			return template;
		}
	}
}
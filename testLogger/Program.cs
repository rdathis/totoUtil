/*
 * Utilisateur: Renaud
 * Date: 13/07/2017
 * Heure: 12:57:39
 * 
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NVelocity;
using NVelocity.App;
using cmdUtils.Objets;
using cmdUtils.Objets.business;
using log4net;
using log4net.Config;
using log4net.DateFormatter;

namespace testLogger
{
	class Program
	{
		public static void Main(string[] args)
		{
			log4net.ILog LOGGER = LogManager.GetLogger("testUtil");
			
			Console.WriteLine("Hello World!");
			//BasicConfigurator.Configure();
			
			//log4net.Config.XmlConfigurator.Configure();
			const string file = "W:/meo-moulinettes/conf/logger.config";
			if (File.Exists(file)) {
				XmlConfigurator.Configure(new Uri(file));
			} else {
				Console.WriteLine("Erreur : config absent : " + file);
			}
			System.Diagnostics.Debug.Print("starting");
			LOGGER.Debug("it's raining");
			LOGGER.Info("water spotted");
			LOGGER.Warn("we are sinking !");
			LOGGER.Error("so many fishes");
			
			Console.Write("Press any key to continue . . . ");
			//testNV();
			
			Program prog = new Program();
			prog.testRecap(prog.getMock());
			//prog.getRecapTemplate();
			Console.ReadKey(true);
			
			/*
Hello World!
xxxx 348  [1] INFO  testUtil (null) - info
xxxx 391  [1] DEBUG testUtil (null) - debug
xxxx 391  [1] WARN  testUtil (null) - warn
xxxx 391  [1] ERROR testUtil (null) - error
Press any key to continue . . .
 
 https://logging.apache.org/log4net/log4net-1.2.13/release/sdk/log4net.Layout.PatternLayout.html
			 */
		}
		private static void testNV()
		{
			Velocity.Init();
			var model = getModel();
			VelocityContext velocityContext = new VelocityContext();
			velocityContext.Put("model", model);
			
			String template = getTemplate();
			
			StringBuilder sb = new StringBuilder();
			Velocity.Evaluate(
				velocityContext,
				new StringWriter(sb),
				"test template",
				new StringReader(template));
			
			Console.WriteLine(sb.ToString());
		}
		private static object getModel()
		{
			var model = new {
				Header = "Test Header",
				Items = new[] {
				new { ID = 1, Name = "Name1", Bold = false},
				new { ID = 2, Name = "Name2", Bold = false},
				new { ID = 3, Name = "Name3", Bold = true}
			}
			};
			return model;
		}

		static string getTemplate()
		{
			string template = string.Join(Environment.NewLine, new [] {
				"<p>",
				"   This is model.Header: <strong>$model.Header</strong>",
				"</p>",
				"<ul>",
				"#foreach($item in $model.Items)",
				"   <li>",
				"      item.ID: $item.ID,",
				"#if ($item.Bold)",
				"      item.Name: <b>$item.Name</b>",
				"#else",
				"      item.Name: $item.Name",
				"#end",
				"   </li>",
				"#end",
				"</ul>"
			});
			return template;
		}

		List<MouliAnneeRecap> getMock()
		{
			List<MouliAnneeRecap> liste = new List<MouliAnneeRecap>();
			{
				MouliAnneeRecap recap = new MouliAnneeRecap("2014");
				recap.setNbVisL(1);
				recap.setNbVisO(2);
				recap.setSt(100, 10000, 3);
				liste.Add(recap);
			}
			{
				MouliAnneeRecap recap = new MouliAnneeRecap("2004");
				recap.setNbVisL(10);
				recap.setNbVisO(20);
				recap.setSt(100, 10000, 3);
				liste.Add(recap);
			}
			{
				MouliAnneeRecap recap = new MouliAnneeRecap("2018");
				recap.setNbVisL(13);
				recap.setNbVisO(20);
				recap.setSt(100, 10000, 3);
				liste.Add(recap);
			}
			
			return liste;
		}

		void testRecap(List<MouliAnneeRecap> liste)
		{
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
				magId = "1234",
				magIrris = "01",
			            //				
				dateGeneration = (DateTime.Now.ToString()),
				Items = tablo, 
				tnVO, tnVL, tsNe, tsNu, tsPo, tnVT = tnVO + tnVL, tsTo = tsNe + tsNu + tsPo,
				rowspan = liste.Count, 
				listeCount = liste.Count
			};

			Velocity.Init();
			String template = getRecapTemplate();
			StringBuilder sb = new StringBuilder();
			VelocityContext velocityContext = new VelocityContext();
			velocityContext.Put("model", model);
			Velocity.Evaluate(
				velocityContext,
				new StringWriter(sb),
				"test template",
				new StringReader(template));
			Console.WriteLine(sb.ToString());
			Console.Write("");

		}
		
		String getRecapTemplate()
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
				" <td class='separator' rowspan='$model.rowspan'>&nbsp</td>",
				" <th class='hvis'>V. OPT</th>",
				" <th class='hvis'>V. LEN</th>",
				" <th class='htotal'>TOTAL</th>",
				" <th class='hcumul'>Cumul V</th>",
				" <td class='separator' rowspan='$model.rowspan'>&nbsp</td>",
				" <th class='hstk'>Stock NEG</th>",
				" <th class='hstk'>Stock NUL</th>",
				" <th class='hstk'>Stock Pos</th>",
				" <th  class='htotal'>TOTAL</th>",
				" <th class='hcumul'>Cumul S</th>",
				" <td class='separator' rowspan='$model.rowspan'>&nbsp</td>",
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